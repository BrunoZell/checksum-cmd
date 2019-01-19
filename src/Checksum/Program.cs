using Checksum.Exceptions;
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
            try {
                if (!File.Exists(options.FileName)) {
                    Console.Error.WriteLine($"File {options.FileName} does not exists.");
                    return 1;
                }

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
            } catch (AlgorithmNotSupportedException ex) {
                Console.WriteLine(ex.Message);
                return 1;
            } catch (Exception) {
                Console.WriteLine("An error occurred.");
                return 1;
            }
        }

        internal static int HandleErrors(IEnumerable<Error> errors)
        {
            Console.WriteLine("Command line arguments cannot be parsed:");

            foreach (var error in errors) {
                Console.WriteLine(error.Tag);
            }

            return 1;
        }
    }
}
