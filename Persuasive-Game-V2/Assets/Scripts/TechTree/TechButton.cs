using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechButton : MonoBehaviour
{

    public int scoreToAdd; //how many points the tech will add
    public string technologyInformation;
    public int scoreIntGlobal;
    private bool techActive;

    public GameObject techPoint; //to disable it once tech is already active for reloads
    public MeshRenderer techText;
    public GameObject techReward;
    public GameObject requirementsEmpty;

    public string techThis; //the id this tech has; gets added to technologyInformation string on activation

    private void Start()
    {
        

        technologyInformation = GlobalControl.Instance.technologyInformation;
        if (technologyInformation.Contains(techThis))
        {
            Debug.Log("tech" + techThis + "already active.");
            techActive = true;

            requirementsEmpty.SetActive(false);
            techPoint.GetComponent<TechPoint>().enabled = false;
            transform.localPosition = new Vector3(0, -2.1f, -0.4f);
            techReward.SetActive(true);
            techText.material.color = Color.yellow;
        }

    }

    public IEnumerator RewardText()
    {
        Debug.Log("Reward Text coroutine trigger");
        yield return new WaitForSeconds(1f);
        techReward.SetActive(true);
        techText.material.color = Color.yellow;

        requirementsEmpty.SetActive(false);
        //yield return null;

    }

    //this should be conditional on if previous techs are researched but...I don't have time...
    private void OnTriggerEnter(Collider other)
    {
        if ((techActive != true) && (other.transform.CompareTag("Player")))
        {
            Debug.Log("Tech is triggered");
            scoreIntGlobal += scoreToAdd;
            technologyInformation = GlobalControl.Instance.technologyInformation;
            technologyInformation += techThis;
            GlobalControl.Instance.technologyInformation = technologyInformation;

        }
    }
}
