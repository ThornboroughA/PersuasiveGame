using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    private int tutorialTracker; //tracks the part of the tutorial we're at
    public GameObject tutOne;
    public GameObject tutTwo;
  


    // Start is called before the first frame update
    void Start()
    {
        // yield return new WaitForSeconds(3);

        StartCoroutine(TutorialOneCall());
        


    }

    // Update is called once per frame
    public IEnumerator TutorialOneCall()
    {
        yield return new WaitForSeconds(1.5f);
        tutOne.SetActive(true);

        StartCoroutine(TutorialTwoCall());
    }
    public IEnumerator TutorialTwoCall()
    {
        yield return new WaitForSeconds(8f);
        tutOne.SetActive(false);
        yield return new WaitForSeconds(3f);
        tutTwo.SetActive(true);
    }
    

}
