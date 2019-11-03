using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{

    //resources
    public int availableGold;
    public int availableBerries;
    public int availableWood;

    private bool storageCollision;

    //building types
    //public GameObject testBuilding;


    // Update is called once per frame
    //void Update()
    //{
    //    //if (Vector3.Distance(transform.position, pickupGuide.position) < 12 && numberOfHits > 0)
    //    //if (Vector3.Distance(transform.position, ))
    //    if (availableGold > 2)
    //    {
    //        testBuilding.SetActive(true);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("ResGold"))
        {
            //Debug.Log("available gold:" + availableGold);
            availableGold += 1;
            other.gameObject.tag = "ResGoldVoid";
            GlobalControl.Instance.availableGold = availableGold;
        }
        if (other.transform.CompareTag("ResBerries"))
        {
            availableBerries += 1;
            other.gameObject.tag = "ResBerriesVoid";
            GlobalControl.Instance.availableBerries = availableBerries;
        }
        if (other.transform.CompareTag("ResWood"))
        {
            availableWood += 1;
            other.gameObject.tag = "ResWoodVoid";
            GlobalControl.Instance.availableWood = availableWood;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("ResGoldVoid"))
        {
            availableGold -= 1;
            other.gameObject.tag = "ResGold";
            //Debug.Log("available gold:" + availableGold);
            GlobalControl.Instance.availableGold = availableGold;
        }
        if (other.transform.CompareTag("ResBerriesVoid"))
        {
            availableBerries -= 1;
            other.gameObject.tag = "ResBerries";
            GlobalControl.Instance.availableBerries = availableBerries;
        }
        if (other.transform.CompareTag("ResWoodVoid"))
        {
            availableWood -= 1;
            other.gameObject.tag = "ResWood";
            GlobalControl.Instance.availableWood = availableWood;
        }
    }


}


//needs to:
//register when a resource is in/out of its sphere
//update the UI to show what's in there
////and be modular; show gold, wood etc
//
//allow building
////reveal UI buttons when there's enough resources, and let you build building etc
//
//show score
////update score if thing is built