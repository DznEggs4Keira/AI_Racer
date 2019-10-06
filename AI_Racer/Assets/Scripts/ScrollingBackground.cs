using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    Material ScrollingMaterial;
    Vector2 offset;

    int xValue = 0;
    int yValue = 5;

    private void Awake()
    {
        ScrollingMaterial = GetComponent<MeshRenderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xValue, yValue);
    }

    // Update is called once per frame
    void Update()
    {
        ScrollingMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
