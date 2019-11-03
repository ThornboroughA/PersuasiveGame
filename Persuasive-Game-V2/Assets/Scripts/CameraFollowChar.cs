using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollowChar : MonoBehaviour
{
    public Transform playerObject;
    public int distanceFromObject;
    void FixedUpdate()
    {

        transform.position = playerObject.transform.position + new Vector3(0, distanceFromObject, (distanceFromObject / -2));
    }
}