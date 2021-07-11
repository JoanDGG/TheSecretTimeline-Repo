using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int scene = 1;
    /*
     Scenes:
         Menu           = 1
         Apocalipsis    = 2
         Puertas        = 3
         Prehistoria    = 4
         80             = 5
         WWII           = 6
         Covid          = 7
         Futurama       = 8
         Prehistoria 2  = 9
         */
    public static bool blockMovement = false;
    public static GameObject[] Inventory = new GameObject[3];
    public static bool Alive = true;
    public static Vector2 position_apocalipsis = new Vector2(0, 0);
    public static Vector2 position_puertas = new Vector2(0, 0);
    public static Vector2 position_prehistoria = new Vector2(0, 0);
    public static Vector2 position_80 = new Vector2(0, 0);
    public static Vector2 position_wwii = new Vector2(0, 0);
    public static Vector2 position_covid = new Vector2(0, 0);
    public static Vector2 position_futurama = new Vector2(0, 0);

    //Conseguir combustible en apocalipsis
    public static bool story1 = false;

    //Conseguir walkman en 80
    public static bool story2 = false;

    //Conseguir bata en futurama
    public static bool story3 = false;

    //Conseguir combustible en futurama
    public static bool story4 = false;

    //Conseguir sable en futurama
    public static bool story5 = false;
}
