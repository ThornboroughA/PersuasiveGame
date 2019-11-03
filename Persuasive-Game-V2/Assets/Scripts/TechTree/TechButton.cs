using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechButton : MonoBehaviour
{

    public int scoreToAdd; //how many points the tech will add
    public string technologyInformation;
    public int scoreIntGlobal;

    public string techThis; //the id this tech has; gets added to technologyInformation string on activation

    private void Start()
    {
        technologyInformation = GlobalControl.Instance.technologyInformation;
        if (technologyInformation.Contains(techThis))
        {
            Debug.Log("tech" + techThis + "already active.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("Tech is triggered");
            scoreIntGlobal += scoreToAdd;
            technologyInformation = GlobalControl.Instance.technologyInformation;
            technologyInformation += techThis;
            GlobalControl.Instance.technologyInformation = technologyInformation;

        }
    }
}
