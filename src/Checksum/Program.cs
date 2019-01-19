using CommandLine;
using System.Collections.Generic;

namespace Checksum
{
    public partial class Program
    {
        public static int Main(string[] args) =>
            Parser.Default.ParseArguments<Options>(args)
              .MapResult(Main, HandleErrors);

        internal static int Main(Options options) => 0;

        internal static int HandleErrors(IEnumerable<Error> errs) => 1;
    }
}
