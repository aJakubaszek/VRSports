using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BowlingController : MonoBehaviour
{
    [SerializeField] BowlingAlleyController alley;
    [SerializeField] TextMeshPro throwRow;
    [SerializeField] TextMeshPro sumRow;
    [SerializeField] TextMeshPro nameText; //zmienic na GetPlayerName
    [SerializeField] string playerName;
    int turnCount;
    int currentPoints;
    List<Boolean> strikesList;
    Boolean spareTurn;
    Boolean lastThrow;
    int lastPoints;
    int multiplier;

    void Awake(){
        Restart();
        alley.scoreEvent += SummarizeThrow;
    }
    void OnDestroy(){
        alley.scoreEvent -= SummarizeThrow;
    }


    public void Restart(){
        multiplier = 1;
        turnCount = 0;
        currentPoints = 0;
        strikesList = new List<Boolean>();
        spareTurn = false;
        lastThrow = false;
        throwRow.text = "";
        sumRow.text = "";
        nameText.text = playerName;
    }
    void UpdateMultiplier(){
        multiplier = 1;
        if(turnCount > 2){
            if(strikesList[turnCount-2]){
                multiplier++;
            }
        }
        if(turnCount > 1){
            if(strikesList[turnCount-1] || spareTurn){
                multiplier++;
            }
        }
    }
    int NewThrowScore(int points){
        if(points<10){
            if(lastPoints + points > 9){
                return 10*multiplier;
            }
            else{
                return points*multiplier;
            }
        }
        return 10*multiplier; // spakować w 1 ifa mniej
    }
    string NewThrowString(int points){
        if(points<10){
            if(lastPoints + points > 9){
                return "/";
            }
            else{
                return (points*multiplier).ToString();
            }
        }
        else{
            lastThrow = true;
            return "XX";
        }
    }
    
    public void SummarizeThrow(int points){ //ma zwracać czy resetować tor
    UpdateMultiplier();
    int thisRoundPoints = NewThrowScore(points);
        if(turnCount<9){
            throwRow.text += NewThrowString(points) + " ";
            currentPoints += thisRoundPoints;
            if(lastThrow){
                throwRow.text += "   ";
                sumRow.text += currentPoints.ToString("D3") + "  ";
                lastThrow = false;
                turnCount++;
            }
            else{
                lastThrow = true;
            }
        }
    }
}
