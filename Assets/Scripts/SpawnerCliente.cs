using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerCliente : MonoBehaviour
{
    [Header("Referencia dos Spawners")]
    [SerializeField]
    GameObject spawner1;
    [SerializeField]
    GameObject spawner2;
    [Header("Referencia do Cliente")]
    [SerializeField]
    GameObject cliente;
    [Header("Referencia do Player")]
    [SerializeField]
    GameObject player;


    int chanceDeAparecer;
    private void FixedUpdate()
    {
        transform.position = new Vector3(0,0,player.transform.position.z);
    }
    public void AparecerCliente()
    {
        chanceDeAparecer = UnityEngine.Random.Range(0, 4);
        print(chanceDeAparecer);
        if (chanceDeAparecer == 0)
        {
            Instantiate(cliente, spawner1.transform.position, Quaternion.Euler(0,90,0));
        }
        if (chanceDeAparecer == 1)
        {
            Instantiate(cliente, spawner2.transform.position, Quaternion.Euler(0, -90, 0));
        }
        if (chanceDeAparecer == 2)
        {
            Instantiate(cliente, spawner1.transform.position, Quaternion.Euler(0, 90, 0));
            Instantiate(cliente, spawner2.transform.position, Quaternion.Euler(0, -90, 0));
        }
        if (chanceDeAparecer == 3)
        {
        }
    }

}
