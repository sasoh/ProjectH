using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navAgent = null;

    void InitializeComponents()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        Debug.Assert(navAgent != null, "Nav mesh agent component not set for player movement class.");
    }

    // Use this for initialization
    void Start()
    {
        InitializeComponents();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDirectionInput();
    }

    void CheckForDirectionInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(screenRay, out hit) == true)
            {
                navAgent.SetDestination(hit.point);
            }
        }
    }
}
