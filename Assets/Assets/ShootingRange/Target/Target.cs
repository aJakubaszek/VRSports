using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int healthPoints;

    void Start(){
        if(healthPoints == 0){
            healthPoints = 1;
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.transform.tag == "Bullet"){
            healthPoints--;
            if(healthPoints < 1){
                Destroy(gameObject);
            }
        }
    }
}
