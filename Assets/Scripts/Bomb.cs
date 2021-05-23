using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody rigidBody = null;

    void Awake(){
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody>();
        }
    }



    void OnCollisionEnter(Collision collision){
        rigidBody.velocity = new Vector3(0,0,0);
        rigidBody.angularVelocity = new Vector3(0,0,0);
        BombSpawner.Instance.ReturnBombToBombPool(this);
    }
}
