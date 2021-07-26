using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStringSerializer<T>
{
    string Serialize(T data);
    T Deserialize(string data);
}
