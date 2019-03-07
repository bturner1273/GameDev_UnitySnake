using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject snake; //so we can check that we aren't spawning an apple on the Snake
    public GameObject toSpawn; //reference to our apple object

    public int MAX_SPAWNS; //this will be one for Snake
    private static int num_spawns;
        
    public static float MAX_X = 17.5f;
    public static float MAX_Y = 7.5f;

    private void Start()
    {
        num_spawns = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (num_spawns < MAX_SPAWNS)
        {
            bool valid;
            Vector3 random_position;
            do
            {
                valid = true;
                float spawn_x = Mathf.Floor(Random.Range(-MAX_X, MAX_X)) + .5f;
                float spawn_y = Mathf.Floor(Random.Range(-MAX_Y, MAX_Y)) + .5f;
                random_position = new Vector3(spawn_x, spawn_y, 1);
                foreach (Transform child in snake.transform)
                {
                    if (random_position == child.transform.position)
                    {
                        valid = false;
                    }
                }
            } while (!valid);
            Instantiate(toSpawn, random_position, Quaternion.identity);
            num_spawns++;
        }       
    }

    public static void DecrementNumSpawns ()
    {
        num_spawns--;
    }
}
