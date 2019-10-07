using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyController : MonoBehaviour
{
    public GameObject player;
    PlayerController controller;

    FuzzyForm.Fuzzy F1 = new FuzzyForm.Fuzzy();

    Vector2 car_velocity;
    Vector2 car_position;

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<PlayerController>();

        //Set initial velocity and position
        car_velocity = new Vector2(30, 0);
        //car_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // get most recent position
        car_position = transform.position;

        //-Value means car is to the left, +Value means car is to the right -- distance
        float distance = car_position.x - controller.position.x;
        float velocity = car_velocity.x;

        //send data
        F1.RunFuzzy(distance, velocity);

        car_position.x += F1.ReturnVal() * Time.deltaTime; //Speed * Time
        transform.position = car_position;
    }
}
