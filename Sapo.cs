using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapo : MonoBehaviour
{
    public Vector3 spawnPosition;
    public Vector3 checkPointPosition;
    public Vector3 direcaoForca;
    public RagdollController RagdollController;
    public Collider meuCollider;
    public Rigidbody meuRigidbody;
    public Transform ondeIr;
    public Transform corpoSapo;
    public float tempoForca;
    public float mult;
    public float tempoReset;
    public float tempoControladorReset;
    public float contadorSpawn;
    public float contadorMortes, velocidadeRotacaoTecladoSla;
    public DirecaoMouse dir;

    public Animator anim;
    public ParticleSystem sangueVfx;

    public float velocidadeY;
    public Vector3 gravidade;
    public bool taNoChao,ajeitar,morto,somMorte;
    public LayerMask maskChao;
    public float xAxis;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        meuCollider = GetComponent<Collider>();
        meuRigidbody = GetComponent<Rigidbody>();
        RagdollController = GetComponent<RagdollController>();
        velocidadeY = -10f;
    }
    private void Start()
    {
        spawnPosition = SpawnSistem.spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (!morto)
        {
            if (taNoChao && Input.GetButton("Jump"))
            {
                if(tempoForca <= 1f)
                tempoForca += Time.deltaTime;
            }
            if (Input.GetButtonUp("Jump"))
            {
                anim.SetTrigger("Jump");
                ajeitar = true;
                tempoReset = 0;
                StopCoroutine(Ajeitar());
                meuRigidbody.AddRelativeForce(new Vector3(0,1,1) * tempoForca * 10, ForceMode.Impulse);
                tempoForca = 0;
            }

            if (taNoChao && Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Ajeitar());
            }

            xAxis = Input.GetAxis("Horizontal");
            anim.SetFloat("xAxis", xAxis);
            transform.Rotate(new Vector3(0, xAxis * velocidadeRotacaoTecladoSla, 0));
        }
    }

    private void FixedUpdate()
    {
        taNoChao = Physics.CheckSphere(transform.position, .8f, maskChao);
        if (taNoChao)
        {
            //anim.SetTrigger("Idle");
            gravidade.y = -5f;
        }
        gravidade.y += velocidadeY * Time.deltaTime;
        meuRigidbody.velocity += gravidade * Time.deltaTime;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Spawn"))
        {
            checkPointPosition = collision.collider.gameObject.transform.position;
            collision.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!morto)
            other.GetComponent<controladorProjetil>().ativar = true;
        else
            other.GetComponent<controladorProjetil>().ativar = false;

    }
    private void OnTriggerExit(Collider other)
    {

    }
    public void AtivarParticulas()
    {
        sangueVfx.transform.position = new Vector3(transform.position.x, transform.position.y + .2f, transform.position.z);
        if (!sangueVfx.isPlaying)
            sangueVfx.Play();
    }
    public IEnumerator Ajeitar()
    {
        while(transform.rotation != Quaternion.Euler(0, 0, 0))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 0), 50f);
            corpoSapo.localPosition = Vector3.zero;
            corpoSapo.localRotation = Quaternion.Euler(270.1f, 0f,0f);
            yield return new WaitForSeconds(.01f);
            StopCoroutine(Ajeitar());
        }
        
    }
    public IEnumerator Morrer()
    {
        if (!morto)
        {
            morto = true;
            somMorte = true;
            if (checkPointPosition != Vector3.zero)
                contadorSpawn++;
            contadorMortes++;
        }

        yield return new WaitForSeconds(5f);

        RagdollController.DesativarRagdoll();

        if (checkPointPosition == Vector3.zero)
            transform.position = new Vector3(spawnPosition.x, spawnPosition.y + 1, spawnPosition.z);
        else
            transform.position = new Vector3(checkPointPosition.x, checkPointPosition.y + 1, checkPointPosition.z);

        StartCoroutine(Ajeitar());
        morto = false;
        StopCoroutine(Morrer());

    }


}
