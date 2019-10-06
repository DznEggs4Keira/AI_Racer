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
        car_velocity = new Vector2(5, 0);
        car_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //-Value means car is to the left, +Value means car is to the right -- distance
        float distance = (car_position.x + 20.0f) - (controller.position.x + 50.0f);
        float velocity = car_velocity.x;

        //send data
        F1.RunFuzzy(distance, velocity);

        car_velocity.x += F1.ReturnVal() * Time.deltaTime;
    }
}
