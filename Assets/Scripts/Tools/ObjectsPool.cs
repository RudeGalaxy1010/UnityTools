using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool<T>
    where T : Object
{
    private readonly string OBJECTS_PARENT_NAME;
    private const int DEFAULT_MAX_OBJECTS_COUNT = 10;
    private static Vector3 DEFAULT_START_POSITION = new Vector3(100, 100);

    private Queue<GameObject> _objectsQueue;
    private GameObject _objectPrefab;
    private int _maxObjectsCount;
    private Vector3 _startPosition;
    private Transform _objectsParent;

    #region Constructors

    public ObjectsPool(GameObject objectPrefab) : this(objectPrefab, DEFAULT_MAX_OBJECTS_COUNT) { }

    public ObjectsPool(GameObject objectPrefab, int maxObjectsCount) : this(objectPrefab, maxObjectsCount, DEFAULT_START_POSITION) { }

    public ObjectsPool(GameObject objectPrefab, int maxObjectsCount, Vector3 startPosition)
    {
        OBJECTS_PARENT_NAME = "[OBJECTS_POOL]" + $" of {objectPrefab.name}";
        _objectsParent = new GameObject(OBJECTS_PARENT_NAME).transform;
        _objectsParent.position = startPosition;
        _objectsQueue = new Queue<GameObject>();
        _objectPrefab = objectPrefab;
        _maxObjectsCount = maxObjectsCount;
        _startPosition = startPosition;

        if (maxObjectsCount < 0)
        {
            _maxObjectsCount = DEFAULT_MAX_OBJECTS_COUNT;
        }

        Init(_objectPrefab, _maxObjectsCount);
    }

    #endregion

    #region Get-Methods

    public T Instantiate()
    {
        var result = GetGameObjectFromQueue();
        result.transform.SetParent(null);
        result.SetActive(true);
        return result.GetComponent<T>();
    }

    public T Instantiate(Vector3 position)
    {
        var result = GetGameObjectFromQueue();
        result.transform.SetParent(null);
        result.transform.position = position;
        result.SetActive(true);
        return result.GetComponent<T>();
    }

    public T Instantiate(Vector3 position, Quaternion rotation)
    {
        var result = GetGameObjectFromQueue();
        result.transform.SetParent(null);
        result.transform.position = position;
        result.transform.rotation = rotation;
        result.SetActive(true);
        return result.GetComponent<T>();
    }

    public T Instantiate(Vector3 position, Quaternion rotatation, Transform parent)
    {
        var result = GetGameObjectFromQueue();
        result.transform.SetParent(null);
        result.transform.position = position;
        result.transform.rotation = rotatation;
        result.transform.SetParent(parent);
        result.SetActive(true);
        return result.GetComponent<T>();
    }

    #endregion

    private GameObject GetGameObjectFromQueue()
    {
        if (_objectsQueue.Count > 0)
        {
            return _objectsQueue.Dequeue();
        }

        ReInit();
        return GetGameObjectFromQueue();
    }

    private void Init(GameObject prefab, int maxObjectsCount)
    {
        for (int i = 0; i < maxObjectsCount; i++)
        {
            var newObject = Spawn(prefab);
            newObject.transform.SetParent(_objectsParent);
            newObject.transform.localPosition = Vector3.zero;
            newObject.SetActive(false);
            newObject.name += " from pool";
            _objectsQueue.Enqueue(newObject);
        }
    }

    private void ReInit()
    {
        Init(_objectPrefab, DEFAULT_MAX_OBJECTS_COUNT);
    }

    private GameObject Spawn(GameObject prefab)
    {
        return Object.Instantiate(prefab);
    }
}
