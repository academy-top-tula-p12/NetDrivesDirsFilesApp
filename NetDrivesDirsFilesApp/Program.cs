// File
// FileInfo

string fileName = "file01.dat";

FileInfo f = new(fileName);
f.Open(FileMode.Open);

//File.Create(fileName);
File.Delete(fileName);