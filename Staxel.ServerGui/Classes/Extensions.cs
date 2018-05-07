using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusFox.ServerGui.Classes {
    internal static class Extensions {
        internal static string GetString(this bool input) {
            return input ? "true" : "false";
        }
    }
}
