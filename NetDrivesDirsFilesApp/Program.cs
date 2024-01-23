// File
// FileInfo

using System.Text;

string fileName = "file01.dat";

FileInfo file = new(fileName);
if(file.Exists)
{
    Console.WriteLine(file.Directory);
    Console.WriteLine(file.DirectoryName);
    Console.WriteLine(file.Name);
    Console.WriteLine(file.Extension);
    Console.WriteLine(file.FullName);
    Console.WriteLine(file.CreationTime);
    Console.WriteLine(file.Length);


    file.Replace(@"D:\newfile.max", @"D:\backup.bak");
}




//f.Open(FileMode.Open);


