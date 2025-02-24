using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsUtil
    {
        public enum enCharType
        {
            SmallLetter = 1,
            CapitalLetter = 2,
            Digit = 3,
            MixChars = 4,
            SpecialCharacter = 5
        }

        private static readonly Random _random = new Random();

        public static int RandomNumber(int from, int to)
        {
            return _random.Next(from, to + 1);
        }

        public static char GetRandomCharacter(enCharType charType)
        {
            if (charType == enCharType.MixChars)
            {
                charType = (enCharType)RandomNumber(1, 3);
            }

            return charType switch
            {
                enCharType.SmallLetter => (char)RandomNumber(97, 122),
                enCharType.CapitalLetter => (char)RandomNumber(65, 90),
                enCharType.SpecialCharacter => (char)RandomNumber(33, 47),
                enCharType.Digit => (char)RandomNumber(48, 57),
                _ => (char)RandomNumber(65, 90)
            };
        }

        public static string GenerateWord(enCharType charType, short length)
        {
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                word.Append(GetRandomCharacter(charType));
            }
            return word.ToString();
        }

        public static string GenerateKey(enCharType charType = enCharType.CapitalLetter)
        {
            return $"{GenerateWord(charType, 4)}-{GenerateWord(charType, 4)}-" +
                   $"{GenerateWord(charType, 4)}-{GenerateWord(charType, 4)}";
        }

        public static void GenerateKeys(short numberOfKeys, enCharType charType)
        {
            for (int i = 1; i <= numberOfKeys; i++)
            {
                Console.WriteLine($"Key [{i}] : {GenerateKey(charType)}");
            }
        }

        public static void FillArrayWithRandomNumbers(int[] arr, int from, int to)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = RandomNumber(from, to);
            }
        }

        public static void FillArrayWithRandomWords(string[] arr, enCharType charType, short wordLength)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = GenerateWord(charType, wordLength);
            }
        }

        public static void FillArrayWithRandomKeys(string[] arr, enCharType charType)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = GenerateKey(charType);
            }
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }

        public static void ShuffleArray<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Swap(ref arr[RandomNumber(0, arr.Length - 1)], ref arr[RandomNumber(0, arr.Length - 1)]);
            }
        }

        public static string Tabs(short numberOfTabs)
        {
            return new string('\t', numberOfTabs);
        }

        public static string NumberToText(int number)
        {
            if (number == 0) return "Zero";

            string[] units = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
                           "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                           "Seventeen", "Eighteen", "Nineteen" };

            string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                return units[number];

            if (number < 100)
                return tens[number / 10] + (number % 10 > 0 ? " " + units[number % 10] : "");

            if (number < 1000)
                return units[number / 100] + " Hundred " + (number % 100 > 0 ? NumberToText(number % 100) : "");

            if (number < 1000000)
                return NumberToText(number / 1000) + " Thousand " + (number % 1000 > 0 ? NumberToText(number % 1000) : "");

            if (number < 1000000000)
                return NumberToText(number / 1000000) + " Million " + (number % 1000000 > 0 ? NumberToText(number % 1000000) : "");

            return NumberToText(number / 1000000000) + " Billion " + (number % 1000000000 > 0 ? NumberToText(number % 1000000000) : "");
        }


        public static string EncryptText(string Text, short EncryptionKey = 2)
        {
            char[] textArray = Text.ToCharArray(); // Convert string to mutable array
            for (int i = 0; i < Text.Length; i++)
            {

                textArray[i] = Convert.ToChar( (int)Text[i] + EncryptionKey);

            }
            Text = new string(textArray); // Convert back to string
            return Text;

        }

        public static string DecryptText(string Text, short EncryptionKey = 2)
        {
            char[] textArray = Text.ToCharArray(); // Convert string to mutable array

            for (int i = 0; i < Text.Length; i++)
            {

                textArray[i] = Convert.ToChar( (int)Text[i] - EncryptionKey);

            }
            Text = new string(textArray); // Convert back to string
            return Text;
           

        }





    }


}
