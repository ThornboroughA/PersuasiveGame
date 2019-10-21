using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtChar : MonoBehaviour
{

    public GameObject Char;
    Vector3 lookAtOffset;
    // Start is called before the first frame update
    void Start()
    {
        lookAtOffset = new Vector3(0, 1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //look at ball
        transform.LookAt(Char.transform.position + lookAtOffset);
    }
}
