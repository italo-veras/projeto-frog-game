using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBarco : MonoBehaviour
{
    public Sapo saapo;
    public Vector3 spawn;
    public Quaternion rotacaoInicial;
    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;
        rotacaoInicial = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (saapo.morto)
        {
            transform.position = spawn;
        }
    }
}
