using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyPicker : MonoBehaviour
{
    [SerializeField] List<String> difficultySettingsKeys;
    [SerializeField] List<GameObject> spawnersList;
    [SerializeField] TMP_Dropdown dropdown;

    public void EnableTarget(){
        string difficulty = dropdown.options[dropdown.value].text;
        foreach (GameObject entry in spawnersList){
            entry.SetActive(false);
        }
        int index = difficultySettingsKeys.IndexOf(difficulty);
        spawnersList[index].SetActive(true);
    }
}
