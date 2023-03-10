using System.Collections;
using System.Collections.Generic;
using EnimiesFactory;
using UnityEngine;

public class FallenBompEnemyController : MonoBehaviour
{
    public FallenBomp fb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="ground") {
            //transform.GetChild(0).gameObject.SetActive(true);
            //Destroy(gameObject, 1);
            fb.ShowParicle();
        }
    }
}
