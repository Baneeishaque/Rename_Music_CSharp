using System;
using Common.Functions.ListFilesUnderDirectory;

namespace Rename_Music
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            foreach (var item in DirectoryFileLister.ListFiles(
                @"G:\DK-HP-PA-2000AR\Songs\Records\Pitbull\Global Warming"))
                Console.WriteLine(item);
        }
    }
}