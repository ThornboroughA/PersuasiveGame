using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    private int tutorialTracker; //tracks the part of the tutorial we're at
    public GameObject tutOne;
    public GameObject tutTwo;
    public GameObject tutThree;
    public GameObject tutFour;
    public GameObject tutFive;
    public GameObject tutDismiss;

    private bool firePitClickCheck;
    private bool berryClickCheck;


    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(TutorialOneCall());



    }
    void Update()
    {
        FirePit firePitCheck = GameObject.FindObjectOfType<FirePit>();
        firePitClickCheck = firePitCheck.firePitIsHit;

        ResourceSource resourceSourceCheck = GameObject.FindObjectOfType<ResourceSource>();
        if (resourceSourceCheck != null)
        {
            berryClickCheck = resourceSourceCheck.isHit;
        }
        
    }
    //for accessing tutorial conditions in other scripts
    public void FirePitRecieve(bool firePit)
    {
        firePitClickCheck = firePit;
    }
    public void BerryReceive(bool berryCheck)
    {
        berryClickCheck = berryCheck;
    }

    //TUTORIAL SCRIPTS
    public IEnumerator TutorialOneCall()
    {
        yield return new WaitForSeconds(1.5f);
        tutOne.SetActive(true);
        tutDismiss.SetActive(true);

        StartCoroutine(TutorialTwoCall());
    }
    public IEnumerator TutorialTwoCall()
    {
        yield return new WaitForSeconds(7f);
        tutOne.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        tutTwo.SetActive(true);

        while (true)
        {
            if (berryClickCheck == true)
            {
                StartCoroutine(TutorialThreeCall());
            }
            yield return null;
        }

    }
    public IEnumerator TutorialThreeCall()
    {
        //firePitClickCheck = false;
        yield return new WaitForSeconds(1f);
        tutTwo.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        tutThree.SetActive(true);

        StartCoroutine(TutorialFourCall());
    }
    public IEnumerator TutorialFourCall()
    {
        yield return new WaitForSeconds(5f);
        tutThree.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        tutFour.SetActive(true);

        StartCoroutine(TutorialFiveCall());
    }
    public IEnumerator TutorialFiveCall()
    {
        yield return new WaitForSeconds(5f);
        tutFour.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        tutFive.SetActive(true);

        while (true)
        {
            if (firePitClickCheck == true)
            {
                StartCoroutine(TutorialSixCall());
            }
            yield return null;
        }

    }
    public IEnumerator TutorialSixCall()
    {
        yield return new WaitForSeconds(1f);
        tutFive.SetActive(false);
        tutDismiss.SetActive(false);
    }
    
    

}
