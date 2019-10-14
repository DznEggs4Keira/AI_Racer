using UnityEngine;
using System.Collections;

public class FSMController : MonoBehaviour
{
    public GameObject UI;
    public GameObject player;
    public Vector2 playerPos;

    FSMForm.FSMSystem F1 = new FSMForm.FSMSystem();

    Vector2 car_position;

    // Start is called before the first frame update
    void Start()
    {
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

        //send data
       float move = F1.RunFSM(distance);

        //Move
        Move(move);
    }

    private void Move(float deltaMove)
    {
        car_position.x += deltaMove * Time.deltaTime;

        //set the new car position
        this.transform.position = car_position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Call game over when collision
        UIManagerScript script = UI.GetComponent<UIManagerScript>();
        script.isGameOver = true;
    }
}
