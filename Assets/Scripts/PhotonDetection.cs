using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonDetection : MonoBehaviour
{

    private GameObject Enemy;
    private EnemyFollow EnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = this.transform.parent.gameObject;
        EnemyScript = Enemy.GetComponent<EnemyFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy") && other.gameObject.name != "Photon(Clone)")
        {
            //print("Choqué con " + other.gameObject.name);
            if (other.CompareTag("Player"))
            {
                EnemyScript.Seen = true;
            }
            else
            {
                EnemyScript.Seen = false;
            }
            Destroy(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //print(other.gameObject.name);
        if(other.gameObject.name == "Sight")
        {
            Destroy(this);
        }
    }
}
