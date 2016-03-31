using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumCur2Words
{
    public class NumCur2Words
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a numerical currency: ");
            string currencyString = Console.ReadLine();

            while (string.IsNullOrEmpty(currencyString))
            {
                Console.WriteLine("Please enter a numerical currency: ");
                currencyString = Console.ReadLine();
            }

            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
            double d = 0;
            while (!double.TryParse(currencyString.Replace(ci.NumberFormat.CurrencySymbol, ""), out d))
            {
                Console.WriteLine("Please enter a valid numerical currency: ");
                currencyString = Console.ReadLine();
            }

            Console.WriteLine(NumberToCurrencyText(d));
            Console.ReadLine();

        }

        public static string NumericalCurrencyToWords(string numericalCurrency)
        {
            double d = 0;

            if (string.IsNullOrEmpty(numericalCurrency)) {
                throw new Exception("Please enter a numerical currency: ");
            }

            CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
            if (!double.TryParse(numericalCurrency.Replace(ci.NumberFormat.CurrencySymbol, ""), out d))
            {
                throw new Exception("Please enter a valid numerical currency: ");
            }
            return NumberToCurrencyText(d);
        }

        private static string NumberToCurrencyText(double number)
        {
            string wordNumber = string.Empty;

            string[] arrNumber = number.ToString().Split('.');

            long wholePart = long.Parse(arrNumber[0]);
            string strWholePart = NumberToText(wholePart);

            wordNumber = strWholePart + (wholePart == 1 ? " Dollar" : " Dollars");

            if (arrNumber.Length > 1)
            {
                long fractionPart = long.Parse((arrNumber[1].Length == 1 ? arrNumber[1] + "0" : arrNumber[1]));
                string strFarctionPart = NumberToText(fractionPart);

                wordNumber += " and " +  (fractionPart == 0 ? " No" : strFarctionPart) + (fractionPart == 1 ? " Cent" : " Cents");
            }

            return wordNumber;
        }

        private static string NumberToText(long number)
        {
            string words = string.Empty;
            StringBuilder wordNumber = new StringBuilder();

            string[] powers = new string[] { "Thousand ", "Million ", "Billion " };
            string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] ones = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", 
                                           "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

            if (number == 0) { return "Zero"; }
            if (number < 0)
            {
                wordNumber.Append("Negative ");
                number = -number;
            }

            long[] groupedNumber = new long[] { 0, 0, 0, 0 };
            int groupIndex = 0;

            while (number > 0)
            {
                groupedNumber[groupIndex++] = number % 1000;
                number /= 1000;
            }

            for (int i = 3; i >= 0; i--)
            {
                long group = groupedNumber[i];

                if (group >= 100)
                {
                    wordNumber.Append(ones[group / 100 - 1] + " Hundred ");
                    group %= 100;

                    if (group == 0 && i > 0)
                        wordNumber.Append(powers[i - 1]);

                    wordNumber.Append("and ");
                }

                if (group >= 20)
                {
                    if ((group % 10) != 0)
                        wordNumber.Append(tens[group / 10 - 2] + " " + ones[group % 10 - 1] + " ");
                    else
                        wordNumber.Append(tens[group / 10 - 2] + " ");
                }
                else if (group > 0)
                    wordNumber.Append(ones[group - 1] + " ");

                if (group != 0 && i > 0)
                    wordNumber.Append(powers[i - 1] + (!string.IsNullOrEmpty(wordNumber.ToString()) ? "and " : ""));
            }

            if (wordNumber.ToString().EndsWith("and "))
            {
                words = wordNumber.ToString().Trim().TrimEnd('d').TrimEnd('n').TrimEnd('a').Trim();
            }
            else
            {
                words = wordNumber.ToString().Trim();
            }

            return words;
        }

    }
}
