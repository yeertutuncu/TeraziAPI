using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace TeraziAPI.Utility
{
    public class WeightData
    {
        /// <summary>
        /// "OL" : OVER LOAD, "UL" : UNDER LOAD, "ST" : WEIGHT STEADY, "US" : WEIGHT WAVE
        /// </summary>
        public string Header1 { get; set; }
        /// <summary>
        /// "NT" : (NET WEIGHT MODE) , "GS" : (GROSS WEIGHT MODE)
        /// </summary>
        public string Header2 { get; set; }
        /// <summary>
        /// SIGN Signal ( "+" or "-" )
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// Weight(Decimal Point Included)
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// "kg" : Unit of Kilogram, "t": Unit of TON, "lb" : Unit of Pound
        /// </summary>
        public string Unit { get; set; }
        public WeightData()
        {
        }
        /// <summary>
        /// Doğru gelen veri 25 karakterden oluşmakta ve ilgili şekilde parçalanıp tekrar bir nesne olarak geri dönmektedir
        /// </summary>
        /// <returns>WeightData</returns>
        public WeightData GetData()
        {            
            string textData = ""; //Sample Data: "US,NT,+0014.30, 0000.00kg"

            try
            {
                textData = Program.Serial.GetValues().Trim();
                
                if (textData.Length != 25) return null;

                if (textData[6].ToString() == "-") return null;

                decimal dWeight = 0;

                decimal.TryParse(textData.Substring(7, 7).Replace('.', ','), out dWeight);

                WeightData data = new WeightData()
                {
                    Header1 = textData.Substring(0, 2),
                    Header2 = textData.Substring(3, 2),
                    Sign = textData[6].ToString(),
                    Weight = dWeight,
                    Unit = textData.Substring(textData.Length - 2, 2)
                };

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
