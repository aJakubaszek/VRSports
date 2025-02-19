using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public int healthPoints = 1;
    public float speed = 2.0f;
    public float distance = 5.0f; 

    private bool moveOnXAxis;
    private float startPosition;
    private int direction = 1; 

    void Start()
    {
        if (healthPoints == 0){
            healthPoints = 1;
        }

        moveOnXAxis = Random.Range(0, 2) == 0;

        if (moveOnXAxis){
            startPosition = transform.position.x;
        }
        else{
            startPosition = transform.position.y;
        }
    }

    void Update(){
        // Move the target
        MoveTarget();
    }

    void MoveTarget(){
        if (moveOnXAxis){
            float newX = startPosition + Mathf.PingPong(Time.time * speed, distance) * direction;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        else{
            float newY = startPosition + Mathf.PingPong(Time.time * speed, distance) * direction;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.transform.tag == "Bullet"){
            healthPoints--;
            if (healthPoints < 1){
                Destroy(gameObject);
            }
        }
    }
}
