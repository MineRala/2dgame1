using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCaller : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool = null;
    public float Width = 3f;
    public float minY = 2f;
    public float maxY = 1.5f;
    public Transform character;
    public Transform generatorPoint;
    public Vector3 lastLeftColumn = new Vector3(-2.632f, -0.92f, 0);
    private GameObject tempLeftColumn;
    private void Update()
    {
        if (transform.position.y < generatorPoint.position.y+5)
        {
            Vector2 spawnPosition = new Vector2();
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-Width, Width);
            transform.position = new Vector3(spawnPosition.x, transform.position.y + spawnPosition.y, transform.position.z);
            GameObject platform = objectPool.GetPooledObject(1 ,transform.position);
            platform.transform.position = transform.position;
 


        }    
    }
}
