using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 sizeVec = GetComponent<Collider>().bounds.size;
        Debug.Log("Height: " + sizeVec.y);
        Debug.Log("Width: " + sizeVec.x);
        Debug.Log("Length: " + sizeVec.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
