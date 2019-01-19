using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Checksum
{
    public partial class Program
    {
        public static int Main(string[] args) =>
            Parser.Default.ParseArguments<Options>(args)
              .MapResult(Main, HandleErrors);

        internal static int Main(Options options)
        {
            string algorithmName = options.Algorithm.ToString().ToUpperInvariant();
            using (var hashAlgorithm = HashAlgorithm.Create(algorithmName)) {
                using (var file = File.OpenRead(options.FileName)) {
                    Console.WriteLine(hashAlgorithm.ComputeHash(file));
                    return 0;
                }
            }
        }

        internal static int HandleErrors(IEnumerable<Error> errs) => 1;
    }
}
