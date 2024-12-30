using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject gun;
    public GameObject muzzleFlash;

    public AudioSource gunFire;

    public bool isFiring = true;
    public float targetDist;
    public int damageAmount = 5;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GlobalAmmo.ammoCount >= 1) 
            if (isFiring == false && GunPickup.isEnabled == true) {
                GlobalAmmo.ammoCount--;
                GlobalAmmo.leftOverAmmo++;
                StartCoroutine(FiringPistol());
            }

        if (GlobalAmmo.ammoCount == 0 || Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
    }

    void Reload() 
    {
        if (GlobalAmmo.maxAmmo <= 12) {
            GlobalAmmo.ammoCount += GlobalAmmo.maxAmmo;
            GlobalAmmo.maxAmmo = 0;
        }
        else if (GlobalAmmo.maxAmmo > 12) {
            GlobalAmmo.maxAmmo -= GlobalAmmo.leftOverAmmo;
            GlobalAmmo.ammoCount = 12;
        }
    }

    IEnumerator FiringPistol() 
    {
        RaycastHit hit;
        isFiring = true;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
            targetDist = hit.distance;
            hit.transform.SendMessage("DamageZombie", damageAmount, SendMessageOptions.DontRequireReceiver);
        }

        gun.GetComponent<Animation>().Play("HandgunFire");
        muzzleFlash.SetActive(true);
        gunFire.Play();

        yield return new WaitForSeconds(0.4f);

        isFiring = false;

        muzzleFlash.SetActive(false);
        GlobalAmmo.SaveAmmo();
    }
}
