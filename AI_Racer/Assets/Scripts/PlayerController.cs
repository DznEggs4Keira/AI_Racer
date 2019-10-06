using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float Horizontal; //what side is the player wanting to move the line to in the horizontal axis
    float amount = 3.5f; //by what speed it should move

    public Vector2 position { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //store the direction in the horiozntal axis
        Horizontal = Input.GetAxis("Horizontal");

        //Create a vector which will store which direction to move in
        Vector2 move = new Vector2(Horizontal, 0);

        //create a vector which will store the current transform's pos
        position = transform.position;

        //increment it with the direction * the amount(speed) and then delta time to have movement be per second rather than per frame
        position += move * amount * Time.deltaTime;

        //set the new incremented position as the current value of the transform
       transform.position = position;
    }
}
