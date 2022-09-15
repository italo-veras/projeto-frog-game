using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSistem : MonoBehaviour
{
    [SerializeField]
    public static Transform spawnPoint;
    public Spawn[] checkpoint;
    public Sapo sapo;
    public bool morreu;
    public int contador;

    private void Awake()
    {
        spawnPoint = checkpoint[0].gameObject.transform;
    }
    void Start()
    {
        foreach (Spawn sp in checkpoint)
        {
            sp.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(sapo.contadorSpawn == 2)
        {
            sapo.checkPointPosition = Vector3.zero;

            foreach (Spawn sp in checkpoint)
            {
                
                sp.gameObject.SetActive(true);
            }

            sapo.contadorSpawn = 0;
        }

    }
}
