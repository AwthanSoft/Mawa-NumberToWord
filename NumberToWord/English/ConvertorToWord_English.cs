using System;

using CurrencyInfo = NumberToWord.English.EnglishCurrencyInfo;

namespace NumberToWord.English
{
    class ConvertorToWord_English : ConvertorToWordCore
    {
        /// Group Levels: 987,654,321.234
        /// 234 : Group Level -1
        /// 321 : Group Level 0
        /// 654 : Group Level 1
        /// 987 : Group Level 2

        #region Varaibles & Properties

        /// <summary>
        /// Currency to use
        /// </summary>
        public CurrencyInfo Currency => (CurrencyInfo)base.CurrencyInfo;

        #endregion

        #region General

        /// <summary>
        /// Constructor: short version
        /// </summary>
        /// <param name="currency">Currency to use</param>
        public ConvertorToWord_English(CurrencyInfo currency) : base(currency)
        {

        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Number">Number to be converted</param>
        /// <returns></returns>
        public override string ConvertToWord(Decimal Number)
        {
            ExtractIntegerAndDecimalParts(Number, out long intergerValue, out int decimalValue);
            return ConvertToEnglish(Number, intergerValue, decimalValue);
        }

        #region English Number To Word

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

        /// <summary>
        /// Process a group of 3 digits
        /// </summary>
        /// <param name="groupNumber">The group number to process</param>
        /// <returns></returns>
        private string ProcessGroup(int groupNumber)
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
        public string ConvertToEnglish(Decimal Number, long intergerValue, int decimalValue)
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

                        retVal = String.Format("{0} {1}", groupDescription, retVal);
                    }

                    group++;
                }
            }

            String formattedNumber = String.Empty;
            formattedNumber += (ConvertorSettings_English.EnglishPrefixText != String.Empty) ? String.Format("{0} ", ConvertorSettings_English.EnglishPrefixText) : String.Empty;
            formattedNumber += (retVal != String.Empty) ? retVal : String.Empty;
            formattedNumber += (retVal != String.Empty) ? (intergerValue == 1 ? Currency.EnglishCurrencyName : Currency.EnglishPluralCurrencyName) : String.Empty;
            formattedNumber += (decimalString != String.Empty) ? " and " : String.Empty;
            formattedNumber += (decimalString != String.Empty) ? decimalString : String.Empty;
            formattedNumber += (decimalString != String.Empty) ? " " + (decimalValue == 1 ? Currency.EnglishCurrencyPartName : Currency.EnglishPluralCurrencyPartName) : String.Empty;
            formattedNumber += (ConvertorSettings_English.EnglishSuffixText != String.Empty) ? String.Format(" {0}", ConvertorSettings_English.EnglishSuffixText) : String.Empty;

            return formattedNumber;
        }

        #endregion
        
    }
}
