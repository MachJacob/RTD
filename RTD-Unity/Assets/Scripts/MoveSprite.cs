using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MoveSprite : MonoBehaviour
{
    public Camera main;
    public NavMeshAgent agent;
    public InputMaster controls;

    public void PathTo(InputAction.CallbackContext context) //mouse pathing
    {
        if (!context.performed) return;
        Vector2 mousePos = Mouse.current.position.ReadValue(); //main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        Ray ray = main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    public void SetDest(Vector3 _dest)
    {
        agent.SetDestination(_dest);
    }
}
