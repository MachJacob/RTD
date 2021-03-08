using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Exponential boost factor on translation, controllable by mouse wheel.")]
    public float boost = 3.5f;

    [Tooltip("Time it takes to interpolate camera position 99% of the way to the target."), Range(0.001f, 1f)]
    public float positionLerpTime = 0.2f;
    private Transform myTransform;
    private Vector3 direction;
    private Vector2 dirMod;
    // Start is called before the first frame update
    void Awake()
    {
        myTransform = GetComponent<Transform>();
        direction = new Vector3();
        dirMod = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    direction += myTransform.forward;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    direction -= myTransform.forward;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    direction -= myTransform.right;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    direction += myTransform.right;
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    direction += Vector3.down;
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    direction += Vector3.up;
        //}

        direction += myTransform.forward * dirMod.y;
        direction += myTransform.right * dirMod.x;
        direction.y = 0;


        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    direction *= 10.0f;
        //}

        // Modify movement by a boost factor (defined in Inspector and modified in play mode through the mouse scroll wheel)
        //boost += Input.mouseScrollDelta.y * 0.2f;
        direction *= Mathf.Pow(2.0f, boost);

        myTransform.Translate(direction * Time.deltaTime, Space.World);
    }

    public void MoveWASD(InputAction.CallbackContext context)
    {
        dirMod = context.ReadValue<Vector2>();
    }
}
