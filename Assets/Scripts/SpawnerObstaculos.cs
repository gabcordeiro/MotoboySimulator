using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstaculos : MonoBehaviour
{


    [Header("Referencia dos Spawners")]
    [SerializeField]
    GameObject spawner1;
    [SerializeField]
    GameObject spawner2;
    [SerializeField]
    GameObject spawner3;
    [Header("Referencia dos Obstaculos")]
    [SerializeField]
    GameObject[] obstaculos;
    [Header("Referencia do Player")]
    [SerializeField]
    GameObject player;

    List<GameObject> activeTiles = new List<GameObject>();
    int chanceDeAparecer;
    private void FixedUpdate()
    {
        transform.position = new Vector3(0, 0, player.transform.position.z);
    }
    public void AparecerObstaculo()
    {
        chanceDeAparecer = UnityEngine.Random.Range(0, 6);
        if (chanceDeAparecer == 0)
        {
            Instantiate(obstaculos[UnityEngine.Random.Range(0, obstaculos.Length)], spawner1.transform.position , Quaternion.Euler(0, 0, 0));
        }
        if (chanceDeAparecer == 1)
        {
            Instantiate(obstaculos[UnityEngine.Random.Range(0, obstaculos.Length)], spawner2.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (chanceDeAparecer == 2)
        {
            Instantiate(obstaculos[UnityEngine.Random.Range(0, obstaculos.Length)], spawner3.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (chanceDeAparecer == 3)
        {
            Instantiate(obstaculos[UnityEngine.Random.Range(0, obstaculos.Length)], spawner1.transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(obstaculos[UnityEngine.Random.Range(0, obstaculos.Length)], spawner2.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (chanceDeAparecer == 4)
        {
            Instantiate(obstaculos[UnityEngine.Random.Range(0, obstaculos.Length)], spawner2.transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(obstaculos[UnityEngine.Random.Range(0, obstaculos.Length)], spawner3.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (chanceDeAparecer == 5)
        {
            Instantiate(obstaculos[UnityEngine.Random.Range(0, obstaculos.Length)], spawner1.transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(obstaculos[UnityEngine.Random.Range(0, obstaculos.Length)], spawner3.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }

}
