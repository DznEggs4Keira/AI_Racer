using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    GameObject[] FSMObjects;
    GameObject[] FuzzyObjects;

    public static bool FSM;

    // Start is called before the first frame update
    void Start()
    {
        FSMObjects = GameObject.FindGameObjectsWithTag("CarSelectFSM");
        FuzzyObjects = GameObject.FindGameObjectsWithTag("CarSelectFuzzy");
 
        Back();
    }

    public void Next()
    {
        foreach (GameObject g in FSMObjects)
        {
            g.SetActive(false);
        }

        foreach (GameObject g in FuzzyObjects)
        {
            g.SetActive(true);
        }

        FSM = false;
    }

    public void Back()
    {
        foreach (GameObject g in FSMObjects)
        {
            g.SetActive(true);
        }

        foreach (GameObject g in FuzzyObjects)
        {
            g.SetActive(false);
        }

        FSM = true;
    }
}
