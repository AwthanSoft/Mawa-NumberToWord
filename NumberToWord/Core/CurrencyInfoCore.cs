using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWord
{
    public abstract class CurrencyInfoCore
    {
        //Language Info
        readonly Language _language;
        public Language language => _language;


        //base currency info

        /// <summary>
        /// Currency ID
        /// </summary>
        public string CurrencyId { private set; get; }
        /// <summary>
        /// Standard Code
        /// Syrian Pound: SYP
        /// UAE Dirham: AED
        /// </summary>
        public string CurrencyCode { private set; get; }
        /// <summary>
        /// Default currency name or national
        /// </summary>
        public string CurrencyName { private set; get; }


        public CurrencyInfoCore(
            Language language,
            string CurrencyId,
            string CurrencyName,
            string CurrencyCode
            )
        {
            this._language = language;

            this.CurrencyId = CurrencyId;
            this.CurrencyName = CurrencyName;
            this.CurrencyCode = CurrencyCode;
        }

    }
}
