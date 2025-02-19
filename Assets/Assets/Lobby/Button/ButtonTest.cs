using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public ButtonFollowVisual button;

    void Start(){
        button.buttonPressed += function;
    }

    void function(){
        Renderer rendered = GetComponent<Renderer>();
        rendered.material.color = Color.black;
    }
}
