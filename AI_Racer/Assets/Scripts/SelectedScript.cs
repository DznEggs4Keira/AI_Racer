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
        if(Selection.FSM == true)
        {
            foreach (GameObject f in FSMObjects)
            {
                f.SetActive(true);
            }

            foreach (GameObject f in FuzzyObjects)
            {
                f.SetActive(false);
            }
        }

        else if (Selection.FSM == false)
        {
            foreach (GameObject fu in FuzzyObjects)
            {
                fu.SetActive(true);
            }

            foreach (GameObject fu in FSMObjects)
            {
                fu.SetActive(false);
            }
        }
    }
    
}
