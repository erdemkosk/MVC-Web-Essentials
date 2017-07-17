using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSimplifier.RandomKeyGenerationHelper
{
    public enum GenerationKeyType
    {

        //Combination of 4(1) + 4(2) + 4(3) + 4(4)
        //1//
        UpperCases = 1,
        LowerCases = 2,
        SpecialWords = 3,
        Numeric = 4,
        //2//
        UpperCasesAndLowerCases = 5,
        UpperCasesAndSpecialWords = 6,
        UpperCasesAndNumeric = 7,
        LowerCasesAndSpecialWords = 8,
        LowerCasesAndNumeric = 9,
        SpecialWordsAndNumeric = 10,
        //3//
        UpperCasesAndLowerCasesSpecialWords = 11,
        UpperCasesAndLowerCasesNumeric = 12,
        UpperCasesAndSpecialWordsAndNumeric = 13,
        LowerCasesAndSpecialWordsAndNumeric = 14,
        //4//
        UpperCasesAndLowerCasesSpecialWordsNumeric = 15


    }
}
