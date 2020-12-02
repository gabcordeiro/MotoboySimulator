using UnityEngine;
using UnityEngine.Events;

public class PlayerDificuldade : MonoBehaviour
{
    [Header("Velocidade Jogador")]
    [SerializeField]
    [Range(1, 10)]
    int fatorDeVelocidade;
    [SerializeField]
    int nivel;
    [SerializeField]
    int ajusteVelocidade;
    [SerializeField]
    int tempo;
    [SerializeField]
    float tempoObstaculos;
    [SerializeField]
    float dificuldadeObstaculos = 1;

    [Header("Eventos")]
    [SerializeField]
    UnityEvent disparaEventoSpawner;

    Rigidbody playerRigidBody;
    bool passarNivel = false;
    public bool jogando = true;

    void Start()
    {
        ajusteVelocidade = 500;
        fatorDeVelocidade = 3;
        playerRigidBody = GetComponent<Rigidbody>();


    }

    void FixedUpdate()
    {
        if (jogando)
        {
            ContadorFrames();
            MovimentarPlayer();
        }
        else
        {
            ajusteVelocidade = 0;
            fatorDeVelocidade = 0;
            playerRigidBody.velocity = new Vector3(0, 0,0);

        }
    }
    private void MovimentarPlayer()
    {
        playerRigidBody.velocity = new Vector3(0, 0, fatorDeVelocidade * Time.deltaTime * ajusteVelocidade);
    }

    private void ContadorFrames()
    {
        tempo = tempo + fatorDeVelocidade;
        tempoObstaculos = tempoObstaculos + Time.deltaTime;
        if (tempo >= 400)
        {
            nivel++;

            tempo = 0;
            passarNivel = true;


        }
        if (tempoObstaculos >= dificuldadeObstaculos)
        {
            tempoObstaculos = 0;           
            disparaEventoSpawner.Invoke();
            //print("toma");
        }


        if (nivel == 5 && passarNivel)
        {

            fatorDeVelocidade++;
            passarNivel = false;

        }
        else if (nivel == 10 && passarNivel)
        {

            fatorDeVelocidade++;
            passarNivel = false;
            dificuldadeObstaculos = 0.7f;
        }
        else if (nivel == 15 && passarNivel)
        {

            fatorDeVelocidade++;
            passarNivel = false;
            dificuldadeObstaculos = 0.5f;
        }
        else if (nivel == 25 && passarNivel)
        {

            fatorDeVelocidade++;
            passarNivel = false;
            dificuldadeObstaculos = 0.4f;
        }
    }
}
