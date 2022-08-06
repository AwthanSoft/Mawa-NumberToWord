using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWord.Arabic
{
    public static class ConvertorSettings_Arabic
    {
        //
        //static String _ArabicPrefixText = string.Empty;
        //static String _ArabicPrefixText = "فقط";
        static String _ArabicPrefixText = "#";
        /// <summary>
        /// Arabic text to be placed before the generated text
        /// </summary>
        public static String ArabicPrefixText => _ArabicPrefixText;
        public static void SetArabicPrefixText(string text)
        {
            _ArabicPrefixText = text;
        }


        //
        //static String _ArabicSuffixText = string.Empty;
        //static String _ArabicSuffixText = "لا غير.";
        static String _ArabicSuffixText = "#";
        /// <summary>
        /// Arabic text to be placed after the generated text
        /// </summary>
        public static String ArabicSuffixText => _ArabicSuffixText;
        public static void SetArabicSuffixText(string text)
        {
            _ArabicSuffixText = text;
        }



    }
}
