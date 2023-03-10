using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Collecters : MonoBehaviour
{
    public bool isActive = false;
    private NavMeshAgent agent;
    public Transform mainPlayerGroup;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (isActive) {
            agent.SetDestination(mainPlayerGroup.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !isActive)
        {
            //this.tag = "Player";
            isActive = true;
            Debug.Log("Ahmeds");


        }
    }
}
