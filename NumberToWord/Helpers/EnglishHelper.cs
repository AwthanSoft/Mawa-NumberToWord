using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWord.Helpers
{
    static class EnglishHelper
    {
        #region Varaibles

        private static string[] englishOnes =
           new string[] {
            "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        private static string[] englishTens =
            new string[] {
            "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
        };

        private static string[] englishGroup =
            new string[] {
            "Hundred", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillian",
            "Septillion", "Octillion", "Nonillion", "Decillion", "Undecillion", "Duodecillion", "Tredecillion",
            "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septendecillion", "Octodecillion", "Novemdecillion",
            "Vigintillion", "Unvigintillion", "Duovigintillion", "10^72", "10^75", "10^78", "10^81", "10^84", "10^87",
            "Vigintinonillion", "10^93", "10^96", "Duotrigintillion", "Trestrigintillion"
        };

        #endregion

        #region Convertor
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Number">Number to be converted</param>
        /// <returns></returns>
        public static string ConvertToWord_Point(
            Decimal Number,
            Byte PartPrecision,
            string PointStr,
            string EnglishPrefixText,
            string EnglishSuffixText)
        {
            CoreHelper.ExtractIntegerAndDecimalParts(Number, PartPrecision, out long intergerValue, out int decimalValue);

            var NumStr = ConvertToEnglish_Point(Number, intergerValue, decimalValue, PointStr);

            String formattedNumber = String.Empty;
            formattedNumber += (EnglishPrefixText != String.Empty) ? String.Format("{0} ", EnglishPrefixText) : String.Empty;
            formattedNumber += NumStr;
            formattedNumber += (EnglishSuffixText != String.Empty) ? String.Format(" {0}", EnglishSuffixText) : String.Empty;

            return formattedNumber;
        }

        /// <summary>
        /// Process a group of 3 digits
        /// </summary>
        /// <param name="groupNumber">The group number to process</param>
        /// <returns></returns>
        private static string ProcessGroup(int groupNumber)
        {
            int tens = groupNumber % 100;

            int hundreds = groupNumber / 100;

            string retVal = String.Empty;

            if (hundreds > 0)
            {
                retVal = String.Format("{0} {1}", englishOnes[hundreds], englishGroup[0]);
            }
            if (tens > 0)
            {
                if (tens < 20)
                {
                    retVal += ((retVal != String.Empty) ? " " : String.Empty) + englishOnes[tens];
                }
                else
                {
                    int ones = tens % 10;

                    tens = (tens / 10) - 2; // 20's offset

                    retVal += ((retVal != String.Empty) ? " " : String.Empty) + englishTens[tens];

                    if (ones > 0)
                    {
                        retVal += ((retVal != String.Empty) ? " " : String.Empty) + englishOnes[ones];
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Convert stored number to words using selected currency
        /// </summary>
        /// <returns></returns>
        private static string ConvertToEnglish_Point(
            Decimal Number, 
            long intergerValue, 
            int decimalValue,
            string PointStr)
        {
            Decimal tempNumber = Number;

            if (tempNumber == 0)
                return "Zero";

            string decimalString = ProcessGroup(decimalValue);

            string retVal = String.Empty;

            int group = 0;

            if (tempNumber < 1)
            {
                retVal = englishOnes[0];
            }
            else
            {
                while (tempNumber >= 1)
                {
                    int numberToProcess = (int)(tempNumber % 1000);

                    tempNumber = tempNumber / 1000;

                    string groupDescription = ProcessGroup(numberToProcess);

                    if (groupDescription != String.Empty)
                    {
                        if (group > 0)
                        {
                            retVal = String.Format("{0} {1}", englishGroup[group], retVal);
                        }

                        //retVal = String.Format("{0} {1}", groupDescription, retVal);
                        retVal = (retVal != string.Empty) ?
                            String.Format("{0} {1}", groupDescription, retVal)
                            :
                            String.Format("{0}", groupDescription);
                    }

                    group++;
                }
            }

            String formattedNumber = String.Empty;
            formattedNumber += (retVal != String.Empty) ? retVal : String.Empty;
            formattedNumber += (decimalString != String.Empty) ? string.Format(" {0} ", PointStr) : String.Empty;
            formattedNumber += (decimalString != String.Empty) ? decimalString : String.Empty;

            return formattedNumber;
        }


        #endregion
    }
}
