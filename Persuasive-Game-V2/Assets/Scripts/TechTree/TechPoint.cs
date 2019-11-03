using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public variable you put the tag the tech needs into
//code checks if object's tag matches public variable's chosen tag

//check tag of all matching objects in it
//public variables that allow requirement of multiple of objects and different kinds of objects
//update to remove resource counts of those objects from global script



//tech effects
//if banked = requirements, physical button becomes available
//stand on button for a time and thing activates

public class TechPoint : MonoBehaviour
{
    public GameObject resourceOne;
    public GameObject resourceTwo;
    public GameObject resourceThree;

    private int bankedResource1; //how much of the resource is within the collider
    private int bankedResource2;
    private int bankedResource3;

    public int requiredResource1; //how much of the resource needs to be banked
    public int requiredResource2;
    public int requiredResource3;

    //tech effects
    public GameObject techButton; //button that lets player choose tech



    void FixedUpdate()
    {

        if ((resourceThree != null) && (resourceTwo != null))
        {
            if ((bankedResource3 == requiredResource3) && (bankedResource2 == requiredResource2) && (bankedResource1 == requiredResource1))
            {
                Debug.Log("3 resource match");
                //scoreIntGlobal += scoreToAdd;
                //technologyInformation += techThis;

                techButton.SetActive(true);
            }
        }
        if ((resourceThree == null) && (resourceTwo != null))
        {
            if ((bankedResource2 == requiredResource2) && (bankedResource1 == requiredResource1))
            {
                Debug.Log("2 resource match");

                techButton.SetActive(true);
            }
        }
        if ((resourceThree == null) && (resourceTwo == null))
        {
            if (bankedResource1 == requiredResource1)
            {
                Debug.Log("1 resource match");

                techButton.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == resourceOne.gameObject.tag)
        {
            bankedResource1 += 1;
            other.gameObject.tag = resourceOne.gameObject.tag + "Void";
        }
        if (resourceTwo != null)
        {
            if (other.gameObject.tag == resourceTwo.gameObject.tag)
            {
                bankedResource2 += 1;
                other.gameObject.tag = resourceTwo.gameObject.tag + "Void";
            }
        }
        if (resourceThree != null)
        {
            if (other.gameObject.tag == resourceThree.gameObject.tag)
            {
                bankedResource3 += 1;
                other.gameObject.tag = resourceThree.gameObject.tag + "Void";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == (resourceOne.gameObject.tag + "Void"))
        {
            bankedResource1 -= 1;
            other.gameObject.tag = resourceOne.gameObject.tag;

        }
        if (resourceTwo != null)
        {
            if (other.gameObject.tag == (resourceTwo.gameObject.tag + "Void"))
            {
                bankedResource2 -= 1;
                other.gameObject.tag = resourceTwo.gameObject.tag;
            }
        }
        if (resourceThree != null)
        {
            if (other.gameObject.tag == (resourceThree.gameObject.tag + "Void"))
            {
                bankedResource3 -= 1;
                other.gameObject.tag = resourceThree.gameObject.tag;
            }
        }
    }
}
