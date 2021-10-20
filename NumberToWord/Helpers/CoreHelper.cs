using System;


namespace NumberToWord.Helpers
{
    static class CoreHelper
    {
        #region Convertor Core

        /// <summary>
        /// Get Proper Decimal Value
        /// </summary>
        /// <param name="decimalPart">Decimal Part as a String</param>
        /// <returns></returns>
        private static string GetDecimalValue(string decimalPart, Byte PartPrecision)
        {
            string result = String.Empty;

            if (PartPrecision != decimalPart.Length)
            {
                int decimalPartLength = decimalPart.Length;

                for (int i = 0; i < PartPrecision - decimalPartLength; i++)
                {
                    decimalPart += "0"; //Fix for 1 number after decimal ( 10.5 , 1442.2 , 375.4 ) 
                }

                result = String.Format("{0}.{1}", decimalPart.Substring(0, PartPrecision), decimalPart.Substring(PartPrecision, decimalPart.Length - PartPrecision));

                result = (Math.Round(Convert.ToDecimal(result))).ToString();
            }
            else
                result = decimalPart;

            for (int i = 0; i < PartPrecision - result.Length; i++)
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
        public static void ExtractIntegerAndDecimalParts(Decimal Number, Byte PartPrecision, out long intergerValue, out int decimalValue)
        {
            String[] splits = Number.ToString().Split('.');

            intergerValue = Convert.ToInt32(splits[0]);

            if (splits.Length > 1)
                decimalValue = Convert.ToInt32(GetDecimalValue(splits[1], PartPrecision));
            //me
            else
                decimalValue = 0;
        }

        #endregion
    }
}
