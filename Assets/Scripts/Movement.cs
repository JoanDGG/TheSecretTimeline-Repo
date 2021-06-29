using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidad = 7;
    new private Rigidbody2D rigidbody;
    private float movHorizontal;
    private float movVertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        GameObject.Find("TalkButton").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.blockMovement)
        {
            movHorizontal = Input.GetAxis("Horizontal");
            movVertical = Input.GetAxis("Vertical");
        }
        rigidbody.velocity = new Vector2(movHorizontal * velocidad, movVertical * velocidad);
    }
}
