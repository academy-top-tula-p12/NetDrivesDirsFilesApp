using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDrivesDirsFilesApp
{
    internal static class Examples
    {
        public static void DirectoryInfoExample()
        {
            // DirectoryInfo

            DriveInfo drive = DriveInfo.GetDrives()[1];
            DirectoryInfo root = drive.RootDirectory;

            //string dirName = "NewDir";

            //DirectoryInfo directory = new(root.FullName + "/" + dirName);
            //if(!directory.Exists)
            //{
            //    directory.Create();
            //    Console.WriteLine($"{directory.Name} create!");
            //}
            //else
            //    Console.WriteLine($"{directory.Name} exists!");

            //var ch = Console.ReadLine();

            //directory.MoveTo(Directory.GetCurrentDirectory() + "/" + dirName + "Moved");

            //if (directory.Exists)
            //{
            //    directory.Delete(true);
            //    Console.WriteLine($"{directory.Name} deleted!");
            //}

            foreach (var dir in root.GetDirectories("*o*"))
                Console.WriteLine($"{dir.Name}\t\t{dir.CreationTime}");
            Console.WriteLine();
            foreach (var file in root.GetFiles("*.pkt"))
                Console.WriteLine($"{file.Name}\t\t{file.CreationTime}");
        }

        public static void DirectoryExample()
        {
            // Directory
            DriveInfo drive = DriveInfo.GetDrives()[1];
            DirectoryInfo root = drive.RootDirectory;

            //Console.WriteLine(Directory.GetCurrentDirectory());
            //Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"/NewDir");
            //Directory.Move(Directory.GetCurrentDirectory() + @"/NewDir", "D:/NewDir");
            if (Directory.Exists(Directory.GetCurrentDirectory() + @"/NewDir"))
                Directory.Delete(Directory.GetCurrentDirectory() + @"/NewDir");
            foreach (var dir in Directory.GetDirectories(root.FullName))
            {
                Console.Write($"{dir}\t\t{((dir.Length < 8) ? '\t' : "")}" +
                    $"{Directory.GetCreationTime(dir)}\t" +
                    $"{Directory.GetLastAccessTime(dir)}\t" +
                    $"{Directory.GetLastWriteTime(dir)}\n");
            }

            Console.WriteLine();
            foreach (var file in Directory.GetFiles(root.FullName))
                Console.WriteLine(file);
            Console.WriteLine();
            foreach (var entries in Directory.GetFileSystemEntries(root.FullName))
                Console.WriteLine(entries);
        }

        public static void DrivesExample()
        {
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                Console.WriteLine($"Drive name: {drive.Name}");
                Console.WriteLine($"Drive type: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Drive label: {drive.VolumeLabel}");
                    Console.WriteLine($"Drive format: {drive.DriveFormat}");
                    Console.WriteLine($"Drive total size: {drive.TotalSize}");
                    Console.WriteLine($"Drive available free size: {drive.AvailableFreeSpace}");
                    Console.WriteLine($"Drive total free space: {drive.TotalFreeSpace}");
                }
                Console.WriteLine();
            }
        }
    }
}
