using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NamedPipeWrapper;
using NimbusFox.ServerGUI.Hook.Classes.Pipe;
using Plukit.Base;
using Staxel;
using Staxel.Items;
using Staxel.Logic;
using Staxel.Modding;
using Staxel.Server;
using Staxel.Tiles;

namespace NimbusFox.ServerGUI.Hook {
    public class ModHook : IModHookV3 {

        private readonly NamedPipeServer<PipeClass> _pipeServer = new NamedPipeServer<PipeClass>("ServerGUI");

        private ServerMainLoop _serverMainLoop;

        private readonly List<string> _serverMessages = new List<string>();

        private readonly List<string> _serverKicks = new List<string>();

        private readonly Dictionary<string, string> _serverBans = new Dictionary<string, string>();

        private readonly List<string> _serverUnbans = new List<string>();

        private readonly Dictionary<string, int> _serverMutes = new Dictionary<string, int>();

        private readonly List<string> _serverUnMutes = new List<string>();

        private readonly Lyst<Entity> _serverUsers = new Lyst<Entity>();

        public ModHook() {
            if (System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Contains("Staxel.Server")) {
                _pipeServer.ClientConnected += _pipeServer_ClientConnected;

                _pipeServer.ClientMessage += _pipeServer_ClientMessage;

                _pipeServer.Start();
            }
        }

        private void _pipeServer_ClientMessage(NamedPipeConnection<PipeClass, PipeClass> connection, PipeClass message) {
            if (message.Current == KeyEnum.Message) {
                _serverMessages.Add((string)message.Data);
            } else if (message.Current == KeyEnum.Kick) {
                _serverKicks.Add((string)message.Data);
            } else if (message.Current == KeyEnum.Ban) {
                var data = (NameReason)message.Data;
                if (!_serverBans.Any(x => string.Equals(x.Key, data.Name, StringComparison.CurrentCultureIgnoreCase))) {
                    _serverBans.Add(data.Name, data.Reason);
                }
            } else if (message.Current == KeyEnum.Unban) {
                _serverUnbans.Add((string)message.Data);
            } else if (message.Current == KeyEnum.Mute) {
                var data = (NameMinutes)message.Data;
                if (!_serverMutes.Any(x => string.Equals(x.Key, data.Name, StringComparison.CurrentCultureIgnoreCase))) {
                    _serverMutes.Add(data.Name, data.Minutes);
                }
            } else if (message.Current == KeyEnum.UnMute) {
                _serverUnMutes.Add((string)message.Data);
            }
        }

        private void _pipeServer_ClientConnected(NamedPipeConnection<PipeClass, PipeClass> connection) {
            connection.PushMessage(new PipeClass {
                Current = KeyEnum.Connected
            });
            connection.PushMessage(new PipeClass {
                Current = KeyEnum.OnlineUsers,
                Data = _serverUsers.Select(x => x.PlayerEntityLogic.DisplayName()).ToList()
            });
        }

