using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ForFileName
{
    [Serializable]
    public class FileNameCustom
    {
        public string Filename { get; set; }
        public byte[] arr { get; set; }
        public string Path { get; set; }
        public FileNameCustom(string filename, byte[] a)
        {
            this.arr = a;
            this.Filename = filename;
        }
        public void SetPath(string path)
        {
            this.Path = path;
        }
    }
}
