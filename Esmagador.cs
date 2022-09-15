using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Esmagador : Espinho
{
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyEspinhos = conjuntoEspinho.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    public override void Update()
    {
        t += Time.deltaTime;

        if (descer && t >= numeroA)
        {
            //rigidbodyEspinhos.DOMoveX(transform.position.x - 8f, .5f);
            rigidbodyEspinhos.DOMove(new Vector3(transform.position.x - 8f, transform.position.y, transform.position.z), .5f);
            descer = false;
            subir = true;
            numeroA = 2f;
            t = 0;
        }
        if (subir && t >= numeroA)
        {
            //rigidbodyEspinhos.DOMoveX(transform.position.x+10, .5f);
            rigidbodyEspinhos.DOMove( new Vector3(transform.position.x+10f,transform.position.y,transform.position.z), .5f);
            subir = false;
            descer = true;
            numeroA = 2f;
            t = 0;
        }
    }
}
