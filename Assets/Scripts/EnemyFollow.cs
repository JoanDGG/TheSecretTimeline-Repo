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
    private float OriginX;
    private float OriginY;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = this.transform.parent.gameObject;
        rigidbody = Enemy.GetComponent<Rigidbody2D>();
        OriginX = Enemy.transform.position.x;
        OriginY = Enemy.transform.position.y;
        Seen = false;
        print(OriginX);
        print(OriginY);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceX = Mathf.Abs(Enemy.transform.position.x - OriginX);
        float distanceY = Mathf.Abs(Enemy.transform.position.y - OriginY);
        if (!Seen && (distanceX > 0.1f || distanceY > 0.1f))
        {
            if (OriginX > Enemy.transform.position.x)
            {
                movHorizontal = 1;
                //print("Moving Right...");
            }
            else if (OriginX < Enemy.transform.position.x)
            {
                movHorizontal = -1;
                //print("Moving Left...");
            }
            if (OriginY > Enemy.transform.position.y)
            {
                movVertical = 1;
                //print("Moving Up...");
            }
            else if (OriginY < Enemy.transform.position.y)
            {
                movVertical = -1;
                //print("Moving Down...");
            }
            rigidbody.velocity = new Vector2(movHorizontal, movVertical);
        }
        else if(!Seen)
        {
            rigidbody.velocity = new Vector2(0, 0);
        }
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
