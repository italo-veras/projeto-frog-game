using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpurradorMovel : MonoBehaviour
{

    public Transform spawn;
    public Rigidbody rb;
    public float velocidade;

    public float t;
    public float t2;
    public float delay;
    public float tempoReset;
    public bool ativado;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        transform.position = spawn.position;


    }
    // Update is called once per frame
    void Update()
    {
        t2 += Time.deltaTime; 

        if(t2 >= delay)
        {
            t2 = 20f;
            rb.MovePosition(rb.position + (Vector3.right * velocidade));

            t += Time.deltaTime;

            if (t >= tempoReset)
            {
                t = 0;
                transform.position = spawn.position;
            }

        }

    }
}
