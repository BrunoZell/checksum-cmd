using CommandLine;

namespace Checksum
{
    internal class Options
    {
        [Value(0, MetaName = "algorithm", Required = true, HelpText = "Algorithm to calculate the checksum: SHA1, SHA256, SHA384, SHA512, MD5")]
        public string Algorithm { get; set; }

        [Value(1, MetaName = "filename", Required = true, HelpText = "File name of the file to test")]
        public string FileName { get; set; }
    }
}
