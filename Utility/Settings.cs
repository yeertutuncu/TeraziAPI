using Newtonsoft.Json;
using System;
using System.IO;

namespace TeraziAPI.Utility
{
    /// <summary>
    /// Projenin ilgili ayarlarını bir dosyadan okumak ve yazmak amacıyla kullanılan sınıftır.
    /// Çalıştıktan sonra "settings.json" isimli bir ayar dosyasında okuma ve yazma işlemi yapar
    /// </summary>
    public class Settings
    {
        #region Definitions

        public string BaseAddress
        {
            get => _baseAddress ?? null;
            set => _baseAddress = value;
        }

        private string _baseAddress;

        #endregion Definitions

        #region Constructor-Destructor

        public Settings()
        {
        }

        ~Settings()
        {
        }

        #endregion Constructor-Destructor

        #region Functions

        public static void WriteJsonSettings(Settings settings)
        {
            File.WriteAllText(@"settings.json", JsonConvert.SerializeObject(settings));
        }

        public static Settings ReadSettings()
        {
            try
            {
                return File.Exists(@"settings.json")
                    ? JsonConvert.DeserializeObject<Settings>(File.ReadAllText(@"settings.json"))
                    : new Settings();
            }
            catch (FileLoadException exf)
            {
                throw exf;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Functions
    }
}