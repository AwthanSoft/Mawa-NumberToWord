using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWord
{
    abstract class ConvertorToWordCore
    {
        /// Group Levels: 987,654,321.234
        /// 234 : Group Level -1
        /// 321 : Group Level 0
        /// 654 : Group Level 1
        /// 987 : Group Level 2
        

        public CurrencyInfoCore CurrencyInfo { get; private set; }
        public Language language => CurrencyInfo.language;
        public ConvertorToWordCore(CurrencyInfoCore CurrencyInfo)
        {

        }

        #region General

        /// <summary>
        /// Get Proper Decimal Value
        /// </summary>
        /// <param name="decimalPart">Decimal Part as a String</param>
        /// <returns></returns>
        private string GetDecimalValue(string decimalPart)
        {
            string result = String.Empty;

            if (CurrencyInfo.PartPrecision != decimalPart.Length)
            {
                int decimalPartLength = decimalPart.Length;

                for (int i = 0; i < CurrencyInfo.PartPrecision - decimalPartLength; i++)
                {
                    decimalPart += "0"; //Fix for 1 number after decimal ( 10.5 , 1442.2 , 375.4 ) 
                }

                result = String.Format("{0}.{1}", decimalPart.Substring(0, CurrencyInfo.PartPrecision), decimalPart.Substring(CurrencyInfo.PartPrecision, decimalPart.Length - CurrencyInfo.PartPrecision));

                result = (Math.Round(Convert.ToDecimal(result))).ToString();
            }
            else
                result = decimalPart;

            for (int i = 0; i < CurrencyInfo.PartPrecision - result.Length; i++)
            {
                result += "0";
            }

            return result;
        }


        /// <summary>
        /// Eextract Interger and Decimal parts
        /// </summary>
        /// <param name="Number">Number to be converted</param>
        /// <param name="intergerValue">integer part</param>
        /// <param name="decimalValue">Decimal Part</param>
        protected void ExtractIntegerAndDecimalParts(Decimal Number, out long intergerValue, out int decimalValue)
        {
            String[] splits = Number.ToString().Split('.');

            intergerValue = Convert.ToInt32(splits[0]);

            if (splits.Length > 1)
                decimalValue = Convert.ToInt32(GetDecimalValue(splits[1]));
            //me
            else
                decimalValue = 0;
        }

        #endregion



    }
}
