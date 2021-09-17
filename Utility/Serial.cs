using System;
using System.IO.Ports;

namespace TeraziAPI.Utility
{
    /// <summary>
    /// ApiController ile System.IO.Ports.SerialPort sınıfları arasında veriyi cihazdan okumak için kullanılan köprü vazifesi gören yardımcı sınıftır
    /// </summary>
    public class Serial
    {
        #region Definitions

        /// <summary>
        /// System.IO.Ports.SerialPort nesnesini bağlı cihazdan veri okumak için kullanırız
        /// </summary>
        public SerialPort SerialObject { get; set; }

        #endregion Definitions

        #region Constructor-Destructor

        public Serial()
        {
            try
            {
                if (SerialPort.GetPortNames().Length == 0)
                {
                    return;
                }                    
                this.SerialObject = new SerialPort()
                {
                    Parity = Parity.None,
                    StopBits = StopBits.One,
                    BaudRate = 9600,
                    PortName = SerialPort.GetPortNames()[0],
                    /* Yazılımcının Dikkatine:
                     * SerialPort.GetPortNames()[0] : Port Adı nesnesi burada indeks olarak "0" verildi.
                     * Aygıt yöneticisinde görünen COM Portlarından ilkini alır.
                     * Bu kısım parametrik yapılabilir fakat bunu direkt makinelere bağlayacağımız için şimdilik gerek duymadım
                     */
                };

                if (!this.SerialObject.IsOpen)
                    this.SerialObject.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ~Serial()
        {
        }

        #endregion Constructor-Destructor

        #region Functions

        /// <summary>
        ///
        /// </summary>
        /// <returns>SerialPort nesnesinden okunan veriyi getirir</returns>
        public string GetValues()
        {
            try
            {
                if (!SerialObject.IsOpen)
                    SerialObject.Open();

                var s = SerialObject.ReadExisting();

                string[] arr = s.Replace("\r","").Split('\n');

                for (int i = arr.Length-1; i >=0; i--)
                {
                    if (arr[i].Length == 25)
                    { s = arr[i];
                        break;
                    }
                }
                
                SerialObject.Close();

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Functions
    }
}