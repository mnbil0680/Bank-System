using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class clsString
    {
        private string _Value;


        // constructor
        public clsString()
        {
            _Value = "";
        }
        public clsString(string Value)
        {
            _Value = Value;
        }

        // // getters and setters properties
        public string Value
        {
            get => _Value;
            set => _Value = value;
        }


        //methods
        public static int Length(string S1)
        {
            return S1.Length;
        }

        public int Length()
        {
            return _Value.Length;
        }

        public static int CountWords(string S1)
        {

            string delim = " "; 
            short Counter = 0;
            int pos = 0;
            string sWord; 
           
            
            while ((pos = S1.IndexOf(delim)) !=-1)
        {
                sWord = S1.Substring(0, pos);  
                if (sWord != "")
                {
                    Counter++;
                }

                
                S1 = S1.Substring(pos + delim.Length);
            }

            if (!string.IsNullOrEmpty(S1))
            {
                Counter++; // it counts the last word of the string.
            }

            return Counter;

        }

        public int CountWords()
        {
            return CountWords(_Value);
        }

        public static string UpperFirstLetterOfEachWord(string S1)
        {
            bool isFirstLetter = true;
            char[] charArray = S1.ToCharArray(); // Convert string to character array

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] != ' ' && isFirstLetter)
                {
                    charArray[i] = char.ToUpper(charArray[i]); // Capitalize first letter
                }
                isFirstLetter = (charArray[i] == ' '); // Reset flag when a space is found
            }

            return new string(charArray);
        }

        public void UpperFirstLetterOfEachWord()
        {
            _Value = UpperFirstLetterOfEachWord(_Value);
        }

        public static string LowerFirstLetterOfEachWord(string S1)
        {
            bool isFirstLetter = true;
            char[] charArray = S1.ToCharArray(); // Convert string to character array

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] != ' ' && isFirstLetter)
                {
                    charArray[i] = char.ToLower(charArray[i]); // Capitalize first letter
                }
                isFirstLetter = (charArray[i] == ' '); // Reset flag when a space is found
            }

            return new string(charArray);
        }


        public void LowerFirstLetterOfEachWord()
        {
            _Value = LowerFirstLetterOfEachWord(_Value);
        }

        public static string UpperAllString(string S1)
        {
            return S1.ToUpper(); // Directly convert entire string to uppercase
        }

        public void UpperAllString()
        {
            _Value = UpperAllString(_Value);
        }

        public static string LowerAllString(string S1)
        {
            return S1.ToLower(); // Directly convert entire string to uppercase
        }

        public void LowerAllString()
        {
            _Value = LowerAllString(_Value);
        }

        public static char InvertLetterCase(char char1)
        {
            return char.IsUpper(char1) ? char.ToLower(char1) : char.ToUpper(char1);
        }

        public static string InvertAllLettersCase(string S1)
        {
            char[] charArray = S1.ToCharArray(); // Convert string to character array

            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = InvertLetterCase(charArray[i]); // Apply case inversion
            }

            return new string(charArray); // Convert back to string
        }

        public void InvertAllLettersCase()
        {
            _Value = InvertAllLettersCase(_Value);
        }

        internal enum enWhatToCount { SmallLetters = 0, CapitalLetters = 1, All = 3 };
        public static int CountLetters(string S1, enWhatToCount WhatToCount = enWhatToCount.All)
        {
            if (WhatToCount == enWhatToCount.All)
            {
                return S1.Length;
            }

            int Counter = 0;

            foreach (char ch in S1)
            {
                if (WhatToCount == enWhatToCount.CapitalLetters && char.IsUpper(ch))
                    Counter++;

                if (WhatToCount == enWhatToCount.SmallLetters && char.IsLower(ch))
                    Counter++;
            }

            return Counter;
        }

        public static int CountCapitalLetters(string S1)
        {
            int Counter = 0;

            foreach (char ch in S1)
            {
                if (char.IsUpper(ch))
                    Counter++;
            }

            return Counter;
        }

        public int CountCapitalLetters()
        {
            return CountCapitalLetters(_Value);
        }

        public static int CountSmallLetters(string S1)
        {
            int Counter = 0;
            foreach (char ch in S1)
            {
                if (char.IsLower(ch))
                    Counter++;
            }
            return Counter;
        }

        public int CountSmallLetters()
        {
            return CountSmallLetters(_Value);
        }


        public static int CountSpecificLetter(string S1, char Letter, bool MatchCase = true)
        {
            int Counter = 0;

            foreach (char ch in S1)
            {
                if (MatchCase)
                {
                    if (ch == Letter)
                        Counter++;
                }
                else
                {
                    if (char.ToLower(ch) == char.ToLower(Letter))
                        Counter++;
                }
            }
            return Counter;
        }

        public int CountSpecificLetter(char Letter, bool MatchCase = true)
        {
            return CountSpecificLetter(_Value, Letter, MatchCase);
        }

        public static bool IsVowel(char Ch1)
        {
            Ch1 = char.ToLower(Ch1);

            return (Ch1 == 'a' || Ch1 == 'e' || Ch1 == 'i' || Ch1 == 'o' || Ch1 == 'u');
        }

        public static int CountVowels(string S1)
        {
            int Counter = 0;

            for (int i = 0; i < S1.Length; i++)
            {
                if (IsVowel(S1[i]))
                    Counter++;
            }

            return Counter;
        }

        public int CountVowels()
        {
            return CountVowels(_Value);
        }

        public static List<string> Split(string S1, string Delim)
        {
            List<string> vString = new List<string>();
            int pos = 0;

            while ((pos = S1.IndexOf(Delim, StringComparison.Ordinal)) != -1)
            {
                string sWord = S1.Substring(0, pos);
                vString.Add(sWord);
                S1 = S1.Substring(pos + Delim.Length);
            }

            if (!string.IsNullOrEmpty(S1))
            {
                vString.Add(S1);
            }
            return vString;
        }

        public List<string> Split(string Delim)
        {
            return Split(_Value, Delim);
        }

        public static string TrimLeft(string S1)
        {
            for (int i = 0; i < S1.Length; i++)
            {
                if (S1[i] != ' ')
                {
                    return S1.Substring(i);
                }
            }
            return "";
        }

        public void TrimLeft()
        {
            _Value = TrimLeft(_Value);
        }

        public static string TrimRight(string S1)
        {
            for (int i = S1.Length - 1; i >= 0; i--)
            {
                if (S1[i] != ' ')
                {
                    return S1.Substring(0, i + 1);
                }
            }
            return "";
        }

        public void TrimRight()
        {
            _Value = TrimRight(_Value);
        }

        public static string Trim(string S1)
        {
            return (TrimLeft(TrimRight(S1)));

        }

        public void Trim()
        {
            _Value = Trim(_Value);
        }

        /*



static string JoinString(vector<string> vString, string Delim)
{

    string S1 = "";

    for (string & s : vString)
        {
            S1 = S1 + s + Delim;
        }

        return S1.substr(0, S1.length() - Delim.length());


    }

    static string JoinString(string arrString[], short Length, string Delim)
{

    string S1 = "";

    for (short i = 0; i < Length; i++)
    {
        S1 = S1 + arrString[i] + Delim;
    }

    return S1.substr(0, S1.length() - Delim.length());

}

static string ReverseWordsInString(string S1)
{

    vector<string> vString;
    string S2 = "";

    vString = Split(S1, " ");

    // declare iterator
    vector<string>::iterator iter = vString.end();

    while (iter != vString.begin())
    {

        --iter;

        S2 += *iter + " ";

    }

    S2 = S2.substr(0, S2.length() - 1); //remove last space.

    return S2;
}

void ReverseWordsInString()
{
    _Value = ReverseWordsInString(_Value);
}

static string ReplaceWord(string S1, string StringToReplace, string sRepalceTo, bool MatchCase = true)
{

    vector<string> vString = Split(S1, " ");

    for (string & s : vString)
        {

            if (MatchCase)
            {
                if (s == StringToReplace)
                {
                    s = sRepalceTo;
                }

            }
            else
{
    if (LowerAllString(s) == LowerAllString(StringToReplace))
    {
        s = sRepalceTo;
    }

}

        }

        return JoinString(vString, " ");
    }

    string ReplaceWord(string StringToReplace, string sRepalceTo)
{
    return ReplaceWord(_Value, StringToReplace, sRepalceTo);
}

static string RemovePunctuations(string S1)
{

    string S2 = "";

    for (short i = 0; i < S1.length(); i++)
    {
        if (!ispunct(S1[i]))
        {
            S2 += S1[i];
        }
    }

    return S2;

}

void RemovePunctuations()
{
    _Value = RemovePunctuations(_Value);
}


};


*/
    }
}
