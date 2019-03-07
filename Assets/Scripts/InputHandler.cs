using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DIRECTION
{
    UP, DOWN, LEFT, RIGHT
}


public class InputHandler : MonoBehaviour
{
    private DIRECTION current_dir;

    // Start is called before the first frame update
    void Start()
    {
        current_dir = DIRECTION.RIGHT;
    }

    // Update is called once per frame
    void Update()
    {
        float x_movement = Input.GetAxisRaw("Horizontal");
        float y_movement = Input.GetAxisRaw("Vertical");
        if (x_movement < 0 && current_dir != DIRECTION.RIGHT)
        {
            current_dir = DIRECTION.LEFT;
        }
        if (x_movement > 0 && current_dir != DIRECTION.LEFT) 
        {
            current_dir = DIRECTION.RIGHT;
        }
        if (y_movement < 0 && current_dir != DIRECTION.UP)
        {
            current_dir = DIRECTION.DOWN;
        }
        if (y_movement > 0 && current_dir != DIRECTION.DOWN)
        {
            current_dir = DIRECTION.UP;
        }
    }

    public DIRECTION GetCurrentDirection () {
        return current_dir;
    }
}
