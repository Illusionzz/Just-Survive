using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MansionDoorOpen : MonoBehaviour
{
    public float theDistance;
    public static bool isOpen = false;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject extraCross;

    [Header ("Door")]
    public GameObject door;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public static GameObject doorOpenTrigger;
    public GameObject openTrigger;

    public AudioSource creekSound;

    void Start()
    {
        doorOpenTrigger = openTrigger;

        doorOpenTrigger.SetActive(true);
    }
    
    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;
    }

    void OnMouseOver()
    {
        if (theDistance <= 2) {
            actionText.GetComponent<Text>().text = "Open Door";
            extraCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
            if (theDistance <= 2) {
                StartCoroutine(DoorOpen());
            }
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator DoorOpen() 
    {
        door.GetComponentInChildren<BoxCollider>().enabled = false;
        actionDisplay.SetActive(false);
        actionText.SetActive(false);

        leftDoor.GetComponent<Animation>().Play("LeftDoor");
        rightDoor.GetComponent<Animation>().Play("RightDoor");
        rightDoor.GetComponent<Animation>().Play("DoorLatch");
        creekSound.Play();

        yield return new WaitForSeconds(3.5f);
        door.GetComponentInChildren<BoxCollider>().enabled = true;
        leftDoor.GetComponent<Animation>().Play("LeftDoor");
        rightDoor.GetComponent<Animation>().Play("RightDoor");
        rightDoor.GetComponent<Animation>().Play("DoorLatch");
    }
}
