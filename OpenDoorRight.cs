using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoorRight : MonoBehaviour
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

                door.GetComponent<Animation>().Play("RightDoor");
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
