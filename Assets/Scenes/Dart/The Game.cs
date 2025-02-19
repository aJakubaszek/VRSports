using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGame : MonoBehaviour
{
    [SerializeField] private GameObject objct1;
    [SerializeField] private GameObject objct2;
    [SerializeField] private GameObject objct3;
    [SerializeField] private GameObject prop1;
    [SerializeField] private GameObject prop2;
    [SerializeField] private GameObject prop3;

    [SerializeField] private GameObject prop_destination;
    [SerializeField] private GameObject obj_destination;

    [SerializeField] private Canvas menu;

    [SerializeField] private Button b_301;
    [SerializeField] private Button b_501;
    [SerializeField] private Button b_701;

    [SerializeField] private Button d_Black;
    [SerializeField] private Button d_Red;
    [SerializeField] private Button d_Green;
    [SerializeField] private Button d_Blue;
    [SerializeField] private Button d_Yellow;
    [SerializeField] private Button d_Orange;
    [SerializeField] private Button d_Pink;

    [SerializeField] private Button db_White;
    [SerializeField] private Button db_Blue;
    [SerializeField] private Button db_Yellow;
    [SerializeField] private Button db_Orange;
    [SerializeField] private Button db_Pink;
    [SerializeField] private Button db_Grey;

    [SerializeField] private Button b_Start;

    public static TheGame instance;

    public int gamemode = 0;
    public int dart_col = 1;
    public int board_col = 1;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        b_301.onClick.AddListener(() => OnClick(b_301));
        b_501.onClick.AddListener(() => OnClick(b_501));
        b_701.onClick.AddListener(() => OnClick(b_701));
        d_Black.onClick.AddListener(() => OnClick(d_Black));
        d_Red.onClick.AddListener(() => OnClick(d_Red));
        d_Green.onClick.AddListener(() => OnClick(d_Green));
        d_Blue.onClick.AddListener(() => OnClick(d_Blue));
        d_Yellow.onClick.AddListener(() => OnClick(d_Yellow));
        d_Orange.onClick.AddListener(() => OnClick(d_Orange));
        d_Pink.onClick.AddListener(() => OnClick(d_Pink));
        db_White.onClick.AddListener(() => OnClick(db_White));
        db_Blue.onClick.AddListener(() => OnClick(db_Blue));
        db_Yellow.onClick.AddListener(() => OnClick(db_Yellow));
        db_Orange.onClick.AddListener(() => OnClick(db_Orange));
        db_Pink.onClick.AddListener(() => OnClick(db_Pink));
        db_Grey.onClick.AddListener(() => OnClick(db_Grey));
        b_Start.onClick.AddListener(() => OnClick(b_Start));
    }

    public void OnClick(Button other)
    {
        if (other == b_301)
        {
            gamemode = 0;
        }
        else if (other == b_501)
        {
            gamemode = 1;
        }
        else if (other == b_701)
        {
            gamemode = 2;
        }
        else if (other == d_Black)
        {
            dart_col = 0;
            //return_material.instance.change();
        }
        else if (other == d_Red)
        {
            dart_col = 1;
            //return_material.instance.change();
        }
        else if (other == d_Green)
        {
            dart_col = 2;
            //return_material.instance.change();
        }
        else if (other == d_Blue)
        {
            dart_col = 3;
            //return_material.instance.change();
        }
        else if (other == d_Yellow)
        {
            dart_col = 4;
            //return_material.instance.change();
        }
        else if (other == d_Orange)
        {
            dart_col = 5;
            //return_material.instance.change();
        }
        else if (other == d_Pink)
        {
            dart_col = 6;
            //return_material.instance.change();
        }
        else if (other == db_White)
        {
            board_col = 0;
        }
        else if (other == db_Blue)
        {
            board_col = 1;
        }
        else if (other == db_Yellow)
        {
            board_col = 2;
        }
        else if (other == db_Orange)
        {
            board_col = 3;
        }
        else if (other == db_Pink)
        {
            board_col = 4;
        }
        else if (other == db_Grey)
        {
            board_col = 5;
        }
        else if (other == b_Start)
        {
            Point_Management.instance.NewGame();

            DartMove();

            //menu.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    public void DartMove()
    {

        prop1.transform.position = prop_destination.transform.position;
        objct1.transform.position = obj_destination.transform.position;
        objct1.transform.rotation = obj_destination.transform.rotation;

        prop2.transform.position = prop_destination.transform.position;
        objct2.transform.position = obj_destination.transform.position;
        objct2.transform.rotation = obj_destination.transform.rotation;

        prop3.transform.position = prop_destination.transform.position;
        objct3.transform.position = obj_destination.transform.position;
        objct3.transform.rotation = obj_destination.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
