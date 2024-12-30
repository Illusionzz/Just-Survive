using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoorLeft : MonoBehaviour
{
    [Header("Door Stuff")]
    public GameObject doorTrigger;
    public GameObject door;

    [Header("UI")]
    public GameObject extraCross;
    public GameObject actionDisplay;
    public GameObject actionText;

    public float theDistance;

    public AudioSource doorOpen;

    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;

        if (Input.GetButton("Action")) {
            
        }

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
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);

                door.GetComponent<Animation>().Play("LeftDoor");
                doorOpen.Play();
            }
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
