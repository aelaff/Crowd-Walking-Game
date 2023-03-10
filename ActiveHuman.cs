using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActiveHuman : MonoBehaviour
{
    
    public float speed = 1;
    bool isCharActive = false;
    private Vector3 velocity = Vector3.zero;
    private Transform followerOBJ;
    NavMeshAgent nv;

    private void Start()
    {
        followerOBJ = GameManager.Instance.followerOBJ;
        nv = GetComponent<NavMeshAgent>();
    }
    public void JoinToCharacters() {
        isCharActive = true;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isCharActive) {
            transform.rotation = Quaternion.LookRotation(followerOBJ.GetComponent<Rigidbody>().velocity);
            //transform.position = Vector3.SmoothDamp(transform.position,GameManager.Instance.followerOBJ.position-new Vector3(0.5f,.5f,.5f), ref velocity, speed * Time.deltaTime);
            nv.SetDestination(followerOBJ.transform.position);

            if (!GameManager.Instance.isPlayerRunning)
            {
                GetComponent<Animator>().SetFloat("run", 0);
            }
            else
            {
                GetComponent<Animator>().SetFloat("run", 1f);

            }
        }
        

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "char")
        {
            col.GetComponent<ActiveHuman>().JoinToCharacters();
        }
    }
}
