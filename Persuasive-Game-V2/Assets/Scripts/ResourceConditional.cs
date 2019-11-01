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
   

    //prefabs
    public GameObject resourceOne;
    public GameObject resourceTwo;
    public GameObject resourceThree;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = objectRenderer.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfHits <= 0)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
            Instantiate(resourceOne, transform.position, transform.rotation);
            Instantiate(resourceTwo, transform.position, transform.rotation);
            Instantiate(resourceThree, transform.position, transform.rotation);

        }
        Character characterScript = GameObject.FindObjectOfType<Character>();
        currentTool = characterScript.toolInt;
    }
    private void OnMouseDown()
    {
        if ((currentTool == requiredTool) && (Vector3.Distance(transform.position, pickupGuide.position) < 12) && (numberOfHits > 0))
        {
            //visual feedback
            objectRenderer.material.color = Color.red;
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

            isHit = true;
        }
    }
    private void OnMouseUp()
    {
        if (isHit == true)
        {
            objectRenderer.material.color = originalColor;//switch out again

            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

            isHit = false;
            numberOfHits -= 1;
        }

    }

}
