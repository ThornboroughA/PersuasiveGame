using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceConditional : MonoBehaviour
{
    //mechanics
    Color originalColor;
    public MeshRenderer objectRenderer; //for the color flash
    public int numberOfHits = 3; //the number of hits it takes to destroy the object
    public Transform pickupGuide; //to detect when the player is close
    //public GameObject requiredTool;
    public int requiredTool; //the tool the resource needs to be gotten
    public int currentTool; //the current tool the player has
    private bool isHit = false;
    private bool isMissed = false;

    ////status preservation
    //public float goldMineStatus = 1f;
    public string resourceThis;
    public string resourcesInformation;

    //resource prefabs
    public GameObject resourceOne;
    public GameObject resourceTwo;
    public GameObject resourceThree;
    public GameObject resourceFour;
    public GameObject resourceFive;

    
    void Start()
    {
        originalColor = objectRenderer.material.color;

        //this is to keep resources persistent between scene switching
        resourcesInformation = GlobalControl.Instance.resourcesInformation;
        if (resourcesInformation.Contains(resourceThis))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfHits <= 0)
        {
            gameObject.SetActive(false);
            
            //Destroy(gameObject);
            if (resourceOne != null)
            {
                Instantiate(resourceOne, transform.position, transform.rotation);
            }
            if (resourceTwo != null)
            {
                Instantiate(resourceTwo, transform.position, transform.rotation);
            }
            if (resourceThree != null)
            {
                Instantiate(resourceThree, transform.position, transform.rotation);
            }
            if (resourceFour != null)
            {
                Instantiate(resourceFour, transform.position, transform.rotation);
            }
            if (resourceFive != null)
            {
                Instantiate(resourceFive, transform.position, transform.rotation);
            }


            ////Resources status preservation / changing
            resourcesInformation = GlobalControl.Instance.resourcesInformation;
            resourcesInformation += resourceThis;
            GlobalControl.Instance.resourcesInformation = resourcesInformation;
            Debug.Log(resourcesInformation);
        }


        Character characterScript = GameObject.FindObjectOfType<Character>();
        currentTool = characterScript.toolInt;
    }

    private void OnMouseDown()
    {
        if ((currentTool == requiredTool) && (Vector3.Distance(transform.position, pickupGuide.position) < 12) && (numberOfHits > 0)) //when you have the right tool
        {
            //visual feedback
            Material[] materials = objectRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].color = Color.yellow;
            }
            //objectRenderer.material.color = Color.red;
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

            isHit = true;
        }
        else if (Vector3.Distance(transform.position, pickupGuide.position) < 12) //when you don't have the right tool
        {
            Material[] materials = objectRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].color = Color.red;
            }
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

            isMissed = true;

        }
    }
    private void OnMouseUp()
    {
        if (isHit == true)
        {
            Material[] materials = objectRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].color = originalColor;
            }
            //objectRenderer.material.color = originalColor;//switch out again

            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

            isHit = false;
            numberOfHits -= 1;
        }
        else if (isMissed == true)
        {
            Material[] materials = objectRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].color = originalColor;
            }
            //objectRenderer.material.color = originalColor;//switch out again

            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

            isMissed = false;
        }
    }


}
