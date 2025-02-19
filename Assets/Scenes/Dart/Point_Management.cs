using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Point_Management : MonoBehaviour
{
    public static Point_Management instance;

    public TextMeshPro scoreboard;

    int points;
    int round;
    int target;
    int round_sum;
    int dart_count;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        NewGame();
        scoreboard.text = string.Empty;
    }

    public void NewGame()
    {
        points = 0;
        round = 1;
        if(TheGame.instance.gamemode==0) target = 301;
        else if (TheGame.instance.gamemode == 1) target = 501;
        else if (TheGame.instance.gamemode == 2) target = 701;
        round_sum = 0;
        dart_count = 0;
        scoreboard.text = "Round: " + round.ToString() + "\nPoints: " + (points + round_sum).ToString() + "\nTarget: " + target.ToString();
    }


    public void AddPoint(int amount)
    {
        if(points+round_sum+amount<target)
        {
            round_sum+= amount;
            scoreboard.text = "Round: " + round.ToString() + "\nPoints: " + (points+round_sum).ToString() + "\nTarget: " + target.ToString();
            dart_count++;
        }
        else//points overflow
        {
            round_sum = 0;
            dart_count = 0;
            NewRound();
        }

        if(dart_count==3)
        {
            points += round_sum;
            round_sum = 0;
            dart_count = 0;
            NewRound();
        }

    }

    public void NewRound()
    {
        round++;
        scoreboard.text = "Round: " + round.ToString() + "\nPoints: " + (points + round_sum).ToString() + "\nTarget: " + target.ToString();
        Invoke("movehelp", 5);
    }

    private void movehelp()
    {
        TheGame.instance.DartMove();
    }

    public void ChangeTarget(int value)
    {
        target = value;
    }
}

//Round: 12
//Points: 555
//Target: 701