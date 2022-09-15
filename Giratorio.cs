using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giratorio : MonoBehaviour
{
    Quaternion rotacaoDelta;
    public Vector3 rotacao;
    public float valorFinal;
    public Rigidbody rb;

    public bool x, y, z;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (x)
            rotacao = new Vector3(valorFinal, 0, 0);
        if (y)
            rotacao = new Vector3(0, valorFinal, 0);
        if (z)
            rotacao = new Vector3(0, 0, valorFinal);
    }

    private void FixedUpdate()
    {
        rotacaoDelta = Quaternion.Euler(rotacao * Time.deltaTime);

    }
    // Update is called once per frame
    public virtual void Update()
    {
        Rotacionar360Loop();
    }

    public virtual void Rotacionar360Loop()
    {
        if (x)
            rb.MoveRotation(rb.rotation * rotacaoDelta);
        else if (y)
            rb.MoveRotation(rb.rotation * rotacaoDelta);
        else if (z)
            rb.MoveRotation(rb.rotation * rotacaoDelta);
    }
}
