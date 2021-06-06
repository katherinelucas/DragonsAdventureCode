using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static bool dressUpWon;
    public static bool kingdomWon;
    public static bool lagoonWon;
    public static bool lagoonMatchWon;
    public static bool forestWon;
    public static bool newGame;

    // Start is called before the first frame update
    void Start()
    {
      if(newGame==true)
      {
        dressUpWon = false;
        kingdomWon = false;
        lagoonWon = false;
        lagoonMatchWon = false;
        forestWon = false;
      }
    }

    // Update is called once per frame
    void Update()
    {
      if(newGame==true)
      {
        dressUpWon = false;
        kingdomWon = false;
        lagoonWon = false;
        lagoonMatchWon = false;
        forestWon = false;
      }
    }
}
