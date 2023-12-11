using System.Linq;
using System.Numerics;

namespace _Scripts.Extensions
{
    public static class BigIntegerExtension
    {
        private static readonly BigInteger K = BigInteger.Pow(new BigInteger(10), 3);
        private static readonly BigInteger KDot = BigInteger.Pow(new BigInteger(10), 2);
        
        private static readonly BigInteger M = BigInteger.Pow(new BigInteger(10), 6);
        private static readonly BigInteger MDot = BigInteger.Pow(new BigInteger(10), 5);
        
        private static readonly BigInteger B = BigInteger.Pow(new BigInteger(10), 9);
        private static readonly BigInteger BDot = BigInteger.Pow(new BigInteger(10), 8);
        
        private static readonly BigInteger T = BigInteger.Pow(new BigInteger(10), 12);
        private static readonly BigInteger TDot = BigInteger.Pow(new BigInteger(10), 11);
        
        private static readonly BigInteger Q = BigInteger.Pow(new BigInteger(10), 15);
        private static readonly BigInteger QDot = BigInteger.Pow(new BigInteger(10), 14);
        
        public static string ToShortString(this BigInteger value)
        {
            if (value / Q > 0)
                return $"{value / Q}Q";

            if (value / T > 0)
                return $"{value / T}T";

            if (value / B > 0)
                return $"{value / B}B";

            if (value / M > 0)
                return $"{value / M}M";

            if (value / K > 0)
                return $"{value / K}.{(value % K) / KDot}K";

            return value.ToString();
        }
    }
}