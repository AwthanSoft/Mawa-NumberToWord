using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToWord.Helpers
{
    static class ArabicHelper
    {
        #region Varaibles

        private static string[] arabicOnes =
           new string[] {
            String.Empty, "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة",
            "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر"
        };

        private static string[] arabicFeminineOnes =
           new string[] {
            String.Empty, "إحدى", "اثنتان", "ثلاث", "أربع", "خمس", "ست", "سبع", "ثمان", "تسع",
            "عشر", "إحدى عشرة", "اثنتا عشرة", "ثلاث عشرة", "أربع عشرة", "خمس عشرة", "ست عشرة", "سبع عشرة", "ثماني عشرة", "تسع عشرة"
        };

        private static string[] arabicTens =
            new string[] {
            "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون"
        };

        private static string[] arabicHundreds =
            new string[] {
            "", "مائة", "مئتان", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة","تسعمائة"
        };

        private static string[] arabicAppendedTwos =
            new string[] {
            "مئتا", "ألفا", "مليونا", "مليارا", "تريليونا", "كوادريليونا", "كوينتليونا", "سكستيليونا"
        };

        private static string[] arabicTwos =
            new string[] {
            "مئتان", "ألفان", "مليونان", "ملياران", "تريليونان", "كوادريليونان", "كوينتليونان", "سكستيليونان"
        };

        private static string[] arabicGroup =
            new string[] {
            "مائة", "ألف", "مليون", "مليار", "تريليون", "كوادريليون", "كوينتليون", "سكستيليون"
        };

        private static string[] arabicAppendedGroup =
            new string[] {
            "", "ألفاً", "مليوناً", "ملياراً", "تريليوناً", "كوادريليوناً", "كوينتليوناً", "سكستيليوناً"
        };

        private static string[] arabicPluralGroups =
            new string[] {
            "", "آلاف", "ملايين", "مليارات", "تريليونات", "كوادريليونات", "كوينتليونات", "سكستيليونات"
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
            string PrefixText,
            string SuffixText)
        {
            CoreHelper.ExtractIntegerAndDecimalParts(Number, PartPrecision, out long intergerValue, out int decimalValue);

            var NumStr = ConvertToArabic_Point(Number, intergerValue, decimalValue, PointStr);

            String formattedNumber = String.Empty;
            formattedNumber += (PrefixText != String.Empty) ? String.Format("{0} ", PrefixText) : String.Empty;
            formattedNumber += NumStr;
            formattedNumber += (SuffixText != String.Empty) ? String.Format(" {0}", SuffixText) : String.Empty;

            return formattedNumber;
        }

        
        /// <summary>
        /// Process a group of 3 digits
        /// </summary>
        /// <param name="groupNumber">The group number to process</param>
        /// <returns></returns>
        private static string ProcessArabicGroup(int groupNumber, int groupLevel, Decimal remainingNumber, long intergerValue)
        {
            int tens = groupNumber % 100;

            int hundreds = groupNumber / 100;

            string retVal = String.Empty;

            if (hundreds > 0)
            {
                if (tens == 0 && hundreds == 2) // حالة المضاف
                    retVal = String.Format("{0}", arabicAppendedTwos[0]);
                else //  الحالة العادية
                    retVal = String.Format("{0}", arabicHundreds[hundreds]);
            }

            if (tens > 0)
            {
                if (tens < 20)
                { // if we are processing under 20 numbers
                    if (tens == 2 && hundreds == 0 && groupLevel > 0)
                    { // This is special case for number 2 when it comes alone in the group
                        if (intergerValue == 2000 || intergerValue == 2000000 || intergerValue == 2000000000 || intergerValue == 2000000000000 || intergerValue == 2000000000000000 || intergerValue == 2000000000000000000)
                            retVal = String.Format("{0}", arabicAppendedTwos[groupLevel]); // في حالة الاضافة
                        else
                            retVal = String.Format("{0}", arabicTwos[groupLevel]);//  في حالة الافراد
                    }
                    else
                    { // General case
                        if (retVal != String.Empty)
                            retVal += " و ";

                        if (tens == 1 && groupLevel > 0 && hundreds == 0)
                            retVal += " ";
                        else
                            if ((tens == 1 || tens == 2) && (groupLevel == 0 || groupLevel == -1) && hundreds == 0 && remainingNumber == 0)
                            retVal += String.Empty; // Special case for 1 and 2 numbers like: ليرة سورية و ليرتان سوريتان
                        else
                            //retVal += GetDigitFeminineStatus(tens, groupLevel);// Get Feminine status for this digit
                            retVal += arabicOnes[tens];
                    }
                }
                else
                {
                    int ones = tens % 10;
                    tens = (tens / 10) - 2; // 20's offset

                    if (ones > 0)
                    {
                        if (retVal != String.Empty)
                            retVal += " و ";

                        // Get Feminine status for this digit
                        //retVal += GetDigitFeminineStatus(ones, groupLevel);
                        retVal += arabicOnes[ones];
                    }

                    if (retVal != String.Empty)
                        retVal += " و ";

                    // Get Tens text
                    retVal += arabicTens[tens];
                }
            }

            return retVal;
        }

        /// <summary>
        /// Convert stored number to words using selected currency
        /// </summary>
        /// <returns></returns>
        private static string ConvertToArabic_Point(Decimal Number, long intergerValue, int decimalValue, string PointStr)
        {
            Decimal tempNumber = Number;

            if (tempNumber == 0)
                return "صفر";

            // Get Text for the decimal part
            string decimalString = ProcessArabicGroup(decimalValue, -1, 0, intergerValue);

            string retVal = String.Empty;
            Byte group = 0;

            if (tempNumber < 1)
            {
                //retVal = arabicOnes[0];
                retVal = "صفر";
            }
            else
            {
                while (tempNumber >= 1)
                {
                    // seperate number into groups
                    int numberToProcess = (int)(tempNumber % 1000);

                    tempNumber = tempNumber / 1000;

                    // convert group into its text
                    string groupDescription = ProcessArabicGroup(numberToProcess, group, Math.Floor(tempNumber), intergerValue);

                    if (groupDescription != String.Empty)
                    { // here we add the new converted group to the previous concatenated text
                        if (group > 0)
                        {
                            if (retVal != String.Empty)
                                retVal = String.Format("{0} {1}", "و", retVal);

                            if (numberToProcess != 2)
                            {
                                if (numberToProcess % 100 != 1)
                                {
                                    if (numberToProcess >= 3 && numberToProcess <= 10) // for numbers between 3 and 9 we use plural name
                                        retVal = String.Format("{0} {1}", arabicPluralGroups[group], retVal);
                                    else
                                    {
                                        if (retVal != String.Empty) // use appending case
                                            retVal = String.Format("{0} {1}", arabicAppendedGroup[group], retVal);
                                        else
                                            retVal = String.Format("{0} {1}", arabicGroup[group], retVal); // use normal case
                                    }
                                }
                                else
                                {
                                    retVal = String.Format("{0} {1}", arabicGroup[group], retVal); // use normal case
                                }
                            }
                        }

                        retVal = String.Format("{0} {1}", groupDescription, retVal);
                    }

                    group++;
                }
            }

            String formattedNumber = String.Empty;
            formattedNumber += (retVal != String.Empty) ? retVal : String.Empty;
            if (intergerValue != 0)
            { // here we add currency name depending on _intergerValue : 1 ,2 , 3--->10 , 11--->99
                int remaining100 = (int)(intergerValue % 100);

                if (remaining100 == 0 || remaining100 == 1 || remaining100 == 2)
                    formattedNumber += arabicOnes[remaining100];
            }
            formattedNumber += (decimalValue != 0) ? string.Format(" {0} ", PointStr) : String.Empty;
            formattedNumber += (decimalValue != 0) ? decimalString : String.Empty;

            return formattedNumber.Replace("  "," ");
        }

        #endregion

    }
}
