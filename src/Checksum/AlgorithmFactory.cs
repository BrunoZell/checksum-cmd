using System;
using System.Security.Cryptography;

namespace Checksum
{
    internal static class AlgorithmFactory
    {
        public static HashAlgorithm ResolveAlgorithm(Algorithms algorithm)
        {
            switch (algorithm) {
                case Algorithms.SHA1:
                    return SHA1.Create();
                case Algorithms.SHA256:
                    return SHA256.Create();
                case Algorithms.SHA384:
                    return SHA384.Create();
                case Algorithms.SHA512:
                    return SHA512.Create();
                case Algorithms.MD5:
                    return MD5.Create();
                default:
                    throw new NotSupportedException("The specified hash algorithm is not supported.");
            }
        }
    }
}
