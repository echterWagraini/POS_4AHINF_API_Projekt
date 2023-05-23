using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Smart.Blazor;

namespace NotziAPI_WebApp
{
    public class Settings
    {
        public String id { get; set; }
        public bool darkMode { get; set; }

        public string titleMDPrefix { get; set; }

        public String apiUrl { get; set; }

        public Settings()
        {
            this.apiUrl = "http://localhost:4200"; //default value
            try
            {
                HttpClient httpclient = new HttpClient();

                string data = "";
                data = httpclient.GetStringAsync(apiUrl + "/settings").Result;

                dynamic obj = JsonConvert.DeserializeObject(data);

                this.darkMode = (bool)obj.darkMode;
                if((string)obj.titleMDPrefix != null)
                {
                    this.titleMDPrefix = (string) obj.titleMDPrefix;
                }
                else
                {
                    this.titleMDPrefix = "# ";
                }
                this.id = "1";
            }
            catch (Exception ex)
            {

            }
        }
        public Settings(String id, bool dakrMode, string titleMDPrefix)
        {
            this.id = id;
            this.darkMode = dakrMode;
            this.titleMDPrefix = titleMDPrefix;
        }
    }
}
