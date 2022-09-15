using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoverDirecao : MonoBehaviour
{
    public bool descer, subir;
    public Rigidbody meuRb;
    public float valorFinal;
    public float velocidadeMover;
    public float cdMover;


    float t;

    void Awake()
    {
        meuRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (descer && t >= cdMover)
        {
            meuRb.DOMoveY(transform.position.y - valorFinal, velocidadeMover);
            descer = false;
            subir = true;
            t = 0;
        }
        else if (subir && t >= cdMover)
        {
            meuRb.DOMoveY(transform.position.y + valorFinal, velocidadeMover);
            subir = false;
            descer = true;
            t = 0;
        }
    }
}
