using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class BallBoxEvent : MonoBehaviour
{
    bool wasHit;
    public delegate void ResetEvent();
    public ResetEvent resetEvent;
    public delegate void CountPointsEvent();
    public CountPointsEvent countPoints;
    bool isBallInPit;

    void Start(){
        isBallInPit = false;
        wasHit = false;
    }

    async void OnCollisionEnter(Collision other) {
        Debug.Log("Cos wpadlo");
        if(other.gameObject.tag == "BowlingBall" && !isBallInPit){
            Debug.Log("Kula wpadla");
            isBallInPit = true;
            await GameFinishedAsync();
        }
    }

    async Task GameFinishedAsync(){
         await Task.Delay(3000);
         countPoints?.Invoke();
         if(wasHit){
            await Task.Delay(3000);
            resetEvent?.Invoke();
            wasHit = false;
         }
         else{
            wasHit = true;
         }
         await Task.Delay(1000);
         isBallInPit = false;
    }
}
