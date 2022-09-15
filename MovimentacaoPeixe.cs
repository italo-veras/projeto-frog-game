using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoPeixe : MonoBehaviour
{
    public Transform spawn;
    public float velocidade;
    public float rotacaoY;
    public float t;
    public Vector3 dir;
    public float cd;
    public Rigidbody meuRB;
    public bool lesgo;


    private void Awake()
    {
        meuRB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!lesgo)
            t += Time.deltaTime;

        Pular();
        Resetar();
        
    }
    
    public void Pular()
    {
        if (lesgo)
        {
            meuRB.isKinematic = false;
            meuRB.AddRelativeForce(dir * velocidade, ForceMode.Impulse);
            lesgo = false;
        }
    }
    public void Resetar()
    {
        if (t >= cd)
        {
            meuRB.isKinematic = true;
            meuRB.velocity = Vector3.zero;
            meuRB.angularVelocity = Vector3.zero;
            transform.SetPositionAndRotation(spawn.position, Quaternion.Euler(0, rotacaoY, 0));
            lesgo = true;
            t = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Derruba"))
        {
            Resetar();
        }
        
    }
}
