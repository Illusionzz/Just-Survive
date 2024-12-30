using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        StalkerAI.isStalking = true;
    }
}
