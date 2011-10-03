using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class Calculator
    {
        List<char> _splitBy = new List<char>() { ',', '\n' };
        public int Add(string input)
        {
            if (input.Equals(string.Empty)) return 0;

            if (input.ToCharArray().Any(x => x == ',' || x == '\n') || isCustomDelimited(input) )
                return InputToIntArray(input).Sum();

            return int.Parse(input);

        }

        private bool isCustomDelimited(string input)
        {
            return input.StartsWith("//");
        }

        public int[] InputToIntArray(string input)
        {
            input = handleCustomDelimited(input);
            var segments = input.Split(_splitBy.ToArray());
            if (isInvalidSegment(segments))
                throw new ArgumentException();
            var parsedSegments = segments.Select(x => int.Parse(x)).ToArray();
            if(isNegativeValue(parsedSegments))
                throw new ArgumentException();

            return parsedSegments;

        }

        private string handleCustomDelimited(string input)
        {
            if (isCustomDelimited(input))
            {
                _splitBy.Add(input[2]);
                input = input.Substring(3);
            }
            return input;
        }

        private bool isNegativeValue(int[] parsedSegments)
        {
            return parsedSegments.Any(x => x < 0);
        }

        private bool isInvalidSegment(string[] segments)
        {
            return segments.Any(x => x == string.Empty);
        }
    }
}
