using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveSystem<T>
{
    public void Save(T data);

    public T Load();
}
