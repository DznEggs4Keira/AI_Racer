using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedScript : MonoBehaviour
{
    GameObject[] FSMObjects;
    GameObject[] FuzzyObjects;

    // Start is called before the first frame update
    void Start()
    {
        FSMObjects = GameObject.FindGameObjectsWithTag("CarSelectFSM");
        FuzzyObjects = GameObject.FindGameObjectsWithTag("CarSelectFuzzy");

        Set();
    }

    void Set()
    {
        if(Selection.FSM)
        {
            foreach (GameObject g in FSMObjects)
            {
                g.SetActive(true);
            }

            foreach (GameObject g in FuzzyObjects)
            {
                g.SetActive(false);
            }
        }

        else
        {
            foreach (GameObject g in FuzzyObjects)
            {
                g.SetActive(true);
            }

            foreach (GameObject g in FSMObjects)
            {
                g.SetActive(false);
            }
        }
    }
    
}
