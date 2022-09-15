using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiDebug : MonoBehaviour
{
    public Sapo sapo;

    public Text rbVelocity;
    public Text forcaPulo;
    public Text segundos;
    public Text minutos;
    public Text hora;
    public Text Sapos;


    float t;
    float m;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        segundos.text = t.ToString("N0");

        if(t > 60f)
        {
            t = 0;
            m++;
            minutos.text = m.ToString("N0");
        }
        hora.text = "0";//t.ToString("N0");

        rbVelocity.text = sapo.meuRigidbody.velocity.magnitude.ToString();
        forcaPulo.text = sapo.tempoForca.ToString();
    }
}
