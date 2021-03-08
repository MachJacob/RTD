using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCam : MonoBehaviour
{
    public Camera cam;
    private Transform myTransform;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        cam = Camera.main;
    }


    void LateUpdate()
    {
        myTransform.forward = cam.transform.forward;
    }
}
