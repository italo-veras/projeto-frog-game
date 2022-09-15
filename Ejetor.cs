using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ejetor : MonoBehaviour
{
    public AudioSource audioSource;
    public Rigidbody meuRigidbody;
    public float valorFinal, valorInicial,velocidade,velocidadeVolta;
    public bool x, y, z,ligou;
    public bool playAudio;
    public float t;
    public float xAxis, yAxis, zAxis;

    // Start is called before the first frame update
    private void Awake()
    {
        meuRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }
    void Start()
    {
        xAxis = transform.rotation.eulerAngles.x;
        yAxis= transform.rotation.eulerAngles.y;
        zAxis = transform.rotation.eulerAngles.z;
    }
    public virtual void Update()
    {
        if (ligou)
            t += Time.deltaTime;
        if(t >= 2f)
        {
            Voltar();
            playAudio = true;
        }
    }

    public void Voltar()
    {
        if (x)
            meuRigidbody.DORotate(new Vector3(valorInicial, yAxis, zAxis), velocidadeVolta);
        else if (y)
            meuRigidbody.DORotate(new Vector3(xAxis, valorInicial, zAxis), velocidadeVolta);
        else if (z)
            meuRigidbody.DORotate(new Vector3(xAxis, yAxis, valorInicial), velocidadeVolta);

        ligou = false;
        t = 0f;
    }
    public void Ejetar()
    {
        ligou = true;
        if (x)
            meuRigidbody.DORotate(new Vector3(valorFinal, yAxis, zAxis), velocidade);
        else if (y)
            meuRigidbody.DORotate(new Vector3(xAxis, valorFinal, zAxis), velocidade);
        else if (z)
            meuRigidbody.DORotate(new Vector3(xAxis, yAxis, valorFinal), velocidade);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        bool player = collision.collider.gameObject.CompareTag("Player");

        if (player)
        {
            if (playAudio)
            {
                audioSource.Play();
                playAudio = false;
            }
            Ejetar();

        }
    }
}
