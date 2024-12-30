using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int ammoCount;
    public int ammo;
    public static int maxAmmo;
    public static int leftOverAmmo;

    public GameObject ammoDisplay;

    void Start()
    {
        if (!PlayerPrefs.HasKey("ammo") && !PlayerPrefs.HasKey("maxAmmo")) {
            PlayerPrefs.SetInt("ammo", ammoCount);
            PlayerPrefs.SetInt("maxAmmo", maxAmmo);
            LoadAmmo();
        }
        else {
            LoadAmmo();
        }
    }
    
    void Update()
    {
        ammo = ammoCount;
        ammoDisplay.GetComponent<Text>().text = "" + ammoCount + "/ " + maxAmmo;

        if (ammoCount > 12) {
            leftOverAmmo = ammoCount;
            ammoCount = 12;
            maxAmmo = leftOverAmmo - ammoCount;
        }
    }

    public static void SaveAmmo() 
    {
        PlayerPrefs.SetInt("ammo", ammoCount);
        PlayerPrefs.SetInt("maxAmmo", maxAmmo);
    }

    public static void LoadAmmo() 
    {
        ammoCount = PlayerPrefs.GetInt("ammo", 0);
        maxAmmo = PlayerPrefs.GetInt("maxAmmo", 0);
    }
}
