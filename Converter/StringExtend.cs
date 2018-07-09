using System;

namespace Converter
{
    /// <summary>
    /// Extentions of the <see cref="System.String"/>
    /// </summary>
    public static class StringExtend
    {
        /// <summary>
        /// Converts integer positive number from its string representation to <see cref="UInt32"/>.
        /// </summary>
        /// <param name="numberString">String representation of number.</param>
        /// <param name="radix">The radix of the number.</param>
        /// <returns>The result of converting.</returns>
        /// <exception cref="ArgumentException">radix</exception>
        /// <exception cref="OverflowException">Number is bigger than UInt.MaxValue.</exception>
        public static uint StringToUInt32(this string numberString, int radix)
        {
            if (numberString == "0")
            {
                return 0;
            }

            Notation notation = new Notation(radix);
            numberString = numberString.ToUpper();
            int length = numberString.Length;
            long result = 0;
            for (int i = 0; i < length; i++)
            {              
                int numberOfSymbol = notation.Symbols.IndexOf(numberString[i]);
                if (numberOfSymbol == -1)
                {
                    throw new ArgumentException(nameof(radix));
                }

                if (i == 0)
                {
                    result += numberOfSymbol;
                }
                else
                {
                    result = notation.Radix * result + numberOfSymbol;
                }

            }

            if (result > uint.MaxValue)
            {
                throw new OverflowException("Number is bigger than UInt.MaxValue.");
            }

            return (uint)result;
        }

        private struct Notation
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Notation"/> struct.
            /// </summary>
            /// <param name="radix">
            /// The radix.
            /// </param>
            /// <exception cref="ArgumentException">Radix was less than 2 or bigger than 16.</exception>
            public Notation(int radix)
            {
                if (radix < 2 || radix > 16)
                {
                    throw new ArgumentException("Radix was less than 2 or bigger than 16.", nameof(radix));
                }

                Radix = radix;
                Symbols = Alphabet.Substring(0, radix);
            }

            /// <summary>
            /// Gets the alphabet.
            /// </summary>
            /// <value>
            /// The alphabet.
            /// </value>
            private static string Alphabet { get; } = "0123456789ABCDEF";

            /// <summary>
            /// Gets radix.
            /// </summary>
            /// <value>
            /// Gets radix.
            /// </value>
            public int Radix { get; }

            /// <summary>
            /// Gets symbols of the notation.
            /// </summary>
            /// <value>
            /// Gets symbols of the notation.
            /// </value>
            public string Symbols { get; }
        }
    }    
}
