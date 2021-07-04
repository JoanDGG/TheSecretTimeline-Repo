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
    private GameObject Wall;

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
        else if (other.CompareTag("Wall"))
        {
            Wall = other.gameObject;
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
        if (other.CompareTag("Player") && Seen && GameManager.Alive)
        {
            GameObject Player = other.gameObject;
            float PlayerPositionX = Player.transform.position.x;
            float PlayerPositionY = Player.transform.position.y;
            float EnemyPositionX = Enemy.transform.position.x;
            float EnemyPositionY = Enemy.transform.position.y;
            if (Wall != null)
            {
                float WallPositionX = Wall.transform.position.x;
                float WallPositionY = Wall.transform.position.y;
                float WallDistanceX = Mathf.Abs(WallPositionX - PlayerPositionX);
                float WallDistanceY = Mathf.Abs(WallPositionY - PlayerPositionY);
                float EWallDistanceX = Mathf.Abs(WallPositionX - EnemyPositionX);
                float EWallDistanceY = Mathf.Abs(WallPositionY - EnemyPositionY);
                float EPlayerDistanceX = Mathf.Abs(PlayerPositionX - EnemyPositionX);
                float EPlayerDistanceY = Mathf.Abs(PlayerPositionY - EnemyPositionY);
                if ((WallDistanceX < 0.5f && EWallDistanceY < EPlayerDistanceY) || (EWallDistanceX < EPlayerDistanceX && WallDistanceY < 0.5F))
                {
                    //print("The player took cover...");
                    Seen = false;
                }
                else
                {
                    //print("The player lost cover...");
                    Seen = true;
                }
            }
            movHorizontal = 0;
            movVertical = 0;
            //print("I, " + Enemy.name + ", see you " + Player.name);
            if(PlayerPositionX > EnemyPositionX)
            {
                movHorizontal = 1;
                //print("Moving Right...");
            }
            else if(PlayerPositionX < EnemyPositionX)
            {
                movHorizontal = -1;
                //print("Moving Left...");
            }
            if (PlayerPositionY > EnemyPositionY)
            {
                movVertical = 1;
                //print("Moving Up...");
            }
            else if (PlayerPositionY < EnemyPositionY)
            {
                movVertical = -1;
                //print("Moving Down...");
            }
            rigidbody.velocity = new Vector2(movHorizontal, movVertical);
        }
    }
}
