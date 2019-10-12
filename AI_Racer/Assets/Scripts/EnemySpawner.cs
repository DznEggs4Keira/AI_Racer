using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    int randomEnemyIndex;

    static float yOffset = -1.0f;

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies(); //can't call it here.... call every 10 seconds.... make a counter like ruby
    }

    void SpawnEnemies()
    {
        if(Random.Range (0, 10) > 7)
        {
           randomEnemyIndex = Random.Range(0, enemies.Length);
        }

        //Enemies
        switch(randomEnemyIndex)
        {
            //Tires
            case 0:
                {
                    Instantiate(enemies[randomEnemyIndex], new Vector3(0, transform.position.y, 0), Quaternion.identity);
                    break;
                }
            //Car
            case 1:
                {
                    Instantiate(enemies[randomEnemyIndex], new Vector3(3.2f, transform.position.y, 0), Quaternion.identity);
                    break;
                }
            //Car
            case 2:
                {
                    Instantiate(enemies[randomEnemyIndex], new Vector3(-1.2f, -transform.position.y, 0), Quaternion.identity);
                    break;
                }
            //Car
            case 3:
                {
                    Instantiate(enemies[randomEnemyIndex], new Vector3(2.2f, -transform.position.y, 0), Quaternion.identity);
                    break;
                }
            //Car
            case 4:
                {
                    Instantiate(enemies[randomEnemyIndex], new Vector3(-3.2f, transform.position.y, 0), Quaternion.identity);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
