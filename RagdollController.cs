using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public SapoAudioController sapoAudioController;
    public Animator animator;
    public Rigidbody Rigidbody;
    public BoxCollider BoxCollider;
    public Sapo Sapo;

    public Collider[] CollidersFilhos;
    public Rigidbody[] RigidbodyFilhos;
    public Rigidbody colisao;

    public Vector3 posicaoNormal;
    public Quaternion rotacaoNormal;
    public bool ativo;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        BoxCollider = GetComponent<BoxCollider>();
        Sapo = GetComponent<Sapo>();

        CollidersFilhos = GetComponentsInChildren<Collider>();
        RigidbodyFilhos = GetComponentsInChildren<Rigidbody>();

    }
    void Start()
    {
        DesativarRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Sapo.meuRigidbody.velocity.y > 20)
          //  AtivarRagdoll();

        if (Input.GetKeyDown(KeyCode.H))
            DesativarRagdoll();
        else if (Input.GetKeyDown(KeyCode.G))
            AtivarRagdoll();

    }

    public void DesativarRagdoll()
    {
        ativo = false;
        foreach (var collider in CollidersFilhos)
        {
            collider.enabled = false;

        }
        foreach (var rigidbody in RigidbodyFilhos)
        {
            rigidbody.isKinematic = true;
        }

        animator.enabled = true;
        Rigidbody.isKinematic = false;
        BoxCollider.enabled = true;
        Sapo.enabled = true;
    }
    public void AtivarRagdoll()
    {
        ativo = true;
        foreach (var collider in CollidersFilhos)
        {
            Physics.IgnoreCollision(BoxCollider, collider);
            collider.enabled = true;
        }
        foreach (var rigidbody in RigidbodyFilhos)
        {
            if(colisao != null)
                rigidbody.velocity = colisao.velocity;

            rigidbody.velocity = Sapo.meuRigidbody.velocity;
            rigidbody.isKinematic = false;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        animator.enabled = false;
        //Rigidbody.isKinematic = true;
        //BoxCollider.enabled = false;
        //Sapo.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        colisao = collision.collider.gameObject.GetComponent<Rigidbody>();

        if (!Sapo.morto)
        {
            if (collision.collider.gameObject.CompareTag("Chao") && (Sapo.meuRigidbody.velocity.y < -30f || Sapo.meuRigidbody.velocity.x < -30f || Sapo.meuRigidbody.velocity.x > 30f || Sapo.meuRigidbody.velocity.z < -30f || Sapo.meuRigidbody.velocity.z > 30f))
            {
                AtivarRagdoll();
                StartCoroutine(Sapo.Morrer());
                Sapo.AtivarParticulas();
            }
            else if (collision.collider.gameObject.CompareTag("Derruba"))
            {
                AtivarRagdoll();
                Sapo.AtivarParticulas();
                StartCoroutine(Sapo.Morrer());

            }
        }
       
    }
}
