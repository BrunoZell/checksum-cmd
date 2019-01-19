using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;

namespace Checksum
{
    public partial class Program
    {
        public static int Main(string[] args) =>
            Parser.Default.ParseArguments<Options>(args)
              .MapResult(Main, HandleErrors);

        internal static int Main(Options options)
        {
            using (var hashAlgorithm = AlgorithmFactory.ResolveAlgorithm(options.Algorithm)) {
                using (var file = File.OpenRead(options.FileName)) {
                    byte[] hash = hashAlgorithm.ComputeHash(file);
                    string hex = BitConverter.ToString(hash)
                        .Replace("-", String.Empty)
                        .ToLowerInvariant();

                    Console.WriteLine(hex);
                    return 0;
                }
            }
        }

        internal static int HandleErrors(IEnumerable<Error> errs) => 1;
    }
}
