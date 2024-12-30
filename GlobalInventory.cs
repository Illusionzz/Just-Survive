using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public static bool isGrabbed = false;
    public bool internalKey;

    void Update()
    {
        internalKey = isGrabbed;
    }
}
