using System;
using System.IO;

public class FileSaveSystem<T> : ISaveSystem<T>
{
    private readonly string _fileName;
    private readonly IStringSerializer<T> _serializer;

    public FileSaveSystem(string fileName, IStringSerializer<T> serializer)
    {
        _fileName = fileName;
        _serializer = serializer;
    }

    public T Load()
    {
        if (File.Exists(_fileName))
        {
            return _serializer.Deserialize(File.ReadAllText(_fileName));
        }

        throw new Exception("File does not exit");
    }

    public void Save(T data)
    {
        if (!File.Exists(_fileName))
        {
            File.Create(_fileName);
        }

        File.WriteAllText(_fileName, _serializer.Serialize(data));
    }
}
