using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapoAudioController : MonoBehaviour
{
    public Sapo sapo;
    public AudioSource audioSource;
    public AudioClip[] audioContato;
    public AudioClip[] audioMorte;
    public AudioClip[] audioSapo;
    public bool b;

    private void Update()
    {
        if (Input.GetButton("Use") && !sapo.morto)
        {
            audioSource.clip = audioSapo[Random.Range(0, 6)];
            if (!audioSource.isPlaying)
                audioSource.Play();
        }

        if (sapo.morto && sapo.somMorte)
        {
            audioSource.clip = audioMorte[Random.Range(0, 2)];
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                sapo.somMorte = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool contato = collision.collider.gameObject.CompareTag("Chao");
        bool contato2 = collision.collider.gameObject.CompareTag("Derruba");

        if (contato && !sapo.morto)
        {
            audioSource.clip = audioContato[Random.Range(0, 4   )];
            if (!audioSource.isPlaying)
                audioSource.Play();
        }

        

    }

}
