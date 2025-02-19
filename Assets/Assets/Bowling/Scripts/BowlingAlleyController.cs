using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class BowlingAlleyController : MonoBehaviour
{
    [SerializeField] bool sandboxMode;
    public GameObject pins;
    public int numberOfPins;
    public TextMeshPro scoreDisplay;
    public BallBoxEvent ballBox;
    UnityEngine.Vector3 ballPosition;
    public GameObject bowlingBall;

    Dictionary<int,UnityEngine.Vector3> pinsPosition;
    Dictionary<int,UnityEngine.Quaternion> pinsRotation;

    public delegate void ScoreEvent(int points);
    public ScoreEvent scoreEvent;
    bool wasHit;

    void savePinsPositions(){
        for(int i = 0; i<numberOfPins;i++){
            Transform child = pins.transform.GetChild(i);

            pinsPosition.Add(i,child.position);
            pinsRotation.Add(i,child.rotation);
            
        }
    }
    void setPinsPositions(){
        for(int i = 0; i<numberOfPins;i++){
            Transform child = pins.transform.GetChild(i);
            child.position = pinsPosition[i];
            child.rotation = pinsRotation[i];
        }
    }
   int countFallenPins() { 
    int counter = 0;
    float fallenThreshold = 0.7f;

    for (int i = 0; i < numberOfPins; i++) {
        Transform child = pins.transform.GetChild(i);
        float dotProduct = UnityEngine.Vector3.Dot(child.up, UnityEngine.Vector3.up);
        
        if (dotProduct < fallenThreshold) {
            counter++;
        }
    }
    
    Debug.Log("Fallen pins: " + counter);
    return counter;
}
    void Reset(){
        setPinsPositions();
    }
    void Start(){
        wasHit = false;
        pinsPosition = new Dictionary<int,UnityEngine.Vector3>();
        pinsRotation = new Dictionary<int,UnityEngine.Quaternion>();
        numberOfPins = pins.transform.childCount;
        ballPosition = bowlingBall.transform.position;
        savePinsPositions();
        ballBox.resetEvent += ResetAlley;
        ballBox.countPoints += CountPoints;
        
    }
    void ResetAlley(){
        bowlingBall.transform.position = ballPosition;
        scoreDisplay.text = "0";
        if(wasHit){
            setPinsPositions();
            wasHit = false;
        }
        else{
            wasHit = true;
        }
    }
    void CountPoints(){
        int points = countFallenPins();
        if(scoreDisplay != null){
        scoreDisplay.text = $"{points}";
        }
        if(scoreEvent != null){
            scoreEvent.Invoke(points);
        }

    }
    void Update(){
    }
}
