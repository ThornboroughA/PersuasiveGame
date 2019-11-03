using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    //public float goldMineStatus;
    public string resourcesInformation;
    public string technologyInformation;
    public int scoreIntGlobal;

    //resource counts
    public int availableGold;
    public int availableBerries;
    public int availableWood;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




    }
}
