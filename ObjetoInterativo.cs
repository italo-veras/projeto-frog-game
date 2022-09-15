using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjetoInterativo : MonoBehaviour
{
    
    [Header("Qual a função")]
    [Tooltip("Rotaciona o objeto na direção escolhida, para o ângulo conforme o valor final e a velocidade")]
    public bool ejetar;
    [Tooltip("Move o objeto na direção escolhida, para a posição conforme o valor final e a velocidade")]
    public bool sair;
    [Tooltip("Rotaciona o objeto na direção escolhida, para o angulo conforme o valor final e a velocidade, na volta conforme a velocidade de rotação *iniciar o objeto em 0*")]
    public bool rotacionar180Loop;
    public bool rotacionar360Loop; 
    public bool moverLoop;

    [Space (1)]
    [Header("Qual a direção")]
    public bool x; public bool y; public bool z;

    [Space]
    [Header("Qual Valores")]
    public float valorFinal;
    public float velocidade;
    public float velocidadeRotacaoLoop;

    [Space]
    [Header("Atributos")]
    public Rigidbody meuRigidbody;

    [Space]
    [Header("Controle")]
    public bool d;
    public bool e;
    public bool b;
    public Transform[] caminho;
    public Vector3[] posicao;
    public Vector3 rotacao;
    public Vector3 r;
    public Vector3 posInicial;
    Quaternion rotacaoDelta;


    // Start is called before the first frame update
    void Awake()
    {
        meuRigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        posInicial = transform.position;
        // if (rotacionarLoop)
        //    StartCoroutine(RotacionarLoop());
        //if (andar)
        //  meuRigidbody.DOLocalPath(posicao, velocidade, PathType.CatmullRom, PathMode.Full3D, 10, null);
        if(x)
            rotacao = new Vector3(valorFinal, 0, 0);
        if (y)
            rotacao = new Vector3(0, valorFinal, 0);
        if (z)
            rotacao = new Vector3(0, 0, valorFinal);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rotacaoDelta = Quaternion.Euler(rotacao * Time.deltaTime);

    }
    void Update()
    {

        if (rotacionar180Loop)
            Rotacionar180Loop(); 
        else if (rotacionar360Loop)
            Rotacionar360Loop();
        else if (moverLoop)
            MoverLoop();

        if (b)
            meuRigidbody.rotation = Quaternion.Euler(0,0,90);
    }
    private void OnCollisionEnter(Collision collision)
    {
        bool player = collision.collider.gameObject.CompareTag("Player");

        if (player && ejetar)
            Rotacionar();
        else if (player && sair)
            Mover();
    }
    public void Rotacionar() 
    {
        if (x)
            meuRigidbody.DORotate(new Vector3(valorFinal, 0, 0), velocidade);
        else if (y)
            meuRigidbody.DORotate(new Vector3(0, valorFinal, 0), velocidade);
        else if (z)
            meuRigidbody.DORotate(new Vector3(0, 0, valorFinal), velocidade);
    }
    public void Mover() 
    {
        if (x)
            meuRigidbody.DOMove(new Vector3(valorFinal, 0, 0), velocidade);
        else if (y)
            meuRigidbody.DOMove(new Vector3(0, valorFinal, 0), velocidade);
        else if (z)
            meuRigidbody.DOMove(new Vector3(0, 0, valorFinal), velocidade);
    }
    public void MoverLoop()
    {
       
        if (x)
        {
            if (transform.position.x == posInicial.x)
            {
                meuRigidbody.DOMove(new Vector3(valorFinal, transform.position.y, transform.position.z), velocidade);
            }
            else if(transform.position.x == valorFinal)
            {
                meuRigidbody.DOMove(new Vector3(posInicial.x, transform.position.y, transform.position.z), velocidade);
            }
        }
        else if (y)
        {
            if (transform.position.y == posInicial.y)
            {
                meuRigidbody.DOMove(new Vector3(transform.position.x, valorFinal, transform.position.z), velocidade);
            }
            else if (transform.position.y == valorFinal)
            {
                meuRigidbody.DOMove(new Vector3(transform.position.x, posInicial.y, transform.position.z), velocidade);
            }
        }
        else if (z)
        {
            if (transform.position.z == posInicial.z)
            {
                meuRigidbody.DOMove(new Vector3(transform.position.x, transform.position.y, valorFinal), velocidade);
            }
            else if (transform.position.z == valorFinal)
            {
                meuRigidbody.DOMove(new Vector3(transform.position.x, transform.position.y, posInicial.z), velocidade);
            }
        }

    }
    public void Rotacionar180Loop()
    {
        if (x)
        {
            if (transform.eulerAngles.x == 90f)
            {
                meuRigidbody.DORotate(Vector3.zero, velocidade, RotateMode.FastBeyond360);
                e = false;
                d = true;
            }
            else if (transform.eulerAngles.x == 0 && e && !d)
            {
                meuRigidbody.DORotate(Vector3.right * valorFinal, velocidade, RotateMode.FastBeyond360);

            }
            else if (transform.eulerAngles.x == 0 && !e && d)
            {
                meuRigidbody.DORotate(Vector3.right * -valorFinal, velocidade, RotateMode.FastBeyond360);

            }
            else if (transform.eulerAngles.x >= 270f)
            {
                meuRigidbody.rotation = Quaternion.RotateTowards(meuRigidbody.rotation, Quaternion.Euler(0, 0, 0), velocidadeRotacaoLoop);
                e = true;
                d = false;
            }

        }
        else if (y)
        {
            if (transform.eulerAngles.y == 90f)
            {
                meuRigidbody.DORotate(Vector3.zero, velocidade, RotateMode.FastBeyond360);
                e = false;
                d = true;
            }
            else if (transform.eulerAngles.y == 0 && e && !d)
            {
                meuRigidbody.DORotate(Vector3.up * valorFinal, velocidade, RotateMode.FastBeyond360);

            }
            else if (transform.eulerAngles.y == 0 && !e && d)
            {
                meuRigidbody.DORotate(Vector3.up * -valorFinal, velocidade, RotateMode.FastBeyond360);

            }
            else if (transform.eulerAngles.y >= 270f)
            {
                meuRigidbody.rotation = Quaternion.RotateTowards(meuRigidbody.rotation, Quaternion.Euler(0, 0, 0), velocidadeRotacaoLoop);
                e = true;
                d = false;
            }

        }
        else if (z)
        {
            if (transform.eulerAngles.z == 90f)
            {
                meuRigidbody.DORotate(Vector3.zero, velocidade, RotateMode.FastBeyond360);
                e = false;
                d = true;
            }
            else if (transform.eulerAngles.z == 0 && e && !d)
            {
                meuRigidbody.DORotate(Vector3.forward * valorFinal, velocidade, RotateMode.FastBeyond360);

            }
            else if (transform.eulerAngles.z == 0 && !e && d)
            {
                meuRigidbody.DORotate(Vector3.forward * -valorFinal, velocidade, RotateMode.FastBeyond360);

            }
            else if (transform.eulerAngles.z >= 270f)
            {
                meuRigidbody.rotation = Quaternion.RotateTowards(meuRigidbody.rotation, Quaternion.Euler(0, 0, 0), velocidadeRotacaoLoop);
                e = true;
                d = false;
            }

        }
    }
    public void Rotacionar360Loop()
    {
        if (x)
            meuRigidbody.MoveRotation(meuRigidbody.rotation * rotacaoDelta);
        else if (y)
            meuRigidbody.MoveRotation(meuRigidbody.rotation * rotacaoDelta);
        else if (z)
            meuRigidbody.MoveRotation(meuRigidbody.rotation * rotacaoDelta);
    }
}
