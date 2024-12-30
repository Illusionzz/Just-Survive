using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public float moveSpeed;
    private float startPos;

    public Vector3 targetPos;

    public GameObject enemy;

    private Rigidbody rig;

    void Update()
    {
        Move();
    }

    void Move() 
    {
        enemy.GetComponent<Animation>().Play("Z_Walk_InPlace");
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed);
    }
}
