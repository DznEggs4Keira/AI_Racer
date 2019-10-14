using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    float cameraY;

    // Start is called before the first frame update
    void Start()
    {
        cameraY = Camera.main.transform.position.y - 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < cameraY)
        {
            Destroy(gameObject);
        }
    }
}
