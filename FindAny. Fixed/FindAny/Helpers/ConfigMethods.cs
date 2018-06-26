using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindAny.Helpers
{
    public class ConfigMethods
    {
        public string GetPlayerName()
        {
            return System.Configuration.ConfigurationSettings.AppSettings["Name"];
        }
        public void SetPlayerName(string value)
        {
            System.Configuration.ConfigurationSettings.AppSettings.Set("Name", value);
        }
        ///
        /// Методы дял рабоыт с уровнем
        /// 
        public string GetLevel()
        {
            return System.Configuration.ConfigurationSettings.AppSettings["Level"];
        }
        public void SetLevel(string value)
        {
            System.Configuration.ConfigurationSettings.AppSettings.Set("Level", value);
        }
    }
}
