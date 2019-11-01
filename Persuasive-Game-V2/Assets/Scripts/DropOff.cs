using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    private int availableGold;
    private bool storageCollision;

    //building types
    public GameObject testBuilding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(transform.position, pickupGuide.position) < 12 && numberOfHits > 0)

        //if (Vector3.Distance(transform.position, ))

        if (availableGold > 2)
        {
            testBuilding.SetActive(true);

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("ResGold"))
        {
            Debug.Log("available gold:" + availableGold);
            availableGold += 1;
            other.gameObject.tag = "Untagged";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("ResGold"))
        {
            availableGold -= 1;
            Debug.Log("available gold:" + availableGold);
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