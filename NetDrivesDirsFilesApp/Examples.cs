using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDrivesDirsFilesApp
{
    internal static class Examples
    {
        public static void FileExample()
        {
            string fileName = "file01.dat";

            /*
            Create(filename)
            Delete(filename)
            Move(Sourcefilename, Distfilename)
            Copy(Sourcefilename, Distfilename)
            Exists(filename)
             */

            string text = "Creates a StreamWriter that appends UTF-8 encoded text to an existing file, or to a new file if the specified file does not exist." +
                "Массив является единственным типом в этом примере, который содержит закодированные данные. .NET Char и String типы представляют собой Юникод, поэтому GetChars вызов декодирует данные обратно в Юникод.";
            string[] textLines = new[]
            {
                "hello world",
                "hello people"
            };


            //File.Create(fileName);

            //File.WriteAllText(fileName, text, Encoding.UTF8);
            //File.AppendAllLines(fileName, textLines);

            //float n = 123.56765f;
            //File.WriteAllBytes(fileName, BitConverter.GetBytes(n));

            File.WriteAllBytes(fileName, Encoding.Unicode.GetBytes(text));

            //var txt = File.ReadAllText(fileName, Encoding.ASCII);

            var txt = File.ReadAllBytes(fileName);
            Console.WriteLine(Encoding.Unicode.GetString(txt));

            //var txtLines = File.ReadAllLines(fileName);
            //foreach(string line in txtLines)
            //    Console.WriteLine(line);

            //var lines = File.ReadLines(fileName);
            //foreach (string line in lines)
            //    Console.WriteLine(line);


            //var buff = File.ReadAllBytes(fileName);
            //var fvar = BitConverter.ToSingle(buff, 0);

            //Console.WriteLine(fvar);

            //File.Delete(fileName);
        }

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
