using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject platformObject;
    [SerializeField] private int poolSize;
    public Transform generatorPoint;
    public float Width = 3f;
    public float minY = 2f;
    public float maxY = 1.5f;

    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public int poolSize;
    }

    [SerializeField] private Pool[] pools = null;
    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();
      
                for (int i = 0; i < poolSize; i++)
                {      
                    GameObject obj = Instantiate(platformObject, transform.position, Quaternion.identity);
                        obj.SetActive(false);        
                        pooledObjects.Enqueue(obj);        
                }
        }
    }

    public GameObject GetPlatformFromPool()
    {
        GameObject platformFromPool = pooledObjects.Dequeue();
        platformFromPool.SetActive(true);
        pooledObjects.Enqueue(platformFromPool);
        return platformFromPool;
    }
}
