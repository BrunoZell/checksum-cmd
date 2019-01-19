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
                options.AutoHelp = true;
            });

        private static int Main(Options options)
        {
            try {
                if (!File.Exists(options.FileName)) {
                    Console.Error.WriteLine($"File {options.FileName} does not exists.");
                    return 1;
                }

                return PrintHash(options);
            } catch (AlgorithmNotSupportedException ex) {
                Console.Error.WriteLine(ex.Message);
                return 1;
            } catch (Exception) {
                Console.Error.WriteLine("An error occurred.");
                return 1;
            }
        }

        private static int PrintHash(Options options)
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

        private static int HandleErrors(IEnumerable<Error> errors)
        {
            Console.Error.WriteLine("Command line arguments invalid. Usage example:");
            Console.Error.WriteLine("> chksm sha1 file.exe");
            Console.Error.WriteLine("Supported hash algorithms: SHA1, SHA256, SHA384, SHA512, MD5");
            Console.Error.WriteLine("Visit https://github.com/BrunoZell/checksum-cmd for more information.");
            return 1;
        }
    }
}
