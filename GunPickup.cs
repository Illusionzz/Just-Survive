using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPickup : MonoBehaviour
{
    public float theDistance;
    public static bool isEnabled = false;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject fakePistol;
    public GameObject realPistol;
    public GameObject guideArrow;
    public GameObject extraCross;
    public GameObject jumpScareTrigger;
    
    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;
        DontDestroyOnLoad(this.gameObject);
    }

    void OnMouseOver()
    {
        if (theDistance <= 2) {
            extraCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);

            actionText.GetComponent<Text>().text = "Pick up pistol";
        }
        if (Input.GetButtonDown("Action"))
            if (theDistance <= 2) {
                this.GetComponent<BoxCollider>().enabled = false;

                isEnabled = true;

                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                fakePistol.SetActive(false);
                realPistol.SetActive(true);
                extraCross.SetActive(false);
                guideArrow.SetActive(false);
                jumpScareTrigger.SetActive(true);
            }
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
