using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public static bool readyJump = false;

    public GameObject jumpTrigger;

    void OnTriggerEnter()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        readyJump = true;
    }
}
