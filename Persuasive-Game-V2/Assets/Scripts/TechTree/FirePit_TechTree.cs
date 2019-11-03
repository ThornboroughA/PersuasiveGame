using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirePit_TechTree : MonoBehaviour
{
    public Transform guide;
    private bool firePitIsHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

            
        }

    }
    private void OnMouseUp() //drops the object
    {
        if (firePitIsHit == true)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);


            

            SceneManager.LoadScene("Temperate", LoadSceneMode.Single);



            firePitIsHit = false;
        }
    }
}
