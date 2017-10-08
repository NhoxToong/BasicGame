using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    static class ConstantValue
    {
        public const string config_db = "config.json";

        public static string APP_PATH = string.Empty;

        static ConstantValue()
        {
            APP_PATH = Path.GetDirectoryName(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path);
        }
    }
}
