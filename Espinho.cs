using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Espinho : MonoBehaviour
{
    public GameObject conjuntoEspinho;
    public Rigidbody rigidbodyEspinhos;
    public bool descer, subir;
    public float t;
    public float numeroA;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyEspinhos = conjuntoEspinho.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
         t += Time.deltaTime;

        if (descer && t >= numeroA)
        {
            rigidbodyEspinhos.DOMoveY(transform.position.y - 2f, 1);
            numeroA = Random.Range(1f, 2f);
            descer = false;
            subir = true;
            t = 0;
        }
        if (subir && t >= numeroA)
        {
            rigidbodyEspinhos.DOMoveY(transform.position.y , .1f);
            numeroA = Random.Range(1f, 4f);
            subir = false;
            descer = true;
            t = 0;
        }
    }
}
