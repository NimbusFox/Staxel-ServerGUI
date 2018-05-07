using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusFox.ServerGUI.Hook.Classes.Pipe {
    [Serializable]
    public class PipeClass {
        public KeyEnum Current { get; set; }
        public object Data { get; set; }
    }
}
