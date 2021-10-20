using NumberToWord.Arabic;
using NumberToWord.English;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWord.Test.Controls
{
    class MainTest_InterfaceCtrl : INotifyPropertyChanged
    {
        #region Static
        public enum Currency{ Syria = 0, UAE, SaudiArabia, Tunisia, Gold, Yemen, General };
        public class CurrencyInfo
        {
            #region Constructors

            public CurrencyInfo(Currency currency)
            {
                switch (currency)
                {
                    case Currency.General:
                        {
                            CurrencyID = 6;
                            CurrencyCode = "";
                            IsCurrencyNameFeminine = false;
                            EnglishCurrencyName = "";
                            EnglishPluralCurrencyName = "";
                            EnglishCurrencyPartName = "";
                            EnglishPluralCurrencyPartName = "";
                            Arabic1CurrencyName = "";
                            Arabic2CurrencyName = "";
                            Arabic310CurrencyName = "";
                            Arabic1199CurrencyName = "";
                            Arabic1CurrencyPartName = "";
                            Arabic2CurrencyPartName = "";
                            Arabic310CurrencyPartName = "";
                            Arabic1199CurrencyPartName = "";
                            PartPrecision = 3;
                            IsCurrencyPartNameFeminine = false;
                            break;
                        }

                    case Currency.Yemen:
                        {
                            CurrencyID = 5;
                            CurrencyCode = "YER";
                            IsCurrencyNameFeminine = false;
                            EnglishCurrencyName = "Yemeni Rial";
                            EnglishPluralCurrencyName = "Yemeni Rials";
                            EnglishCurrencyPartName = "Fils";
                            EnglishPluralCurrencyPartName = "Filses";
                            Arabic1CurrencyName = "ريال يمني";
                            Arabic2CurrencyName = "ريالان يمنيان";
                            Arabic310CurrencyName = "ريالات يمنية";
                            Arabic1199CurrencyName = "ريال يمني";
                            Arabic1CurrencyPartName = "فلس";
                            Arabic2CurrencyPartName = "فلسان";
                            Arabic310CurrencyPartName = "فلس";
                            Arabic1199CurrencyPartName = "فلساً";
                            PartPrecision = 3;
                            IsCurrencyPartNameFeminine = false;
                            break;
                        }

                    case Currency.Syria:
                        CurrencyID = 0;
                        CurrencyCode = "SYP";
                        IsCurrencyNameFeminine = true;
                        EnglishCurrencyName = "Syrian Pound";
                        EnglishPluralCurrencyName = "Syrian Pounds";
                        EnglishCurrencyPartName = "Piaster";
                        EnglishPluralCurrencyPartName = "Piasteres";
                        Arabic1CurrencyName = "ليرة سورية";
                        Arabic2CurrencyName = "ليرتان سوريتان";
                        Arabic310CurrencyName = "ليرات سورية";
                        Arabic1199CurrencyName = "ليرة سورية";
                        Arabic1CurrencyPartName = "قرش";
                        Arabic2CurrencyPartName = "قرشان";
                        Arabic310CurrencyPartName = "قروش";
                        Arabic1199CurrencyPartName = "قرشاً";
                        PartPrecision = 2;
                        IsCurrencyPartNameFeminine = false;
                        break;

                    case Currency.UAE:
                        CurrencyID = 1;
                        CurrencyCode = "AED";
                        IsCurrencyNameFeminine = false;
                        EnglishCurrencyName = "UAE Dirham";
                        EnglishPluralCurrencyName = "UAE Dirhams";
                        EnglishCurrencyPartName = "Fils";
                        EnglishPluralCurrencyPartName = "Fils";
                        Arabic1CurrencyName = "درهم إماراتي";
                        Arabic2CurrencyName = "درهمان إماراتيان";
                        Arabic310CurrencyName = "دراهم إماراتية";
                        Arabic1199CurrencyName = "درهماً إماراتياً";
                        Arabic1CurrencyPartName = "فلس";
                        Arabic2CurrencyPartName = "فلسان";
                        Arabic310CurrencyPartName = "فلوس";
                        Arabic1199CurrencyPartName = "فلساً";
                        PartPrecision = 2;
                        IsCurrencyPartNameFeminine = false;
                        break;

                    case Currency.SaudiArabia:
                        CurrencyID = 2;
                        CurrencyCode = "SAR";
                        IsCurrencyNameFeminine = false;
                        EnglishCurrencyName = "Saudi Riyal";
                        EnglishPluralCurrencyName = "Saudi Riyals";
                        EnglishCurrencyPartName = "Halala";
                        EnglishPluralCurrencyPartName = "Halalas";
                        Arabic1CurrencyName = "ريال سعودي";
                        Arabic2CurrencyName = "ريالان سعوديان";
                        Arabic310CurrencyName = "ريالات سعودية";
                        Arabic1199CurrencyName = "ريالاً سعودياً";
                        Arabic1CurrencyPartName = "هللة";
                        Arabic2CurrencyPartName = "هللتان";
                        Arabic310CurrencyPartName = "هللات";
                        Arabic1199CurrencyPartName = "هللة";
                        PartPrecision = 2;
                        IsCurrencyPartNameFeminine = true;
                        break;

                    case Currency.Tunisia:
                        CurrencyID = 3;
                        CurrencyCode = "TND";
                        IsCurrencyNameFeminine = false;
                        EnglishCurrencyName = "Tunisian Dinar";
                        EnglishPluralCurrencyName = "Tunisian Dinars";
                        EnglishCurrencyPartName = "milim";
                        EnglishPluralCurrencyPartName = "millimes";
                        Arabic1CurrencyName = "دينار تونسي";
                        Arabic2CurrencyName = "ديناران تونسيان";
                        Arabic310CurrencyName = "دنانير تونسية";
                        Arabic1199CurrencyName = "ديناراً تونسياً";
                        Arabic1CurrencyPartName = "مليم";
                        Arabic2CurrencyPartName = "مليمان";
                        Arabic310CurrencyPartName = "ملاليم";
                        Arabic1199CurrencyPartName = "مليماً";
                        PartPrecision = 3;
                        IsCurrencyPartNameFeminine = false;
                        break;

                    case Currency.Gold:
                        CurrencyID = 4;
                        CurrencyCode = "XAU";
                        IsCurrencyNameFeminine = false;
                        EnglishCurrencyName = "Gram";
                        EnglishPluralCurrencyName = "Grams";
                        EnglishCurrencyPartName = "Milligram";
                        EnglishPluralCurrencyPartName = "Milligrams";
                        Arabic1CurrencyName = "جرام";
                        Arabic2CurrencyName = "جرامان";
                        Arabic310CurrencyName = "جرامات";
                        Arabic1199CurrencyName = "جراماً";
                        Arabic1CurrencyPartName = "ملجرام";
                        Arabic2CurrencyPartName = "ملجرامان";
                        Arabic310CurrencyPartName = "ملجرامات";
                        Arabic1199CurrencyPartName = "ملجراماً";
                        PartPrecision = 2;
                        IsCurrencyPartNameFeminine = false;
                        break;

                }
            }

            #endregion

            #region Properties

            /// <summary>
            /// Currency ID
            /// </summary>
            public int CurrencyID { get; set; }

            /// <summary>
            /// Standard Code
            /// Syrian Pound: SYP
            /// UAE Dirham: AED
            /// </summary>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// Is the currency name feminine ( Mua'anath مؤنث)
            /// ليرة سورية : مؤنث = true
            /// درهم : مذكر = false
            /// </summary>
            public Boolean IsCurrencyNameFeminine { get; set; }

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
            /// Arabic Currency Name for 1 unit only
            /// ليرة سورية
            /// درهم إماراتي
            /// </summary>
            public string Arabic1CurrencyName { get; set; }

            /// <summary>
            /// Arabic Currency Name for 2 units only
            /// ليرتان سوريتان
            /// درهمان إماراتيان
            /// </summary>
            public string Arabic2CurrencyName { get; set; }

            /// <summary>
            /// Arabic Currency Name for 3 to 10 units
            /// خمس ليرات سورية
            /// خمسة دراهم إماراتية
            /// </summary>
            public string Arabic310CurrencyName { get; set; }

            /// <summary>
            /// Arabic Currency Name for 11 to 99 units
            /// خمس و سبعون ليرةً سوريةً
            /// خمسة و سبعون درهماً إماراتياً
            /// </summary>
            public string Arabic1199CurrencyName { get; set; }

            /// <summary>
            /// Decimal Part Precision
            /// for Syrian Pounds: 2 ( 1 SP = 100 parts)
            /// for Tunisian Dinars: 3 ( 1 TND = 1000 parts)
            /// </summary>
            public Byte PartPrecision { get; set; }

            /// <summary>
            /// Is the currency part name feminine ( Mua'anath مؤنث)
            /// هللة : مؤنث = true
            /// قرش : مذكر = false
            /// </summary>
            public Boolean IsCurrencyPartNameFeminine { get; set; }

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

            /// <summary>
            /// Arabic Currency Part Name for 1 unit only
            /// قرش
            /// هللة
            /// </summary>
            public string Arabic1CurrencyPartName { get; set; }

            /// <summary>
            /// Arabic Currency Part Name for 2 unit only
            /// قرشان
            /// هللتان
            /// </summary>
            public string Arabic2CurrencyPartName { get; set; }

            /// <summary>
            /// Arabic Currency Part Name for 3 to 10 units
            /// قروش
            /// هللات
            /// </summary>
            public string Arabic310CurrencyPartName { get; set; }

            /// <summary>
            /// Arabic Currency Part Name for 11 to 99 units
            /// قرشاً
            /// هللةً
            /// </summary>
            public string Arabic1199CurrencyPartName { get; set; }
            #endregion
        }

        #endregion

        #region Initial

        public MainTest_InterfaceCtrl()
        {
            pre_initial();
        }

        void pre_initial()
        {
            pre_initail_CurrencyCtrl();
            pre_initial_ConvertorsCtrl();
            
            pre_initial_EnglishCtrl();
            pre_initial_ArabicCtrl();

        }
        #endregion

        #region Currencies

        Currency[] _Currencies = new Currency[] {
            Currency.General,
            Currency.Yemen,
            Currency.Syria,
            Currency.UAE,
            Currency.SaudiArabia,
            Currency.Tunisia,
            Currency.Gold};
        public Currency[] Currencies => _Currencies;

        Currency _SelectedCurrency;
        public Currency SelectedCurrency
        {
            get => _SelectedCurrency;
            set
            {
                _SelectedCurrency = value;
                //OnPropertyChanged(nameof(SelectedCurrency));
                //OnNumberChanged();
                NotifyAllPropertiesChanged();
            }
        }

        void pre_initail_CurrencyCtrl()
        {

        }

        #endregion

        #region ConvertorsCtrl

        Dictionary<Currency, IConvertorToWordCore> EnglishConvertors_dic;
        Dictionary<Currency, IConvertorToWordCore> ArabicConvertors_dic;
        void pre_initial_ConvertorsCtrl()
        {
            EnglishConvertors_dic = new Dictionary<Currency, IConvertorToWordCore>();
            foreach (var currency in Currencies)
            {
                var currencyInfo = new CurrencyInfo(currency);
                EnglishConvertors_dic.Add(currency, ConvertorManager.GetConvertorEnglish(
                    currencyInfo.CurrencyID.ToString(),
                    currencyInfo.EnglishCurrencyName,
                    currencyInfo.CurrencyCode,

                    currencyInfo.EnglishCurrencyName,
                    currencyInfo.EnglishPluralCurrencyName,
                    currencyInfo.EnglishCurrencyPartName,
                    currencyInfo.EnglishPluralCurrencyPartName,

                    currencyInfo.PartPrecision));
            }

            ArabicConvertors_dic = new Dictionary<Currency, IConvertorToWordCore>();
            foreach (var currency in Currencies)
            {
                var currencyInfo = new CurrencyInfo(currency);
                ArabicConvertors_dic.Add(currency, ConvertorManager.GetConvertorArabic(
                    currencyInfo.CurrencyID.ToString(),
                    currencyInfo.EnglishCurrencyName,
                    currencyInfo.CurrencyCode,

                    currencyInfo.IsCurrencyNameFeminine,
                    currencyInfo.Arabic1CurrencyName,
                    currencyInfo.Arabic2CurrencyName,
                    currencyInfo.Arabic310CurrencyName,
                    currencyInfo.Arabic1199CurrencyName,
                    currencyInfo.IsCurrencyPartNameFeminine,
                    currencyInfo.Arabic1CurrencyPartName,
                    currencyInfo.Arabic2CurrencyPartName,
                    currencyInfo.Arabic310CurrencyPartName,
                    currencyInfo.Arabic1199CurrencyPartName,

                    currencyInfo.PartPrecision));
            }

        }

        #endregion

        #region NumberCtrl
        string _Number;
        public string Number
        {
            get => _Number;
            set
            {
                _Number = value;
                //OnNumberChanged();
                //OnPropertyChanged(nameof(Number));
                NotifyAllPropertiesChanged();
            }
        }

        //void OnNumberChanged()
        //{
        //    //English
        //    try
        //    {
        //        EnglishConvertedResult = EnglishConvertors_dic[SelectedCurrency].ConvertToWord(Convert.ToDecimal(Number));
        //    }
        //    catch (Exception ex)
        //    {
        //        EnglishConvertedResult = ex.Message;
        //    }

        //    NotifyAllPropertiesChanged();
        //}

        #endregion

        #region EnglishCtrl

        public string EnglishPrefix
        {
            get => ConvertorSettings_English.EnglishPrefixText;
            set
            {
                ConvertorSettings_English.SetEnglishPrefixText(value);
                //OnPropertyChanged(nameof(EnglishPrefix));
                NotifyAllPropertiesChanged();
            }
        }
        public string EnglishSuffix
        {
            get => ConvertorSettings_English.EnglishSuffixText;
            set
            {
                ConvertorSettings_English.SetEnglishSuffixText(value);
                //OnPropertyChanged(nameof(EnglishSuffix));
                NotifyAllPropertiesChanged();
            }
        }

        //
        string _EnglishConvertedResult;
        public string EnglishConvertedResult
        {
            get
            {
                //English
                try
                {
                    _EnglishConvertedResult = EnglishConvertors_dic[SelectedCurrency].ConvertToWord(Convert.ToDecimal(Number));
                }
                catch (Exception ex)
                {
                    _EnglishConvertedResult = ex.Message;
                }
                return _EnglishConvertedResult;
            }
            private set
            {
                _EnglishConvertedResult = value;
                //OnPropertyChanged(nameof(EnglishConvertedResult));
                //NotifyAllPropertiesChanged();
            }
        }

        void pre_initial_EnglishCtrl()
        {

        }

        #endregion

        #region ArabicCtrl

        public string ArabicPrefix
        {
            get => ConvertorSettings_Arabic.ArabicPrefixText;
            set
            {
                ConvertorSettings_Arabic.SetArabicPrefixText(value);
                //OnPropertyChanged(nameof(ArabicPrefix));
                NotifyAllPropertiesChanged();
            }
        }
        public string ArabicSuffix
        {
            get => ConvertorSettings_Arabic.ArabicSuffixText;
            set
            {
                ConvertorSettings_Arabic.SetArabicSuffixText(value);
                //OnPropertyChanged(nameof(ArabicSuffix));
                NotifyAllPropertiesChanged();
            }
        }

        //
        string _ArabicConvertedResult;
        public string ArabicConvertedResult
        {
            get
            {
                //Arabic
                try
                {
                    _ArabicConvertedResult = ArabicConvertors_dic[SelectedCurrency].ConvertToWord(Convert.ToDecimal(Number));
                }
                catch (Exception ex)
                {
                    _ArabicConvertedResult = ex.Message;
                }
                return _ArabicConvertedResult;
            }
            private set
            {
                _ArabicConvertedResult = value;
                //OnPropertyChanged(nameof(ArabicConvertedResult));
                //NotifyAllPropertiesChanged();
            }
        }

        void pre_initial_ArabicCtrl()
        {

        }

        #endregion

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void NotifyAllPropertiesChanged()
        {
            //CurrenciesCtrl
            //OnPropertyChanged(nameof(Currencies));

            //Number
            OnPropertyChanged(nameof(Number));

            //EnglishCtrl
            OnPropertyChanged(nameof(EnglishPrefix));
            OnPropertyChanged(nameof(EnglishSuffix));
            OnPropertyChanged(nameof(EnglishConvertedResult));

            //ArabicCtrl
            OnPropertyChanged(nameof(ArabicPrefix));
            OnPropertyChanged(nameof(ArabicSuffix));
            OnPropertyChanged(nameof(ArabicConvertedResult));
        }
        #endregion
    }
}
