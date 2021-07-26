using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaveSystem<T> : MonoBehaviour
{
    [Serializable]
    public struct SaveData
    {
        public List<T> SaveList;
        public bool IsSingle;
    }
    private readonly string _saveKey;
    private readonly IStringSerializer<SaveData> _serializer;

    public PlayerPrefsSaveSystem(string saveKey, IStringSerializer<SaveData> serializer)
    {
        _saveKey = saveKey;
        _serializer = serializer;
    }

    public T LoadSingle()
    {
        var data = PlayerPrefs.GetString(_saveKey);
        var convertedData = _serializer.Deserialize(data);
        if (!convertedData.IsSingle)
        {
            throw new Exception("Can't convert data. Should use method for multiple objects");
        }
        else
        {
            return convertedData.SaveList[0];
        }
    }

    public void SaveSingle(T data)
    {
        string result = _serializer.Serialize(new SaveData { SaveList = new List<T> { data }, IsSingle = true });
        PlayerPrefs.SetString(_saveKey, result);
    }

    public List<T> LoadMultiple()
    {
        var data = PlayerPrefs.GetString(_saveKey);
        SaveData result = _serializer.Deserialize(data);
        if (result.IsSingle)
        {
            throw new Exception("Can't convert data. Should use method for single object");
        }
        else
        {
            return result.SaveList;
        }
    }

    public void SaveMultiple(List<T> data)
    {
        var dataToConvert = new SaveData { SaveList = data, IsSingle = false };
        string result = _serializer.Serialize(dataToConvert);
        PlayerPrefs.SetString(_saveKey, result);
    }
}
