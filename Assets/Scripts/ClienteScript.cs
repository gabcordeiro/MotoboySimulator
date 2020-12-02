using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClienteScript : MonoBehaviour
{
    [Header("Eventos")]
    [SerializeField]
    UnityEvent fezEntrega;
    [Header("Referencia de GameObjects")]
    [SerializeField]
    GameObject particula1;
    [SerializeField]
    GameObject particula2;
    [SerializeField]
    GameObject circuloTransform;
    [Header("Materiais")]
    [SerializeField]
    Material jaPassouMaterial;
    [SerializeField]
    Material naoPassouMaterial;

    MeshRenderer meshRenderer;
    Animator anim;
    bool jaPassou = false;
    void Start()
    {
        
        anim = GetComponent<Animator>();
        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        if (!jaPassou)
        {
            meshRenderer.material = naoPassouMaterial;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && jaPassou==false)
        {
            PassouNoCollider();
        }
    }

    private void PassouNoCollider()
    {
        Instantiate(particula1, circuloTransform.transform.position, new Quaternion(0, 0, 0, 0));
        Instantiate(particula2, circuloTransform.transform.position, new Quaternion(0, 0, 0, 0));
        anim.SetBool("EntregaFeita", true);
        jaPassou = true;
        meshRenderer.material = jaPassouMaterial;
        fezEntrega.Invoke();
    }
}
