using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class WreckingBall : Giratorio
{
    public AudioSource audioSource;

    public bool voltar, avancar;
    public bool playDelay;
    public float amdspega;
    public float delay;
    // Start is called before the first frame update
    public override void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        if(x)
            rotacao = new Vector3(valorFinal, 0, 0);
        if (y)
            rotacao = new Vector3(0, valorFinal, 0);
        if (z)
            rotacao = new Vector3(0, 0, valorFinal);



        if (playDelay)
            audioSource.PlayDelayed(delay);
    }
    public override void Update()
    {
        if (z)
        {
            amdspega = transform.rotation.eulerAngles.z;

            if (voltar && transform.rotation.eulerAngles.z >= 90f && transform.rotation.eulerAngles.z <= 95f)
            {
                rotacao = new Vector3(0, 0, -valorFinal);
                voltar = false;
                avancar = true;
            }
            if (avancar && transform.rotation.eulerAngles.z >= 270f && transform.rotation.eulerAngles.z <= 275f)
            {
                rotacao = new Vector3(0, 0, valorFinal);
                avancar = false;
                voltar = true;
            }
        }
        else if (x)
        {
            amdspega = transform.rotation.eulerAngles.x;

            if (voltar && transform.rotation.eulerAngles.x >= 90f && transform.rotation.eulerAngles.x <= 95f)
            {
                rotacao = new Vector3(0, 0, -valorFinal);
                voltar = false;
                avancar = true;
            }
            if (avancar && transform.rotation.eulerAngles.x >= 270f && transform.rotation.eulerAngles.x <= 275f)
            {
                rotacao = new Vector3(0, 0, valorFinal);
                avancar = false;
                voltar = true;
            }
        }
        else if (y)
        {
            amdspega = transform.rotation.eulerAngles.y;

            if (voltar && transform.rotation.eulerAngles.y >= 90f && transform.rotation.eulerAngles.y <= 95f)
            {
                rotacao = new Vector3(0, 0, -valorFinal);
                voltar = false;
                avancar = true;
            }
            if (avancar && transform.rotation.eulerAngles.z >= 270f && transform.rotation.eulerAngles.z <= 275f)
            {
                rotacao = new Vector3(0, 0, valorFinal);
                avancar = false;
                voltar = true;
            }
        }
       

        Rotacionar360Loop();

    }
}
    