using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirecaoMouse : MonoBehaviour
{
    public Vector3 MousePos;
    public  Vector3 posInicial;
    public  Vector3 posFinal;
    public  Vector3 direcao;

    public Ray raio;
    public LayerMask sapoLayer;
    public bool raioCheck;
    public bool arrastarCheck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
        MousePos.z = Camera.main.nearClipPlane;

        if ( /*raioCheck && */Input.GetButtonDown("Use"))
        {
            Debug.Log("Clicou");
            posInicial = Camera.main.ScreenToWorldPoint(MousePos);
            arrastarCheck = true;
        }

        if (/*arrastarCheck && */Input.GetButtonUp("Use"))
        {
            posFinal = Camera.main.ScreenToWorldPoint(MousePos);
            Debug.Log("Parou");
            direcao = posInicial - posFinal;
            arrastarCheck = false;
        }

        //Debug.Log(MousePos);
    }
    private void FixedUpdate()
    {
        raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        raioCheck = Physics.Raycast(raio, out RaycastHit hit, 1000, sapoLayer);

        
    }
}
