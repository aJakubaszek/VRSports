using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class return_material : MonoBehaviour
{
    //public static return_material instance;

    [SerializeField] Material Black;
    [SerializeField] Material Red;
    [SerializeField] Material Green;
    [SerializeField] Material Blue;
    [SerializeField] Material Yellow;
    [SerializeField] Material Orange;
    [SerializeField] Material Pink;

    public GameObject go;

    //private void Awake()
    //{
    //    instance = this;
    //}

    private void Start()
    {
        go = this.gameObject;

        if (TheGame.instance.dart_col == 1)
        {
            go.GetComponent<MeshRenderer>().material = Red;
        }
        else if (TheGame.instance.dart_col == 2)
        {
            go.GetComponent<MeshRenderer>().material = Green;
        }
        else if (TheGame.instance.dart_col == 3)
        {
            go.GetComponent<MeshRenderer>().material = Blue;
        }
        else if (TheGame.instance.dart_col == 4)
        {
            go.GetComponent<MeshRenderer>().material = Yellow;
        }
        else if (TheGame.instance.dart_col == 5)
        {
            go.GetComponent<MeshRenderer>().material = Orange;
        }
        else if (TheGame.instance.dart_col == 6)
        {
            go.GetComponent<MeshRenderer>().material = Pink;
        }
        else go.GetComponent<MeshRenderer>().material = Black;
    }
    private void Update()
    {
        
        if (TheGame.instance.dart_col == 1)
        {
            go.GetComponent<MeshRenderer>().material = Red;
        }
        else if (TheGame.instance.dart_col == 2)
        {
            go.GetComponent<MeshRenderer>().material = Green;
        }
        else if (TheGame.instance.dart_col == 3)
        {
            go.GetComponent<MeshRenderer>().material = Blue;
        }
        else if (TheGame.instance.dart_col == 4)
        {
            go.GetComponent<MeshRenderer>().material = Yellow;
        }
        else if (TheGame.instance.dart_col == 5)
        {
            go.GetComponent<MeshRenderer>().material = Orange;
        }
        else if (TheGame.instance.dart_col == 6)
        {
            go.GetComponent<MeshRenderer>().material = Pink;
        }
        else go.GetComponent<MeshRenderer>().material = Black;
    }

    /*
     
    public void change()
    {

        if (TheGame.instance.dart_col == 1)
        {
            go.GetComponent<MeshRenderer>().material = Red;
        }
        if (TheGame.instance.dart_col == 2)
        {
            go.GetComponent<MeshRenderer>().material = Green;
        }
        if (TheGame.instance.dart_col == 3)
        {
            go.GetComponent<MeshRenderer>().material = Blue;
        }
        if (TheGame.instance.dart_col == 4)
        {
            go.GetComponent<MeshRenderer>().material = Yellow;
        }
        if (TheGame.instance.dart_col == 5)
        {
            go.GetComponent<MeshRenderer>().material = Orange;
        }
        if (TheGame.instance.dart_col == 6)
        {
            go.GetComponent<MeshRenderer>().material = Pink;
        }
        go.GetComponent<MeshRenderer>().material = Black;
    }
     
     */


}
