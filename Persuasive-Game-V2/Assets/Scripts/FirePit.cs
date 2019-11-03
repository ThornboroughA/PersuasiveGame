using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FirePit : MonoBehaviour
{

    public Transform guide;
    public bool firePitIsHit;
    private TutorialScript tutorialCheck;

    public GameObject firePitInterface;

    
    void Start()
    {
        tutorialCheck = GameObject.FindObjectOfType<TutorialScript>();
    }

   
    void Update()
    {
        
    }


    private void OnMouseDown() //picks up the object
    {
        if (Vector3.Distance(transform.position, guide.position) < 12) //so the player has to be close to the object to pick it up
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            firePitIsHit = true;
            Debug.Log(firePitIsHit);

            tutorialCheck.FirePitRecieve(true);
        }

    }
    private void OnMouseUp() //drops the object
    {
        if (firePitIsHit == true)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);


            firePitInterface.SetActive(true);

            SceneManager.LoadScene("TechTree", LoadSceneMode.Single);



            firePitIsHit = false;
        }
    }
}
