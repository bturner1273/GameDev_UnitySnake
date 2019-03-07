using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadController : MonoBehaviour
{
    private InputHandler ih;
    private float OFFSET;
    public float INITIAL_MOVEMENT_INTERVAL;
    private float movement_interval;
    private PositionManager pm;

    // Start is called before the first frame update
    void Start()
    {
        ih = GetComponent<InputHandler>();
        movement_interval = INITIAL_MOVEMENT_INTERVAL;
        OFFSET = 1.0f;
        pm = GetComponent<PositionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetActive())
        {
            if (movement_interval - Time.deltaTime >= 0)
            {
                movement_interval -= Time.deltaTime;
            }
            else
            {
                movement_interval = INITIAL_MOVEMENT_INTERVAL;
                if (ih.GetCurrentDirection() == DIRECTION.UP)
                {
                    transform.Translate(Vector2.up * OFFSET);
                }
                else if (ih.GetCurrentDirection() == DIRECTION.DOWN)
                {
                    transform.Translate(Vector2.down * OFFSET);
                }
                else if (ih.GetCurrentDirection() == DIRECTION.LEFT)
                {
                    transform.Translate(Vector2.left * OFFSET);
                }
                else if (ih.GetCurrentDirection() == DIRECTION.RIGHT)
                {
                    transform.Translate(Vector2.right * OFFSET);
                }
                pm.SetCurrentLocation(transform.position);
                BodyUpdater.UpdateBody(transform.parent);
                //added code to stop the game and show game over if the Snake Head goes off
                //the screen
                if (transform.position.x < -SpawnManager.MAX_X || transform.position.x > SpawnManager.MAX_X
                    || transform.position.y < -SpawnManager.MAX_Y || transform.position.y > SpawnManager.MAX_Y)
                {
                    GameManager.SetActive(false, false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            if (collision.gameObject.GetComponent<PositionManager>().GetIsBody())
            {
                GameManager.SetActive(false, false);
            } else
            {
                GameManager.SetScore(GameManager.GetScore() + 10);
                collision.gameObject.transform.parent = transform.parent;
                collision.gameObject.GetComponent<PositionManager>().SetIsBody(true);
                //if (transform.parent.childCount >= ((2*SpawnManager.MAX_X) * (2*SpawnManager.MAX_Y)))
                //{
                //    GameManager.SetActive(false, true);
                //}
                SpawnManager.DecrementNumSpawns();

            }
        }
    }
}
