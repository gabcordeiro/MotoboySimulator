using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movimentacao da Moto")]
    [SerializeField]
    float velocidadeMudarPista;
    [SerializeField]
    int pista = 1;
    [SerializeField]
    AnimationCurve curvaPosicaoPassarDePista;
    [SerializeField]
    float distanciaLane;
    [SerializeField]
    Vector3 centroDeMassa;
    [Header("Eventos")]
    [SerializeField]
    UnityEvent gameOver;


    PlayerDificuldade dificuldade;
    Animator animator;
    State estado;
    float velocTime;
    float lerpTime = 3;
    float animationCurve;

    enum State
    {
        Parado,
        Morto,
    }
    

    // Start is called before the first frame update
    void Start()
    {
        estado = State.Parado;
        animator = GetComponent<Animator>();
        dificuldade = GetComponent<PlayerDificuldade>();
    }
    void Update()
    {
        MoverPlayer();
    }
    void MoverPlayer()
    {
        switch (estado) {
        case State.Parado:

        Vector3 proximaPosicao = transform.position.z * transform.forward + transform.position.y * transform.up;
                proximaPosicao =new Vector3(proximaPosicao.x, 1.5f, proximaPosicao.z);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
                    if (pista == 0)
                    {
                        animator.SetTrigger("Direita");
                    }
                    else if (pista == 1)
                    {

                        animator.SetTrigger("Direita");
                    }
                    pista++;
                    
                    if (pista >= 2)
            {
                pista = 2;
                    }
                    
                }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
                    if (pista == 1)
                    {
                        animator.SetTrigger("Esquerda");
                    }
                    else if (pista == 2)
                    {

                        animator.SetTrigger("Esquerda");
                    }
                    pista--;
                    
                    if (pista <= 0)
            {
                pista = 0;
                    }
                }
        if (pista == 0)
        {
            proximaPosicao += Vector3.left * distanciaLane;
            
        }else if (pista == 2)
        {
            proximaPosicao += Vector3.right * distanciaLane;        
        }
                transform.position = Vector3.Lerp(transform.position, proximaPosicao, ComecarAnimationCurve(curvaPosicaoPassarDePista) * velocidadeMudarPista);   
        break;
            case State.Morto:

                break;
        }
    }
    void OnTriggerEnter(Collider other)
    {
  
        if (other.gameObject.tag == "Obstaculo")
        {
            estado = State.Morto;
            dificuldade.jogando = false;
            gameOver.Invoke();
        }
    }

    float ComecarAnimationCurve(AnimationCurve curvaAnimacao)
    {
        
        velocTime = Time.deltaTime;
        if (velocTime>lerpTime)
        {
            velocTime = lerpTime;
        }
        float lerpRatio = velocTime / lerpTime;
        animationCurve = curvaAnimacao.Evaluate(lerpRatio);
        return animationCurve;
        
    }
}
