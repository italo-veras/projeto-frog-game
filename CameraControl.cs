using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera _camera;
    public CinemachineTransposer cameraOrbital;
    public CinemachineFreeLook cameraFree;
    public Vector3 posMouse;

    [Range(1,10)]
    public float sense;

    // Start is called before the first frame update
    void Start()
    {
        //_camera = GetComponent<CinemachineVirtualCamera>();
        //cameraOrbital = _camera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        cameraFree = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire2"))
        {
            cameraFree.m_XAxis.m_MaxSpeed = 70 * sense;
            cameraFree.m_YAxis.m_MaxSpeed = 5 * sense;
        }
        else
        {
            cameraFree.m_XAxis.m_MaxSpeed = 0;
            cameraFree.m_YAxis.m_MaxSpeed = 0;
        }
    }
}
