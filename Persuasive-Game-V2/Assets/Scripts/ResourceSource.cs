using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResourceSource : MonoBehaviour
{

    //mechanics
    Color originalColor; //change to Color[]
    //Color[] storedColor;
    public MeshRenderer objectRenderer;
    public int numberOfHits = 3;
    public Transform pickupGuide;
    public bool isHit;

    private TutorialScript tutorialBerryCheck;

    public string resourceThis;
    public string resourcesInformation;

    //prefabs
    public GameObject resourceOne;
    public GameObject resourceTwo;
    public GameObject resourceThree;
    public GameObject resourceFour;
    public GameObject resourceFive;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = objectRenderer.material.color;

        //Material[] materials = objectRenderer.materials;
        //for (int i = 0; i < materials.Length; i++)
        //{
        //    originalColor[i] = materials[i].color; //objectRenderer.materials[i].color;
        //}

        //for (int i = 0; i < materials.Length; i++)
        //{
        //    materials[i].color = originalColor;
        //}

        tutorialBerryCheck = GameObject.FindObjectOfType<TutorialScript>();

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
    }
    private void OnMouseDown()
    {

        if (Vector3.Distance(transform.position, pickupGuide.position) < 12 && numberOfHits > 0) //so the player has to be close to the object
        {
            //visual feedback
            Material[] materials = objectRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i].color = Color.yellow;
            }
            //objectRenderer.material.color = Color.red;//switch out again when I figure it out
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

            isHit = true;

            tutorialBerryCheck.BerryReceive(true);
        }
        //for color, find a way to store all the old materials, then re-access them?
    }
    private void OnMouseUp()
    {
        if (isHit == true)
        {
            //visual feedback
            //Material[] materials = objectRenderer.materials;
            //for (int i = 0; i < materials.Length; i++)
            //{
            //    materials[i].color = originalColor; //materials[i].color = originalColor[i];
            //}

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

    }

}

