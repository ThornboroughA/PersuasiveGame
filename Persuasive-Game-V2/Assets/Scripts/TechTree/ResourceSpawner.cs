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

        for (int i = 0; i < availableGold; i++)
        {
            Instantiate(goldObject, transform.position, transform.rotation);
        }
        for (int i = 0; i < availableBerries; i++)
        {
            Instantiate(berriesObject, transform.position, transform.rotation);
        }
        for (int i = 0; i < availableWood; i++)
        {
            Instantiate(woodObject, transform.position, transform.rotation);
        }

        //}

    }
}
