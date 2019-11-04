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

    public int bankedResource1; //how much of the resource is within the collider
    public int bankedResource2;
    public int bankedResource3;

    public int requiredResource1; //how much of the resource needs to be banked
    public int requiredResource2;
    public int requiredResource3;

    public GameObject res1Text;
    public GameObject res2Text;
    public GameObject res3Text;
    private string res1Imi;
    private string res2Imi;
    private string res3Imi;

    //from global control script
    public int availableGold;
    public int availableBerries;
    public int availableWood;
    //for counting how many of each type comes 
    public int woodCount;
    public int berryCount;
    public int goldCount;

    //tech effects
    public GameObject techButton; //button that lets player choose tech

    private bool coroutineStartBool;

    private void Start()
    {

        availableGold = GlobalControl.Instance.availableGold;
        availableBerries = GlobalControl.Instance.availableBerries;
        availableWood = GlobalControl.Instance.availableWood;

        //sets the numbers for the resource requirement guides
        //Debug.Log("starting text");
        if (requiredResource1 != 0)
        {
            res1Text.GetComponent<TMPro.TextMeshPro>().text = requiredResource1.ToString();
        }
        if (requiredResource2 != 0)
        {
            res2Text.GetComponent<TMPro.TextMeshPro>().text = requiredResource2.ToString();
        }
        if (requiredResource3 != 0)
        {
            res3Text.GetComponent<TMPro.TextMeshPro>().text = requiredResource3.ToString();
        }
        
    }
    void FixedUpdate()
    {

        if ((resourceThree != null) && (resourceTwo != null))
        {
            if ((coroutineStartBool == false) && (bankedResource3 == requiredResource3) && (bankedResource2 == requiredResource2) && (bankedResource1 == requiredResource1))
            {
                Debug.Log("3 resource match");
                StartCoroutine(TechButtonUp());
            }
        }
        if ((coroutineStartBool == false) && (resourceThree == null) && (resourceTwo != null))
        {
            if ((bankedResource2 == requiredResource2) && (bankedResource1 == requiredResource1))
            {
                Debug.Log("2 resource match");
                StartCoroutine(TechButtonUp());
            }
        }
        if ((coroutineStartBool == false) && (resourceThree == null) && (resourceTwo == null))
            
        {
            if ((bankedResource1 == requiredResource1) && (requiredResource1 != 0))
            {
                Debug.Log("1 resource match");
                StartCoroutine(TechButtonUp());
                
            }
        }

    }

    //bool buttonIsMoving = false;


    IEnumerator TechButtonUp()
    {
        Debug.Log("Tech Button movement coroutine start");
        coroutineStartBool = true;
        //techButton.SetActive(true);
        //if (buttonIsMoving)
        //{
        //    yield break;
        //}
        //buttonIsMoving = true;

        float counter = 0;
        float duration = 4f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            techButton.transform.localPosition = Vector3.Lerp(new Vector3(0,-7,-0.4f), new Vector3(0,-2.1f,-0.4f), counter / duration);
 
            yield return null;
        }

        //remove spent resources from GlobalControl's memory
        availableGold -= goldCount;
        GlobalControl.Instance.availableGold = availableGold;
        availableBerries -= berryCount;
        GlobalControl.Instance.availableBerries = availableBerries;
        availableWood -= woodCount;
        GlobalControl.Instance.availableWood = availableWood;


        var coScript = techButton.GetComponent<TechButton>();
        StartCoroutine(coScript.RewardText());

    }


    private void OnTriggerEnter(Collider other)
    {
        //for counting specific types
        if (other.gameObject.tag == "ResWood")
        {
            woodCount += 1;
        }
        if (other.gameObject.tag == "ResBerries")
        {
            berryCount += 1;
        }
        if (other.gameObject.tag == "ResGold")
        {
            goldCount += 1;
        }

        if (other.gameObject.tag == resourceOne.gameObject.tag)
        {
            bankedResource1 += 1;
            other.gameObject.tag = resourceOne.gameObject.tag + "Void";

            //Debug.Log("add to text");
            //res1Text.GetComponent<TMPro.TextMeshPro>().text = (requiredResource1 - bankedResource1).ToString();
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
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == (resourceOne.gameObject.tag + "Void"))
    //    {
    //        bankedResource1 -= 1;
    //        other.gameObject.tag = resourceOne.gameObject.tag;
    //        //Debug.Log("subtract from text");
    //        //res1Text.GetComponent<TMPro.TextMeshPro>().text = (-1).ToString();//(requiredResource1 + bankedResource1).ToString();
    //    }
    //    if (resourceTwo != null)
    //    {
    //        if (other.gameObject.tag == (resourceTwo.gameObject.tag + "Void"))
    //        {
    //            bankedResource2 -= 1;
    //            other.gameObject.tag = resourceTwo.gameObject.tag;
    //        }
    //    }
    //    if (resourceThree != null)
    //    {
    //        if (other.gameObject.tag == (resourceThree.gameObject.tag + "Void"))
    //        {
    //            bankedResource3 -= 1;
    //            other.gameObject.tag = resourceThree.gameObject.tag;
    //        }
    //    }
    //}
}
