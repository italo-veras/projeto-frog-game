using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjetorTimer : Ejetor
{
    public float segundosCD;
    public float timer;
    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer > segundosCD)
        {
            Ejetar();
            t += Time.deltaTime;
        }
        if (t >= Random.Range(2f,5f))
        {
            timer = 0f;
            Voltar();
        }
    }


    public override void OnCollisionEnter(Collision collision)
    {
        //base.OnCollisionEnter(collision);
    }
}
