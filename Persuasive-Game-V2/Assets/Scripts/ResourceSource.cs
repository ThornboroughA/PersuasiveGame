using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSource : MonoBehaviour
{

    //mechanics
    Color originalColor;
    public MeshRenderer objectRenderer;
    public int numberOfHits = 3;
    public Transform pickupGuide;
    private bool isHit;

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
    }
    private void OnMouseDown()
    {

        if (Vector3.Distance(transform.position, pickupGuide.position) < 12 && numberOfHits > 0) //so the player has to be close to the object
        {
            //visual feedback
            //Material[] materials = objectRenderer.materials;
            //for(int i = 0; i < materials.Length; i++)
            //{
            //    materials[i].color = Color.red;
            //}
           objectRenderer.material.color = Color.red;//switch out again when I figure it out
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

            isHit = true;
        }
        //find a way to store all the old materials, then re-access them?
    }
    private void OnMouseUp()
    {
        if (isHit == true) {
            //visual feedback
            //Material[] materials = objectRenderer.materials;
            //for (int i = 0; i < materials.Length; i++)
            //{
            //    materials[i].color = originalColor;
            //}
            objectRenderer.material.color = originalColor;//switch out again

        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        isHit = false;
        numberOfHits -= 1;
        }
        
    }

}

//click the resource source several times; afterwards, it turns into several of the constituent resource
////code to tick up 1 with each click; should be visual feedback with each one too
///
//if tag = gold then spawn gold, if tag = wood then spawn wood etc