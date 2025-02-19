using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDimensions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 sizeVec = GetComponent<Collider>().bounds.size;
        Debug.Log("Height: " + sizeVec.y + " Width: " + sizeVec.x + " Depth: " + sizeVec.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
