using System;
using System.IO;

namespace CWI.Watcher.Shared
{
    public static class Domain
    {
        public static string Delimiter { get; } = "ç";
        public static string DelimiterItems { get; } = ",";
        public static string DelimiterItem { get; } = "-";
        public static string DecimalSymbol { get; } = ".";
        public static string PathBase { get; } = Environment.GetEnvironmentVariable("HOMEPATH");
        public static string PathIn { get; } = Path.Combine(PathBase, "data", "in");
        public static string PathTemp { get; } = Path.Combine(PathBase, "data", "temp");
        public static string PathError { get; } = Path.Combine(PathBase, "data", "out", "error");
        public static string PathOut { get; } = Path.Combine(PathBase, "data", "out");
        public static string[] AcceptedFileFormats { get; } = { "*.txt", "*.dat" };
    }
}
