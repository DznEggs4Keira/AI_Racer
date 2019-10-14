using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyController : MonoBehaviour
{
    public GameObject UI;
    public GameObject player;
    public Vector2 playerPos;

    FuzzyForm.Fuzzy F1 = new FuzzyForm.Fuzzy();

    Vector2 car_velocity;
    Vector2 car_position;

    // Start is called before the first frame update
    void Start()
    {
        car_velocity = new Vector2(30, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // get most recent positions of car and control line
        car_position = this.transform.position;
        playerPos = player.transform.position;

        //Debug.Log("Player Position: " + playerPos);

        //-Value means car is to the left, +Value means car is to the right -- distance
        float distance = car_position.x - playerPos.x;
        //Debug.Log("Distance: " + distance);

        float velocity = car_velocity.x;
        //Debug.Log("Velocity: " + velocity);

        //send data
        F1.RunFuzzy(distance, velocity);
        UpdateVelocity();

        //Move
        Move();
    }

    private void UpdateVelocity()
    {
        car_velocity.x += F1.ReturnVal() * Time.deltaTime;
        //Debug.Log(car_velocity);
    }

    private void Move()
    {
        car_position += car_velocity * Time.deltaTime;

        //set the new car position
        this.transform.position = car_position;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemies")
        {
            Debug.Log("AAA i hit " + collision.gameObject.tag); //this is working
            //Call game over when collision
            UIManagerScript script = UI.GetComponent<UIManagerScript>();
            //script.Reload();
            script.isGameOver = true;

        }
    }
}
