using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistasSpawnScript : MonoBehaviour
{
    [Header("Pistas")]
    [SerializeField]
    GameObject[] pistasRetaArray;
    [SerializeField]
    float tamanhoPista;
    [SerializeField]
    float zSpawn;
    [SerializeField]
    int numeroDeSpawn;
    [SerializeField]
    Transform playerTransform;
    [Header("Obstaculos")]
    [SerializeField]
    GameObject[] obstaculosArray;

    List<GameObject> activeTiles = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < numeroDeSpawn; i++)
        {
            if (i == 0)
            {
                SpawnPista(0);
                
            }
            else
            {
                
                SpawnPista(UnityEngine.Random.Range(0, pistasRetaArray.Length));
            }
            
        }

    }
    void FixedUpdate()
    {
       

        if (playerTransform.transform.position.z-35 > zSpawn - (numeroDeSpawn * tamanhoPista))
        {
            SpawnPista(UnityEngine.Random.Range(0, pistasRetaArray.Length));
            DeletarPistas();
        }

    }
    void SpawnPista(int index)
    {
        GameObject go = Instantiate(pistasRetaArray[index], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tamanhoPista;

    }
    void DeletarPistas()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }




}
