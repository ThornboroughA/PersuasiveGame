using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatchScript : MonoBehaviour
{
    public GameObject player;
    public GameObject resetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")) {

            Debug.Log("Catch script collision");
            //player.transform.Translate(new Vector3(0, 0, 0));

            StartCoroutine(PlayerCatch());
         
        }
        
    }

    private IEnumerator PlayerCatch()
    {
        player.GetComponent<Character>().enabled = false;

        player.transform.position = resetObject.transform.position;

        yield return new WaitForSeconds(0.1f);

        player.GetComponent<Character>().enabled = true;
    }

}
