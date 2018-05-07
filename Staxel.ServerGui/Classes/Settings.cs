using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plukit.Base;

namespace NimbusFox.ServerGui.Classes {
    internal class Settings {
        public bool Creative { get; set; }
        public string IP { get; set; }
        public string Name { get; set; }
        public bool UsePassword { get; set; }
        public string Password { get; set; }
        public long PlayerLimit { get; set; }
        public long Port { get; set; }
        public bool Public { get; set; }
        public string WorldName { get; set; }
        public bool Upnp { get; set; }
        public bool WeakAuthentication { get; set; }

        public Settings() {
            Creative = false;
            IP = "Any IP";
            Name = "server";
            UsePassword = true;
            Password = "";
            PlayerLimit = 4;
            Port = 38465;
            Public = false;
            WorldName = "server";
            Upnp = true;
            WeakAuthentication = false;
        }

        internal void FromBlob(Blob blob) {
            Creative = blob.GetBool("Creative", Creative);
            IP = blob.GetString("IP", IP);
            Name = blob.GetString("Name", Name);
            UsePassword = blob.GetBool("UsePassword", UsePassword);
            Password = blob.GetString("Password", Password);
            PlayerLimit = blob.GetLong("PlayerLimit", PlayerLimit);
            Port = blob.GetLong("Port", Port);
            Public = blob.GetBool("Public", Public);
            WorldName = blob.GetString("WorldName", WorldName);
            Upnp = blob.GetBool("Upnp", Upnp);
            WeakAuthentication = blob.GetBool("WeakAuthentication", WeakAuthentication);
        }

        internal Blob ToBlob() {
            var blob = BlobAllocator.AcquireAllocator().NewBlob(true);

            blob.SetBool("Creative", Creative);
            blob.SetString("IP", IP);
            blob.SetString("Name", Name);
            blob.SetBool("UsePassword", UsePassword);
            blob.SetString("Password", Password);
            blob.SetLong("PlayerLimit", PlayerLimit);
            blob.SetLong("Port", Port);
            blob.SetBool("Public", Public);
            blob.SetString("WorldName", WorldName);
            blob.SetBool("Upnp", Upnp);
            blob.SetBool("WeakAuthentication", WeakAuthentication);

            return blob;
        }

        public string CommandArgs {
            get {
                var output = new StringBuilder();

                output.Append($"--creative={Creative.GetString()} ");
                output.Append($"--interface={IP} ");
                output.Append($"--name={Name} ");
                if (UsePassword) {
                    output.Append($"--password={Password} ");
                }
                output.Append($"--playerlimit={PlayerLimit} ");
                output.Append($"--port={Port} ");
                output.Append($"--public={Public.GetString()} ");
                output.Append($"--storage={WorldName} ");
                output.Append($"--upnp={Upnp.GetString()} ");
                output.Append($"--weakAuthentication={WeakAuthentication.GetString()} ");

                return output.ToString();
            }
        }
    }
}
