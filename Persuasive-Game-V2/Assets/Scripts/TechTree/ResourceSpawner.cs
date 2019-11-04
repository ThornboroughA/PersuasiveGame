using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{

    public int availableGold;
    public int availableBerries;
    public int availableWood;

    public GameObject goldObject;
    public GameObject berriesObject;
    public GameObject woodObject;

    // Start is called before the first frame update
    void Start()
    {
        availableGold = GlobalControl.Instance.availableGold;
        availableBerries = GlobalControl.Instance.availableBerries;
        availableWood = GlobalControl.Instance.availableWood;

        //Vector3 randomPosition = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
        //Vector3 randomPosition = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        //Instantiate(resourceOne, transform.position + randomPosition, transform.rotation);

        for (int i = 0; i < availableGold; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            Instantiate(goldObject, transform.position + randomPosition, transform.rotation);
        }
        for (int i = 0; i < availableBerries; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            Instantiate(berriesObject, transform.position + randomPosition, transform.rotation);
        }
        for (int i = 0; i < availableWood; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            Instantiate(woodObject, transform.position + randomPosition, transform.rotation);
        }




        //}

    }
}
