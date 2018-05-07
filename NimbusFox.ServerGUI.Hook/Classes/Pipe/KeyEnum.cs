using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusFox.ServerGUI.Hook.Classes.Pipe {
    [Serializable]
    public enum KeyEnum {
        Connected,
        Message,
        Whisper,
        Ban,
        Kick,
        Intergrated,
        OnlineUsers,
        Unban,
        Mute,
        UnMute
    }
}
