using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    //Variables
    public GameObject item;
    GameObject tempParent;
    Transform guide;

    public MeshRenderer objectRenderer;
    Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        tempParent = GameObject.FindWithTag("pickupGuide");
        guide = GameObject.FindWithTag("pickupGuide").transform;

        item.GetComponent<Rigidbody>().useGravity = true;
        originalColor = objectRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() //picks up the object
    {
        if (Vector3.Distance(transform.position, guide.position) < 12) //so the player has to be close to the object to pick it up
        {
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = guide.transform.position;
            item.transform.rotation = guide.transform.rotation;
            item.transform.parent = tempParent.transform;
            item.transform.localScale += new Vector3(1, 1, 1);
        }
        
    }
    private void OnMouseUp() //drops the object
    {
        if (Vector3.Distance(transform.position, guide.position) < 12)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            item.transform.position = guide.transform.position;
            item.transform.localScale -= new Vector3(1, 1, 1);
        }
    }
    //private void OnMouseOver() //highlights the object a color on mouseover.
    //{
    //    if (Vector3.Distance(transform.position, guide.position) < 12)
    //    {
    //        objectRenderer.material.color = Color.yellow;
    //    }
    //}
    //private void OnMouseExit()
    //{
    //    objectRenderer.material.color = originalColor;
    //}
}
