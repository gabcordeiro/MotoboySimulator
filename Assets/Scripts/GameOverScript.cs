using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
    public void RecomecarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("dasfasdf");
    }
    public void VoltarAoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
