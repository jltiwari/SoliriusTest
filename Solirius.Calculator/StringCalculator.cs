using System;
using System.Linq;
using Solirius.Calculator.Exceptions;

namespace Solirius.Calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int result = 0;
            char newLineChar = '\n';
            int maxNumberToAdd = 1000;
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return result;
            }

            char[] separators;
            string[] numbersString;
            if (numbers.StartsWith("//"))
            {
                var customSeparators = numbers.Substring(2).Split(newLineChar)[0];
                separators = customSeparators.ToCharArray();
                numbersString = numbers.Substring(numbers.IndexOf(newLineChar) + 1).Split(separators);
            }
            else
            {
                separators = new char[] { ',', newLineChar };
                numbersString = numbers.Split(separators);
            }

            int[] numbersInt;
            try
            {
                numbersInt = Array.ConvertAll(numbersString, i => int.Parse(i));
            }
            catch(Exception)
            {
                throw new InvalidOperationException();
            }

            if(numbersInt.Any(i => i < 0))
            {
                var negativeNumbers = numbersInt.Where(i => i < 0);
                throw new NegativesNotAllowedException($"Negatives not allowed. {string.Join(",", negativeNumbers)}");
            }

            return numbersInt.Where(i => i <= maxNumberToAdd).Sum();
        }
    }
}
