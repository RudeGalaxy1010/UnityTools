using System;
using UnityEngine;

public class JsonSerializer<T> : IStringSerializer<T>
{
    public string Serialize(T data)
    {
        return JsonUtility.ToJson(data);
        throw new Exception("Something went wrong...");
    }

    public T Deserialize(string data)
    {
        return JsonUtility.FromJson<T>(data);
        throw new Exception("Something went wrong...");
    }
}
