using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilSeguir : MonoBehaviour
{
    public Sapo sapoo;
    public controladorProjetil controlador;
    public bool ativar;
    public bool moverNoAlvo;
    public Rigidbody meuRb;
    public Transform posicaoAlvo;
    public Vector3 spawnPoint;
    public Vector3 direcao;
    public float velocidade , velocidadeRotacao;
    public float t;
    public float CD;

    private void Awake()
    {
    }
    void Start()
    {
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moverNoAlvo && controlador.ativar)
        {
            t = 0;

            direcao = new Vector3(posicaoAlvo.position.x, posicaoAlvo.position.y+.4f, posicaoAlvo.position.z) - meuRb.position;
            direcao = direcao.normalized;

            meuRb.rotation = Quaternion.Lerp(meuRb.rotation, Quaternion.LookRotation(direcao), velocidadeRotacao * Time.deltaTime);
            meuRb.MovePosition(meuRb.position + direcao * Time.deltaTime * velocidade);
           //meuRb.AddRelativeForce(Time.deltaTime * velocidade * Vector3.forward, ForceMode.VelocityChange);
        }
        else
            t += Time.deltaTime;


        if (t > CD)
        {
            transform.position = spawnPoint;
            meuRb.velocity = Vector3.zero;
            meuRb.angularVelocity = Vector3.zero;
            moverNoAlvo = true;

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        moverNoAlvo = false;
        meuRb.AddRelativeForce(velocidade * 2 * Vector3.forward, ForceMode.VelocityChange);

    }
}
