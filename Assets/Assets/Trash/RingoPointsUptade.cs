using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RingoPointsUptade : MonoBehaviour
{
    private int _ringoPoints = 0; //Zmienić na wspólną wartość dla wszystkich tablic?
    
     public int getRingoPoints()
    {
        return _ringoPoints;
    }
    public void setRingoPoints(int newValue)
    {
        _ringoPoints = newValue;
    }
    private void OnEnable()
    {
        // Subscribe to the delegate event when enabled
        RingoPointCounter.AddPointEvent += PointsAdded;
        RingoPointCounter.SubstractPointEvent += PointsSubstracted;
    }
    void Start()
    {
        transform.GetComponent<TextMeshPro>().text = _ringoPoints.ToString();
    }
    private void PointsAdded()
    {
        _ringoPoints++;
        transform.GetComponent<TextMeshPro>().text = _ringoPoints.ToString();
    }
    private void PointsSubstracted()
    {
        _ringoPoints--;
        transform.GetComponent<TextMeshPro>().text = _ringoPoints.ToString();
    }

}
