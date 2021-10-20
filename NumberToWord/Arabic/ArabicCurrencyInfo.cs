
using System;

namespace NumberToWord.Arabic
{
    public class ArabicCurrencyInfo : CurrencyInfoCore
    {
        /// <summary>
        /// Is the currency name feminine ( Mua'anath مؤنث)
        /// ليرة سورية : مؤنث = true
        /// درهم : مذكر = false
        /// </summary>
        public Boolean IsCurrencyNameFeminine { get; private set; }

        /// <summary>
        /// Arabic Currency Name for 1 unit only
        /// ليرة سورية
        /// درهم إماراتي
        /// </summary>
        public string Arabic1CurrencyName { get; private set; }

        /// <summary>
        /// Arabic Currency Name for 2 units only
        /// ليرتان سوريتان
        /// درهمان إماراتيان
        /// </summary>
        public string Arabic2CurrencyName { get; private set; }

        /// <summary>
        /// Arabic Currency Name for 3 to 10 units
        /// خمس ليرات سورية
        /// خمسة دراهم إماراتية
        /// </summary>
        public string Arabic310CurrencyName { get; private set; }

        /// <summary>
        /// Arabic Currency Name for 11 to 99 units
        /// خمس و سبعون ليرةً سوريةً
        /// خمسة و سبعون درهماً إماراتياً
        /// </summary>
        public string Arabic1199CurrencyName { get; private set; }

        /// <summary>
        /// Is the currency part name feminine ( Mua'anath مؤنث)
        /// هللة : مؤنث = true
        /// قرش : مذكر = false
        /// </summary>
        public Boolean IsCurrencyPartNameFeminine { get; private set; }

        /// <summary>
        /// Arabic Currency Part Name for 1 unit only
        /// قرش
        /// هللة
        /// </summary>
        public string Arabic1CurrencyPartName { get; private set; }

        /// <summary>
        /// Arabic Currency Part Name for 2 unit only
        /// قرشان
        /// هللتان
        /// </summary>
        public string Arabic2CurrencyPartName { get; private set; }

        /// <summary>
        /// Arabic Currency Part Name for 3 to 10 units
        /// قروش
        /// هللات
        /// </summary>
        public string Arabic310CurrencyPartName { get; private set; }

        /// <summary>
        /// Arabic Currency Part Name for 11 to 99 units
        /// قرشاً
        /// هللةً
        /// </summary>
        public string Arabic1199CurrencyPartName { get; private set; }



        public ArabicCurrencyInfo(
            string CurrencyId,
            string CurrencyName,
            string CurrencyCode,
            Byte PartPrecision,

            Boolean IsCurrencyNameFeminine,
            string Arabic1CurrencyName,
            string Arabic2CurrencyName,
            string Arabic310CurrencyName,
            string Arabic1199CurrencyName,
            Boolean IsCurrencyPartNameFeminine,
            string Arabic1CurrencyPartName,
            string Arabic2CurrencyPartName,
            string Arabic310CurrencyPartName,
            string Arabic1199CurrencyPartName

            ) : base(Language.Arabic,
            CurrencyId,
            CurrencyName,
            CurrencyCode,
            PartPrecision)
        {
            this.IsCurrencyNameFeminine = IsCurrencyNameFeminine;
            this.Arabic1CurrencyName = Arabic1CurrencyName;
            this.Arabic2CurrencyName = Arabic2CurrencyName;
            this.Arabic310CurrencyName = Arabic310CurrencyName;
            this.Arabic1199CurrencyName = Arabic1199CurrencyName;
            this.IsCurrencyPartNameFeminine = IsCurrencyPartNameFeminine;
            this.Arabic1CurrencyPartName = Arabic1CurrencyPartName;
            this.Arabic2CurrencyPartName = Arabic2CurrencyPartName;
            this.Arabic310CurrencyPartName = Arabic310CurrencyPartName;
            this.Arabic1199CurrencyPartName = Arabic1199CurrencyPartName;
        }
    }
}
