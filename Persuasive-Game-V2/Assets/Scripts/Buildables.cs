using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildables : MonoBehaviour
{
    public GameObject TestBuilding;

    // Start is called before the first frame update
    public void start()
    {
        //Debug.Log("Hello World");
        
    }

    public void OnClick()
    {
        TestBuilding.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
