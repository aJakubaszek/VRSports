using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioSource sound;
    void OnCollisionEnter(Collision collision){
        if(collision.collider.gameObject.tag == "BowlingBall"){
            if(sound!=null){
                sound.Play();
            }
        }
    }
}
