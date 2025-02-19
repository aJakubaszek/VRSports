using Mono.Unix.Native;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Board : MonoBehaviour
{
    [SerializeField] Material White;
    [SerializeField] Material Blue;
    [SerializeField] Material Yellow;
    [SerializeField] Material Orange;
    [SerializeField] Material Pink;
    [SerializeField] Material Gray;

    public GameObject go;

    void Start()
    {
        go = this.gameObject;

        if (TheGame.instance.board_col == 1)
        {
            go.GetComponent<MeshRenderer>().material = Blue;
        }
        else if (TheGame.instance.board_col == 2)
        {
            go.GetComponent<MeshRenderer>().material = Yellow;
        }
        else if (TheGame.instance.board_col == 3)
        {
            go.GetComponent<MeshRenderer>().material = Orange;
        }
        else if (TheGame.instance.board_col == 4)
        {
            go.GetComponent<MeshRenderer>().material = Pink;
        }
        else if (TheGame.instance.board_col == 5)
        {
            go.GetComponent<MeshRenderer>().material = Gray;
        }
        else go.GetComponent<MeshRenderer>().material = White;
    }


    void Update()
        {
        if (TheGame.instance.board_col == 1)
        {
            go.GetComponent<MeshRenderer>().material = Blue;
        }
        else if (TheGame.instance.board_col == 2)
        {
            go.GetComponent<MeshRenderer>().material = Yellow;
        }
        else if (TheGame.instance.board_col == 3)
        {
            go.GetComponent<MeshRenderer>().material = Orange;
        }
        else if (TheGame.instance.board_col == 4)
        {
            go.GetComponent<MeshRenderer>().material = Pink;
        }
        else if (TheGame.instance.board_col == 5)
        {
            go.GetComponent<MeshRenderer>().material = Gray;
        }
        else go.GetComponent<MeshRenderer>().material = White;
    }

    /*
    public void change()
    {
        if (TheGame.instance.board_col == 1)
        {
            go.GetComponent<MeshRenderer>().material = Blue;
        }
        else if (TheGame.instance.board_col == 2)
        {
            go.GetComponent<MeshRenderer>().material = Yellow;
        }
        else if (TheGame.instance.board_col == 3)
        {
            go.GetComponent<MeshRenderer>().material = Orange;
        }
        else if (TheGame.instance.board_col == 4)
        {
            go.GetComponent<MeshRenderer>().material = Pink;
        }
        else if (TheGame.instance.board_col == 5)
        {
            go.GetComponent<MeshRenderer>().material = Gray;
        }
        else go.GetComponent<MeshRenderer>().material = White;
    }
     
     */

}
