using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerDoorOpen : MonoBehaviour
{
    public static bool isOpen = false;

    public GameObject doorTrigger;
    public GameObject door;
    public GameObject stalker;

    public AudioSource doorCreek;

    void OnTriggerEnter()
    {
        stalker.GetComponent<BoxCollider>();
        this.GetComponent<BoxCollider>().enabled = false;
        door.GetComponent<Animation>().Play();
        doorCreek.Play();
        isOpen = true;
    }
}
