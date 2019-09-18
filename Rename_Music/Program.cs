using System;
using System.IO;
using Common.Functions.ListFilesUnderDirectory;
using Id3;
using IEnumerable.ForEach;

namespace Rename_Music
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
//            foreach (var item in DirectoryFileLister.ListFiles(
//                @"G:\DK-HP-PA-2000AR\Songs\Records\Pitbull\Global Warming"))
//                Console.WriteLine(item);

//            DirectoryFileLister.ListFiles(@"G:\DK-HP-PA-2000AR\Songs\Records\Pitbull\Global Warming").ForEach(item =>
//            {
//                if (item.Contains(".mp3"))
//                {
//                    Console.WriteLine(item);
//                }
//            });

            DirectoryFileLister.ListFiles(@"G:\DK-HP-PA-2000AR\Songs\Records\Pitbull\Global Warming").ForEach(file =>
            {
                if (!new FileInfo(file).Extension.Equals(".mp3")) return;
                Console.WriteLine("File : " + file);
                var tag = new Mp3(file).GetTag(Id3TagFamily.Version2X);
                Console.WriteLine("Title: {0}", tag.Title);
                Console.WriteLine("Artist: {0}", tag.Artists);
                Console.WriteLine("Album: {0}", tag.Album);
            });
        }
    }
}
