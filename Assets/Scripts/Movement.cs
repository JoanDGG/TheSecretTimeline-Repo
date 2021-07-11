using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float velocidad = 7;
    new private Rigidbody2D rigidbody;
    private float movHorizontal;
    private float movVertical;
    private Animator anim;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        GameManager.scene = SceneManager.GetActiveScene().buildIndex + 1;
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject.Find("TalkButton").SetActive(false);
        LoadLocationPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.blockMovement)
        {
            movHorizontal = Input.GetAxis("Horizontal");
            movVertical = Input.GetAxis("Vertical");
        }
        Vector2 move = new Vector2(movHorizontal, movVertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        anim.SetFloat("Look X", lookDirection.x);
        anim.SetFloat("Look Y", lookDirection.y);
        anim.SetFloat("Speed", move.magnitude);

        rigidbody.velocity = new Vector2(movHorizontal * velocidad, movVertical * velocidad);
    }

    public void SaveLocationPlayer()
    {
        print(transform.position);
        transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        print(transform.position);
        if (GameManager.scene == 2)
        {
            GameManager.position_apocalipsis = transform.position;
        }

        else if (GameManager.scene == 3)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 2);
            GameManager.position_puertas = transform.position;
        }

        else if (GameManager.scene == 4)
        {
            GameManager.position_prehistoria = transform.position;
        }

        else if (GameManager.scene == 5)
        {
            GameManager.position_80 = transform.position;
        }

        else if (GameManager.scene == 6)
        {
            GameManager.position_wwii = transform.position;
        }

        else if (GameManager.scene == 7)
        {
            GameManager.position_covid = transform.position;
        }

        else if (GameManager.scene == 8)
        {
            GameManager.position_futurama = transform.position;
        }
    }

    public void LoadLocationPlayer()
    {
        if (GameManager.scene == 2)
        {
            gameObject.transform.position = GameManager.position_apocalipsis;
        }

        else if (GameManager.scene == 3)
        {
            gameObject.transform.position = GameManager.position_puertas;
        }

        else if (GameManager.scene == 4)
        {
            gameObject.transform.position = GameManager.position_prehistoria;
        }

        else if (GameManager.scene == 5)
        {
            gameObject.transform.position = GameManager.position_80;
        }

        else if (GameManager.scene == 6)
        {
            GameManager.position_wwii = gameObject.transform.position;
        }

        else if (GameManager.scene == 7)
        {
            GameManager.position_covid = gameObject.transform.position;
        }

        else if (GameManager.scene == 8)
        {
            GameManager.position_futurama = gameObject.transform.position;
        }
        print(gameObject.transform.position);
    }
}
