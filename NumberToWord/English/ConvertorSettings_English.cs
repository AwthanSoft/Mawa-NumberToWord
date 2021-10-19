﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWord.English
{
    public static class ConvertorSettings_English
    {
        //
        static String _EnglishPrefixText = string.Empty;
        /// <summary>
        /// English text to be placed before the generated text
        /// </summary>
        public static String EnglishPrefixText => _EnglishPrefixText;

        //
        //static String _EnglishSuffixText = string.Empty;
        static String _EnglishSuffixText = "only";
        /// <summary>
        /// English text to be placed after the generated text
        /// </summary>
        public static String EnglishSuffixText => _EnglishSuffixText;


    }
}