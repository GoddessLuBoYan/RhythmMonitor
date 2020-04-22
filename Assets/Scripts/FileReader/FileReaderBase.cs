using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class FileReaderBase
{
    protected INoteFactory factory;
    public FileReaderBase(INoteFactory factory) { this.factory = factory; }

    public void LoadFile(string path)
    {
        var content = File.ReadAllBytes(path);
        LoadBuffer(content);
    }

    public void LoadBuffer(byte[] buffer)
    {
        using (var stream = new MemoryStream(buffer))
        {
            LoadStream(stream);
        }
    }

    public void LoadStream(Stream stream)
    {
        using (var reader = new BinaryReader(stream))
        {
            LoadBinaryReader(reader);
        }
    }

    public abstract void LoadBinaryReader(BinaryReader reader);
}
