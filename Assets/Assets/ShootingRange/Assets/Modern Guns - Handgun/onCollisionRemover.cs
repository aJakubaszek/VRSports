using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionRemover : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject,0.3f);
    }
}
