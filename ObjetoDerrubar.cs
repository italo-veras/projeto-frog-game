using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDerrubar : MonoBehaviour
{
    public float forcaImpacto;
    public Rigidbody objRigidbody;

    private void Awake()
    {
        objRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        objRigidbody.AddForce(Vector3.forward * 20, ForceMode.Impulse);
    }
}
