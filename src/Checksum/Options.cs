using CommandLine;

namespace Checksum
{
    internal class Options
    {
        [Value(0, MetaName = "algorithm", HelpText = "Algorithm to calculate the checksum")]
        public Algorithms Algorithm { get; set; }

        [Value(1, MetaName = "filename", HelpText = "File name of the file to test")]
        public string FileName { get; set; }
    }
}
