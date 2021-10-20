using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWord
{
    public static class ConvertorManager
    {
        /// <summary>
        /// get control to process number
        /// </summary>
        /// <param name="CurrencyId">refrence currency id</param>
        /// <param name="CurrencyName">Standard Name</param>
        /// <param name="CurrencyCode">Standard Code</param>
        /// <param name="EnglishCurrencyName">currency name in english as single</param>
        /// <param name="EnglishPluralCurrencyName">currency name in english as plural</param>
        /// <param name="EnglishCurrencyPartName"></param>
        /// <param name="EnglishPluralCurrencyPartName"></param>
        /// <param name="PartPrecision">Decimal Part Precision
        /// for Syrian Pounds: 2 ( 1 SP = 100 parts)
        /// for Tunisian Dinars: 3 ( 1 TND = 1000 parts)</param>
        /// <returns>interface control</returns>
        public static IConvertorToWordCore GetConvertorEnglish(
            string CurrencyId,
            string CurrencyName,
            string CurrencyCode,
            
            string EnglishCurrencyName,
            string EnglishPluralCurrencyName,
            string EnglishCurrencyPartName,
            string EnglishPluralCurrencyPartName,
            
            Byte PartPrecision = 2)
        {
            return new English.ConvertorToWord_English(new English.EnglishCurrencyInfo(
                CurrencyId,
                CurrencyName,
                CurrencyCode,
                PartPrecision,

                EnglishCurrencyName,
                EnglishPluralCurrencyName,
                EnglishCurrencyPartName,
                EnglishPluralCurrencyPartName));
        }




        public static IConvertorToWordCore GetConvertorArabic(
            string CurrencyId,
            string CurrencyName,
            string CurrencyCode,

            Boolean IsCurrencyNameFeminine,
            string Arabic1CurrencyName,
            string Arabic2CurrencyName,
            string Arabic310CurrencyName,
            string Arabic1199CurrencyName,
            Boolean IsCurrencyPartNameFeminine,
            string Arabic1CurrencyPartName,
            string Arabic2CurrencyPartName,
            string Arabic310CurrencyPartName,
            string Arabic1199CurrencyPartName,

            Byte PartPrecision = 2)
        {
            return new Arabic.ConvertorToWord_Arabic(new Arabic.ArabicCurrencyInfo(
                CurrencyId,
                CurrencyName,
                CurrencyCode,
                PartPrecision,

                IsCurrencyNameFeminine,
                Arabic1CurrencyName,
                Arabic2CurrencyName,
                Arabic310CurrencyName,
                Arabic1199CurrencyName,
                IsCurrencyPartNameFeminine,
                Arabic1CurrencyPartName,
                Arabic2CurrencyPartName,
                Arabic310CurrencyPartName,
                Arabic1199CurrencyPartName
            ));
        }

   
        public static string ConvertToWord_English_Point(
            Decimal Number,
            string EnglishPrefixText,
            string EnglishSuffixText,
            Byte PartPrecision = 2,
            string PointStr = "POINT")
        {
            return Helpers.EnglishHelper.ConvertToWord_Point(
                Number,
                PartPrecision,
                PointStr,
                EnglishPrefixText, EnglishSuffixText);
        }

        public static string ConvertToWord_Arabic_Point(
            Decimal Number,
            string EnglishPrefixText,
            string EnglishSuffixText,
            Byte PartPrecision = 2,
            string PointStr = "فاصلة")
        {
            return Helpers.ArabicHelper.ConvertToWord_Point(
                Number,
                PartPrecision,
                PointStr,
                EnglishPrefixText, EnglishSuffixText);
        }
    }
}
