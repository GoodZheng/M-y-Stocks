using System.IO;
using System.Text.Json;

namespace MyStocks.Services
{
    public class SettingsService
    {
        private const string SettingsFileName = "settings.json";

        public class AppSettings
        {
            public bool Topmost { get; set; }
            public double Opacity { get; set; }
            public List<string> StockCodes { get; set; } = new List<string>();
        }

        public static void SaveSettings(AppSettings settings)
        {
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(SettingsFileName, json);
        }

        public static AppSettings LoadSettings()
        {
            if (File.Exists(SettingsFileName))
            {
                string json = File.ReadAllText(SettingsFileName);
                return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
            }
            return new AppSettings();
        }
    }
}