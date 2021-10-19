using System;

namespace NumberToWord.English
{
    public class EnglishCurrencyInfo : CurrencyInfoCore
    {
        /// <summary>
        /// English Currency Name for single use
        /// Syrian Pound
        /// UAE Dirham
        /// </summary>
        public string EnglishCurrencyName { get; set; }

        /// <summary>
        /// English Plural Currency Name for Numbers over 1
        /// Syrian Pounds
        /// UAE Dirhams
        /// </summary>
        public string EnglishPluralCurrencyName { get; set; }


        /// <summary>
        /// English Currency Part Name for single use
        /// Piaster
        /// Fils
        /// </summary>
        public string EnglishCurrencyPartName { get; set; }

        /// <summary>
        /// English Currency Part Name for Plural
        /// Piasters
        /// Fils
        /// </summary>
        public string EnglishPluralCurrencyPartName { get; set; }

        public EnglishCurrencyInfo(
            string CurrencyId,
            string CurrencyName,
            string CurrencyCode
            ) : base(Language.English,
            CurrencyId,
            CurrencyName,
            CurrencyCode)
        {

        }
    }
}
