using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyReposition : MonoBehaviour
{
    [SerializeField] private Collider objct_col;
    [SerializeField] private GameObject objct;
    [SerializeField] private GameObject destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other == objct_col)
        {
        objct.transform.position = destination.transform.position;
        objct.transform.rotation = destination.transform.rotation;
        }
    }
}
