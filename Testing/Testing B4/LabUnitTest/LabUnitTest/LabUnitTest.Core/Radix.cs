using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabUnitTest.Core
{
    public class Radix
    {
        private readonly int _number;

        public Radix(int number)
        {
            if (number < 0)
                throw new ArgumentException("Number must be non-negative.", nameof(number));
            _number = number;
        }

        public string ConvertDecimalToAnother(int radix)
        {
            if (radix < 2 || radix > 36)
                throw new ArgumentException("Radix must be between 2 and 36.", nameof(radix));
            return Convert.ToString(_number, radix).ToUpperInvariant();
        }
    }
}
