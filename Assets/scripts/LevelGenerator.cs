﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms;
    
    public float Width = 3f;
    public float minY= 2f;

    public float maxY=1.5f;

    void Start()
    {
        Vector3 spawnPosition = new Vector2();
        for(int i = 0; i < numberOfPlatforms; i++){
            spawnPosition.y += Random.Range(minY,maxY);
            spawnPosition.x = Random.Range(-Width , Width);
            Instantiate(platformPrefab,spawnPosition,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