        public void Dispose() { }
        public void GameContextInitializeInit() { }
        public void GameContextInitializeBefore() { }
        public void GameContextInitializeAfter() {
        }
        public void GameContextDeinitialize() { }
        public void GameContextReloadBefore() { }
        public void GameContextReloadAfter() { }
        public void UniverseUpdateAfter() {

            if (_serverMainLoop == null && ServerContext.VillageDirector != null && ServerContext.VillageDirector.HasDirectorFacade()) {
                _serverMainLoop = (ServerMainLoop)typeof(DirectorUniverseFacade)
                    .GetField("_serverMainLoop",
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    ?.GetValue(ServerContext.VillageDirector.UniverseFacade);

                _pipeServer.PushMessage(new PipeClass {
                    Current = KeyEnum.Intergrated
                });
            }
        }

        public bool CanRemoveTile(Entity entity, Vector3I location, TileAccessFlags accessFlags) {
            return true;
        }

        public bool CanReplaceTile(Entity entity, Vector3I location, Tile tile, TileAccessFlags accessFlags) {
            return true;
        }

        public bool CanPlaceTile(Entity entity, Vector3I location, Tile tile, TileAccessFlags accessFlags) {
            return true;
        }

        public void UniverseUpdateBefore(Universe universe, Timestep step) {
            if (_serverMessages.Any() && _serverMainLoop != null) {
                var first = _serverMessages.First();
                _serverMessages.Remove(first);
                Logger.WriteLine("<Server>: " + first);

                var online = new Lyst<Entity>();

                universe.GetPlayers(online);

                foreach (var player in online) {
                    _serverMainLoop.MessagePlayer(player.PlayerEntityLogic.Uid(), "&lt;Server&gt;: " + first, new object[0]);
                }
            }

            if (_serverKicks.Any() && _serverMainLoop != null) {
                var first = _serverKicks.First();
                _serverKicks.Remove(first);

                var online = new Lyst<Entity>();

                universe.GetPlayers(online);

                if (online.Any(x => string.Equals(x.PlayerEntityLogic.DisplayName(), first,
                    StringComparison.CurrentCultureIgnoreCase))) {
                    _serverMainLoop.KickPlayer(online.First(x => string.Equals(x.PlayerEntityLogic.DisplayName(), first,
                        StringComparison.CurrentCultureIgnoreCase)).PlayerEntityLogic.Uid());
                } else {
                    Logger.WriteLine("Unable to kick '" + first + "'. Please check if they are online");
                }
            }

            if (_serverBans.Any() && _serverMainLoop != null) {
                var first = _serverBans.First();
                _serverBans.Remove(first.Key);

                var online = new Lyst<Entity>();

                universe.GetPlayers(online);

                var target = online.FirstOrDefault(x => string.Equals(x.PlayerEntityLogic.DisplayName(), first.Key,
                    StringComparison.CurrentCultureIgnoreCase));

                if (target != null) {
                    ServerContext.RightsManager.BanUser(target.PlayerEntityLogic.DisplayName(),
                        target.PlayerEntityLogic.Uid(), first.Value);
                } else {
                    Logger.WriteLine("Unable to ban '" + first + "'. Please check they are online");
                }
            }

            if (_serverUnbans.Any() && _serverMainLoop != null) {
                var first = _serverUnbans.First();
                _serverUnbans.Remove(first);

                string uid;
                if (ServerContext.RightsManager.TryGetUIDByUsername(first, out uid)) {
                    ServerContext.RightsManager.UnbanUser(first, uid);
                } else {
                    Logger.WriteLine("Unable to unban '" + first + "'.");
                }
            }

            if (_serverMutes.Any() && _serverMainLoop != null) {
                var first = _serverMutes.First();
                _serverMutes.Remove(first.Key);

                var online = new Lyst<Entity>();

                universe.GetPlayers(online);

                var target = online.FirstOrDefault(x => string.Equals(x.PlayerEntityLogic.DisplayName(), first.Key,
                    StringComparison.CurrentCultureIgnoreCase));

                if (target != null) {
                    ServerContext.RightsManager.MuteUser(target.PlayerEntityLogic.Uid(),
                        target.PlayerEntityLogic.DisplayName(), step, first.Value);
                } else {
                    Logger.WriteLine("Unable to mute '" + first.Key + "'. Please check they are online");
                }

                SendUserList();
            }

            if (_serverUnMutes.Any() && _serverMainLoop != null) {
                var first = _serverUnMutes.First();
                _serverUnMutes.Remove(first);

                var online = new Lyst<Entity>();

                universe.GetPlayers(online);

                var target = online.FirstOrDefault(x => string.Equals(x.PlayerEntityLogic.DisplayName(), first,
                    StringComparison.CurrentCultureIgnoreCase));

                if (target != null) {
                    ServerContext.RightsManager.UnmuteUser(target.PlayerEntityLogic.Uid());
                } else {
                    Logger.WriteLine("Unable to unmute '" + first + "'. Please check they are online");
                }
                SendUserList();
            }

            if (_serverMainLoop != null) {
                if (_serverUsers.Count != universe.GetPlayerCount()) {
                    _serverUsers.Clear();

                    universe.GetPlayers(_serverUsers);

                    SendUserList();
                }
            }
        }

        private void SendUserList() {
            _pipeServer.PushMessage(new PipeClass {
                Current = KeyEnum.OnlineUsers,
                Data = _serverUsers.Select(x => x.PlayerEntityLogic.DisplayName() + (ServerContext.RightsManager.IsMuted(x.PlayerEntityLogic.Uid()) ? " (Muted)" : "")).ToList()
            });
        }

        public void ClientContextInitializeInit() { }
        public void ClientContextInitializeBefore() { }
        public void ClientContextInitializeAfter() { }
        public void ClientContextDeinitialize() { }
        public void ClientContextReloadBefore() { }
        public void ClientContextReloadAfter() { }
        public void CleanupOldSession() { }
        public bool CanInteractWithTile(Entity entity, Vector3F location, Tile tile) {
            return true;
        }

        public bool CanInteractWithEntity(Entity entity, Entity lookingAtEntity) {
            return true;
        }
    }
}
