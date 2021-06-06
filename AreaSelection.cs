using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AreaSelection : MonoBehaviour
{
    // bool mapPiece1Unlocked = false;
    // bool mapPiece2Unlocked = false;
    // bool mapPiece3Unlocked = false;
    public GameObject mapPiece1;
    public GameObject mapPiece2;
    public GameObject mapPiece3;
    public GameObject completeMap;
    // Start is called before the first frame update
    void Start()
    {
      mapPiece1.SetActive(false);
      mapPiece2.SetActive(false);
      mapPiece3.SetActive(false);
      completeMap.SetActive(false);
    }

    public void Home()
    {
      SceneManager.LoadScene("HomeScreenScene");
    }

    // Update is called once per frame
    void Update()
    {
      if(GlobalVariables.kingdomWon == true && GlobalVariables.forestWon == true && GlobalVariables.lagoonWon == true)
      {
        completeMap.SetActive(true);
        mapPiece1.SetActive(false);
        mapPiece2.SetActive(false);
        mapPiece3.SetActive(false);
      }
      else if(GlobalVariables.kingdomWon == true && GlobalVariables.lagoonWon == true)
      {
        mapPiece1.SetActive(true);
        mapPiece3.SetActive(true);
      }
      else if(GlobalVariables.kingdomWon == true && GlobalVariables.forestWon == true)
      {
        mapPiece1.SetActive(true);
        mapPiece2.SetActive(true);
      }
      else if(GlobalVariables.lagoonWon == true && GlobalVariables.forestWon == true)
      {
        mapPiece3.SetActive(true);
        mapPiece2.SetActive(true);
      }
      else if(GlobalVariables.kingdomWon == true)
      {
        mapPiece1.SetActive(true);
      }
      else if(GlobalVariables.forestWon == true)
      {
        mapPiece2.SetActive(true);
      }
      else if(GlobalVariables.lagoonWon == true)
      {
        mapPiece3.SetActive(true);
      }
    }

    public void Kingdom()
    {
      if(GlobalVariables.dressUpWon == true && GlobalVariables.kingdomWon == false)
      {
        SceneManager.LoadScene("CastleWinScene");
      }
      else if(GlobalVariables.dressUpWon == true && GlobalVariables.kingdomWon == true)
      {
        SceneManager.LoadScene("CastleFinal");
      }
      else
      {
        SceneManager.LoadScene("CastleScene");
      }
    }

    public void Lagoon()
    {
        if (GlobalVariables.lagoonWon == true && GlobalVariables.lagoonMatchWon == true)
        {
            SceneManager.LoadScene("BeachAfterHidden");
        }
        else if(GlobalVariables.lagoonMatchWon == true && GlobalVariables.lagoonWon == false)
        {
          SceneManager.LoadScene("BeachAfterMatch");
        }
        else
        {
            SceneManager.LoadScene("WelcomeBeach");
        }

    }

    public void Forest()
    {

    }

    public void EndGame()
    {
      SceneManager.LoadScene("MountainEnd");
    }

    public void Arcade()
    {
      SceneManager.LoadScene("ArcadeScene");
    }
}
