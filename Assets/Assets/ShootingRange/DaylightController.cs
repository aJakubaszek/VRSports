using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DaylightController : MonoBehaviour
{
    [SerializeField] Slider slider;
    void Update(){
        gameObject.transform.rotation = Quaternion.Euler(slider.value, 0, 0);
    }
}
