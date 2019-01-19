using System;

namespace Checksum.Exceptions
{
    internal class AlgorithmNotSupportedException : Exception
    {
        public AlgorithmNotSupportedException(string algorithmName) :
            base($"The specified hash algorithm {algorithmName} is not supported.") =>
            AlgorithmName = algorithmName;

        public string AlgorithmName { get; }
    }
}
