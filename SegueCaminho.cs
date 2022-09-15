using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SegueCaminho : MonoBehaviour
{
    public Rigidbody meuRb;
    public Transform[] caminhoTransform;
    public Vector3[] caminho;
    public bool a;
    public bool vai;
    public float t;
    public float duracao;
    public float delay;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < caminhoTransform.Length; i++)
        {
            caminho[i] = caminhoTransform[i].position;
        }

    }
    private void Start()
    {
        meuRb.DOPath(caminho, 5f, PathType.Linear, PathMode.Full3D, 1, Color.red);
        Debug.Log("AAAAAAAAAAAAAA");
    }
    private void Update()
    {
        t += Time.deltaTime;
        if (t > delay && vai)
        {
            meuRb.DOPath(caminho, duracao, PathType.Linear, PathMode.Full3D, 1, Color.red);
            vai = false;
            t = 0;
        }
        else
            vai = true;
    }
}
