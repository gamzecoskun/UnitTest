using System;
using System.IO;

namespace FileReader
{
    public class FileReaderComponent
    {
        private readonly IFileReader _fileReader;
        public FileReaderComponent(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }
        public string ReadAndAppendeHello(string path)
        {
            if (_fileReader.Exists(path))
            {
                var content = _fileReader.ReadAllText(path);
                return content + "Hello";
            }
            throw new ArgumentException($"{nameof(path)} is invalid!");

        }
    }

    public interface IFileReader
    {
        bool Exists(string path);
        string ReadAllText(string path);
    }

    public class FileReader : IFileReader
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
