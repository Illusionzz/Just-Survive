using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPickup : MonoBehaviour
{
    public float theDistance;

    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject extraCross;
    public GameObject ammoBox;
    public GameObject ammoPanel;

    public GameObject b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12;

    void Update()
    {
        theDistance = PlayerCasting.distFromTarget;
        BulletCount();
    }

    void OnMouseOver()
    {
        if (theDistance <= 2.5f) {
            extraCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);

            actionText.GetComponent<Text>().text = "Pick up ammo";
        }

        if (Input.GetButtonDown("Action")) {
            if (theDistance <= 2.5f) {
                this.GetComponent<BoxCollider>().enabled = false;

                extraCross.SetActive(true);
                actionDisplay.SetActive(true);
                actionText.SetActive(true);
                ammoBox.SetActive(false);
                ammoPanel.SetActive(true);
                GlobalAmmo.ammoCount += 6;
                GlobalAmmo.SaveAmmo();
            }
        }
    }

    void BulletCount() 
    {
        if (GlobalAmmo.ammoCount == 1)
            b1.SetActive(true);
            b2.SetActive(false);
            b3.SetActive(false);
            b4.SetActive(false);
            b5.SetActive(false);
            b6.SetActive(false);
            b7.SetActive(false);
            b8.SetActive(false);
            b9.SetActive(false);
            b10.SetActive(false);
            b11.SetActive(false);
            b12.SetActive(false);
        if (GlobalAmmo.ammoCount == 2) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(false);
            b4.SetActive(false);
            b5.SetActive(false);
            b6.SetActive(false);
            b7.SetActive(false);
            b8.SetActive(false);
            b9.SetActive(false);
            b10.SetActive(false);
            b11.SetActive(false);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 3) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(false);
            b5.SetActive(false);
            b6.SetActive(false);
            b7.SetActive(false);
            b8.SetActive(false);
            b9.SetActive(false);
            b10.SetActive(false);
            b11.SetActive(false);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 4) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(false);
            b6.SetActive(false);
            b7.SetActive(false);
            b8.SetActive(false);
            b9.SetActive(false);
            b10.SetActive(false);
            b11.SetActive(false);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 5) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(true);
            b6.SetActive(false);
            b7.SetActive(false);
            b8.SetActive(false);
            b9.SetActive(false);
            b10.SetActive(false);
            b11.SetActive(false);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 6) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(true);
            b6.SetActive(true);
            b7.SetActive(false);
            b8.SetActive(false);
            b9.SetActive(false);
            b10.SetActive(false);
            b11.SetActive(false);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 7) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(true);
            b6.SetActive(true);
            b7.SetActive(true);
            b8.SetActive(false);
            b9.SetActive(false);
            b10.SetActive(false);
            b11.SetActive(false);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 8) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(true);
            b6.SetActive(true);
            b7.SetActive(true);
            b8.SetActive(true);
            b9.SetActive(false);
            b10.SetActive(false);
            b11.SetActive(false);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 9) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(true);
            b6.SetActive(true);
            b7.SetActive(true);
            b8.SetActive(true);
            b9.SetActive(true);
            b10.SetActive(false);
            b11.SetActive(false);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 10) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(true);
            b6.SetActive(true);
            b7.SetActive(true);
            b8.SetActive(true);
            b9.SetActive(true);
            b10.SetActive(true);
            b11.SetActive(false);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 11) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(true);
            b6.SetActive(true);
            b7.SetActive(true);
            b8.SetActive(true);
            b9.SetActive(true);
            b10.SetActive(true);
            b11.SetActive(true);
            b12.SetActive(false);
        }
        if (GlobalAmmo.ammoCount == 12) {
            b1.SetActive(true);
            b2.SetActive(true);
            b3.SetActive(true);
            b4.SetActive(true);
            b5.SetActive(true);
            b6.SetActive(true);
            b7.SetActive(true);
            b8.SetActive(true);
            b9.SetActive(true);
            b10.SetActive(true);
            b11.SetActive(true);
            b12.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
