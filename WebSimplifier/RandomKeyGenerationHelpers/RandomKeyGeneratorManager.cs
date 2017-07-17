using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSimplifier.RandomKeyGenerationHelper
{
    public static class RandomKeyGeneratorManager
    {
        private static readonly string upperCaseString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string lowerCaseString = upperCaseString.ToLower();
        private static readonly string numericString = "0123456789";
        private static readonly string specialString = "!+%&/=?*-";

        private static Random random = new Random();
        public static string GenerateRandomKey(int length, GenerationKeyType type)
        {

            string chars = SelectStringUsingType(type);
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GenerateRandomKey(int length, string chars)
        {
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string ReplaceAt(this string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
        private static string SelectStringUsingType(GenerationKeyType type)
        {
            string returnStringValue = "";
            switch (type)
            {
                case GenerationKeyType.UpperCases: returnStringValue = upperCaseString; break;
                case GenerationKeyType.LowerCases: returnStringValue = lowerCaseString; break;
                case GenerationKeyType.SpecialWords: returnStringValue = specialString; break;
                case GenerationKeyType.Numeric: returnStringValue = numericString; break;
                case GenerationKeyType.UpperCasesAndLowerCases: returnStringValue = upperCaseString + lowerCaseString; break;
                case GenerationKeyType.UpperCasesAndSpecialWords: returnStringValue = upperCaseString + specialString; break;
                case GenerationKeyType.UpperCasesAndNumeric: returnStringValue = upperCaseString + numericString; break;
                case GenerationKeyType.LowerCasesAndSpecialWords: returnStringValue = lowerCaseString + specialString; break;
                case GenerationKeyType.LowerCasesAndNumeric: returnStringValue = lowerCaseString + numericString; break;
                case GenerationKeyType.SpecialWordsAndNumeric: returnStringValue = specialString + numericString; break;
                case GenerationKeyType.UpperCasesAndLowerCasesSpecialWords: returnStringValue = upperCaseString + lowerCaseString + specialString; break;
                case GenerationKeyType.UpperCasesAndLowerCasesNumeric: returnStringValue = upperCaseString + lowerCaseString + numericString; break;
                case GenerationKeyType.UpperCasesAndSpecialWordsAndNumeric: returnStringValue = upperCaseString + specialString + numericString; break;
                case GenerationKeyType.LowerCasesAndSpecialWordsAndNumeric: returnStringValue = lowerCaseString + specialString + numericString; break;
                case GenerationKeyType.UpperCasesAndLowerCasesSpecialWordsNumeric: returnStringValue = upperCaseString + lowerCaseString + specialString + numericString; break;

            }
            return returnStringValue;
        }


    }
}
