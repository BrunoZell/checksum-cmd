using System;
using System.Security.Cryptography;

namespace Checksum
{
    internal static class AlgorithmFactory
    {
        public static HashAlgorithm ResolveAlgorithm(string name)
        {
            switch (name.ToUpperInvariant()) {
                case "SHA1":
                    return SHA1.Create();
                case "SHA256":
                    return SHA256.Create();
                case "SHA384":
                    return SHA384.Create();
                case "SHA512":
                    return SHA512.Create();
                case "MD5":
                    return MD5.Create();
                default:
                    throw new NotSupportedException("The specified hash algorithm is not supported.");
            }
        }
    }
}
