using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    new private Rigidbody2D rigidbody;
    private GameObject Enemy;
    public bool Seen;
    private float movHorizontal;
    private float movVertical;
    private float OriginX;
    private float OriginY;
    public GameObject Photon;
    private float PlayerPositionX;
    private float PlayerPositionY;
    private float EnemyPositionX;
    private float EnemyPositionY;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = this.transform.parent.gameObject;
        rigidbody = Enemy.GetComponent<Rigidbody2D>();
        OriginX = Enemy.transform.position.x;
        OriginY = Enemy.transform.position.y;
        Seen = false;
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
        if (other.CompareTag("Player") && GameManager.Alive)
        {
            GameObject Player = other.gameObject;
            PlayerPositionX = Player.transform.position.x;
            PlayerPositionY = Player.transform.position.y;
            EnemyPositionX = Enemy.transform.position.x;
            EnemyPositionY = Enemy.transform.position.y;
            float Multiplier = 3;
            float SpeedX = PlayerPositionX - EnemyPositionX;
            float SpeedY = PlayerPositionY - EnemyPositionY;
            GameObject photon = Instantiate(Photon, new Vector2(EnemyPositionX, EnemyPositionY), Quaternion.identity);
            photon.transform.SetParent(this.transform);
            photon.GetComponent<Rigidbody2D>().velocity = new Vector2(SpeedX * Multiplier, SpeedY * Multiplier);
            Destroy(photon, 1.0f / Multiplier);
        }
        if (other.CompareTag("Player") && Seen && GameManager.Alive)
        {
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
