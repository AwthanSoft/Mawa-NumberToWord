using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWord
{
    public interface IConvertorToWordCore
    {
        Language language { get; }
        CurrencyInfoCore CurrencyInfo { get; }
        /// <summary>
        /// Convert number to words using selected currency
        /// </summary>
        /// <param name="Number">Number to be converted</param>
        /// <returns></returns>
        string ConvertToWord(Decimal Number);
    }
}
