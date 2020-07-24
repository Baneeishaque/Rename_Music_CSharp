using System;
using System.IO;
using Common.Functions.ListFilesUnderDirectory;
using Id3;
using IEnumerable.ForEach;

//using FileManagerCore;
//using FileManagerCore.Models;

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

            const string folder = @"D:\Global Warming";
            DirectoryFileLister.ListFiles(folder).ForEach(songFile =>
            {
                var songFileInfo = new FileInfo(songFile);
                if (!songFileInfo.Extension.Equals(".mp3")) return;

                Console.WriteLine("Song : " + songFile);

                var tag = new Mp3(songFile).GetTag(Id3TagFamily.Version2X);
                Console.WriteLine("Title: {0}", tag.Title);
                Console.WriteLine("Artist: {0}", tag.Artists);
//                Console.WriteLine("Album: {0}", tag.Album);

                var songTitle = tag.Title.ToString().Trim();
                var songArtist = tag.Artists.ToString().Trim();
                var newSongFileBase = folder + "\\" + songTitle + " - " + songArtist;
                Console.WriteLine("New Song File Base : " + newSongFileBase);
                var newSongFile = newSongFileBase + songFileInfo.Extension;

//                var fileService=new FileService(new FileManagerConfig());
//                fileService.Rename(songFileInfo.Name+songFileInfo.Extension,folder,newSongFileBase+songFileInfo.Extension,DirectoryType.File);
//                File.Move(file, newFileBase + ".mp3");

                var lyrics = songFileInfo.Name + ".lrc";
                if (!File.Exists(lyrics)) return;

                Console.WriteLine("Lyrics : " + lyrics);
                var newLyricsFile = newSongFileBase + ".lrc";
//                fileService.Rename(lyrics,folder,newSongFileBase+".lrc",DirectoryType.File);
//                File.Move(lyrics, newFileBase + ".lrc");
            });
        }
    }
}
