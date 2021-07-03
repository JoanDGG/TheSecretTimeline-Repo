using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    new private Rigidbody2D rigidbody;
    private GameObject Enemy;
    private bool Seen;
    private float movHorizontal;
    private float movVertical;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = this.transform.parent.gameObject;
        rigidbody = Enemy.GetComponent<Rigidbody2D>();
        Seen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Seen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Seen = false;
            //while
            if (!Seen && Enemy.transform.position.x != 0 && Enemy.transform.position.y != 3.4)
            {
                movHorizontal = 0;
                movVertical = 0;
                if (Enemy.transform.position.x < 0)
                {
                    movHorizontal = 0.5f;
                }
                else if (Enemy.transform.position.x > 0)
                {
                    movHorizontal = -0.5f;
                }
                if (Enemy.transform.position.y < 3.4)
                {
                    movVertical = 0.5f;
                }
                else if (Enemy.transform.position.y > 3.4)
                {
                    movVertical = -0.5f;
                }
                rigidbody.velocity = new Vector2(movHorizontal, movVertical);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject Player = other.gameObject;
            movHorizontal = 0;
            movVertical = 0;
            //print("I, " + Enemy.name + ", see you " + Player.name);
            if(Player.transform.position.x > Enemy.transform.position.x)
            {
                movHorizontal = 1;
                //print("Moving Right...");
            }
            else if(Player.transform.position.x < Enemy.transform.position.x)
            {
                movHorizontal = -1;
                //print("Moving Left...");
            }
            if (Player.transform.position.y > Enemy.transform.position.y)
            {
                movVertical = 1;
                //print("Moving Up...");
            }
            else if (Player.transform.position.y < Enemy.transform.position.y)
            {
                movVertical = -1;
                //print("Moving Down...");
            }
            rigidbody.velocity = new Vector2(movHorizontal, movVertical);
        }
    }
}
