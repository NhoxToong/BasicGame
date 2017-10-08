using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Config : IDisposable
    {
        private static Config _instance = null;
        public static Config Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Config();
                return _instance;
            }

        }
        public static JObject jsonConfig=null;

        public void Load()
        {
            var path = $"{ConstantValue.APP_PATH}\\{ConstantValue.config_db}";
            var jsonText = File.ReadAllText(path);
            jsonConfig = JObject.Parse(jsonText);

            double scaleX = double.Parse(jsonConfig["scaleX"].ToString());
        }

        public void Save()
        {
            var path = $"{ConstantValue.APP_PATH}\\{ConstantValue.config_db}";
            jsonConfig["scaleX"] = 1.2;
            File.WriteAllText(path,jsonConfig.ToString());
        }

        public string[] LoadUnitTexture(string unitname)
        {
            return (jsonConfig["units"][unitname] as JArray).Select(v => v.ToString()).ToArray();
        }

        public void Dispose()
        {
            jsonConfig = null;
            GC.Collect();
        }
    }
}
