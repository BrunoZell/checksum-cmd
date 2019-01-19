using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;

namespace Checksum
{
    public partial class Program
    {
        public static int Main(string[] args) =>
            BuildParser().ParseArguments<Options>(args)
              .MapResult(Main, HandleErrors);

        private static Parser BuildParser() =>
            new Parser(options => {
                options.CaseInsensitiveEnumValues = true;
            });

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

        internal static int HandleErrors(IEnumerable<Error> errors)
        {
            foreach (var error in errors) {
                Console.WriteLine(error.Tag);
            }

            return 1;
        }
    }
}
