using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabController : MonoBehaviour
{

    // Ideas from NecMesh tutorial links posted on piazza
    public Transform target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            agent.enabled = !(agent.enabled);
        }
        if (agent.enabled)
        {
            agent.SetDestination(target.position + (new Vector3(Random.Range(-2F, 2F), Random.Range(-2F, 2F), Random.Range(-2F, 2F))));

        }
    }
}
