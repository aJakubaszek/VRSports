using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartfixedrotation : MonoBehaviour
{

    [SerializeField] private GameObject objct;

    // Start is called before the first frame update
    void Start()
    {
        objct.transform.rotation.Set(90.0f, objct.transform.rotation.y, objct.transform.rotation.z, objct.transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        objct.transform.rotation.Set(90.0f, objct.transform.rotation.y, objct.transform.rotation.z, objct.transform.rotation.w);
    }
}
