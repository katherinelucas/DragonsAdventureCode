using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerArcade : MonoBehaviour
{
    enum elements {Rock , Paper , Scissors}
    private int playerChoice = -1;
    private int computerChoice = -1;
    private bool playerTurn = true;
    public GameObject WinnerText;
    public Sprite rock, paper, scissors, princeRock, princePaper, princeScissors;
    public GameObject computerImage;
    public GameObject computerScissors;
    public GameObject computerRock;
    public GameObject winImage;
    public bool playerWin = false;

    public void Home()
    {
      SceneManager.LoadScene("HomeScreenScene");
    }

    public void Back()
    {
      SceneManager.LoadScene("ArcadeScene");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTurn && playerChoice==-1)
        {
          return;
        }
        if(playerWin==true)
        {
          //end game
          Application.Quit();
        }
        else
        {
          ComputerChoice();
          WinCheck();
          playerTurn = true;
          playerChoice = -1;
        }
    }

    public void PlayerChoice(int choice)
    {
      playerChoice = choice;
      playerTurn = false;
      computerRock.SetActive(false);
      computerScissors.SetActive(false);
    }

    public void ComputerChoice()
    {
      computerChoice = Random.Range(1, 4);

      if(computerChoice==1)
      {
        computerImage.GetComponent<Image>().sprite = princeRock;
      }
      else if(computerChoice==2)
      {
        computerImage.GetComponent<Image>().sprite = princePaper;
      }
      else
      {
        computerImage.GetComponent<Image>().sprite = princeScissors;
      }
    }

    private void WinCheck()
    {
      if(playerChoice==computerChoice)
      {
        //tie
        WinnerText.GetComponent<Text>().text = "TIE! TRY AGAIN!";
      }
      else if(playerChoice==2 && computerChoice==1)
      {
        //pwin
        WinnerText.GetComponent<Text>().text = "";
        winImage.SetActive(true);
        playerWin=true;
        StartCoroutine(Wait());
        // SceneManager.LoadScene("BallRoomWinScene");
      }
      else if(playerChoice==1 && computerChoice==2)
      {
        //cwim
        WinnerText.GetComponent<Text>().text = "YOU LOSE! TRY AGAIN!";
      }
      else if(playerChoice==3 && computerChoice==2)
      {
        //pwin
        WinnerText.GetComponent<Text>().text = "";
        winImage.SetActive(true);
        playerWin=true;
        StartCoroutine(Wait());

      }
      else if(playerChoice==2 && computerChoice==3)
      {
        //cwin
        WinnerText.GetComponent<Text>().text = "YOU LOSE! TRY AGAIN!";
      }
      else if(playerChoice==1 && computerChoice==3)
      {
        //pwin
        WinnerText.GetComponent<Text>().text = "";
        winImage.SetActive(true);
        playerWin=true;
        StartCoroutine(Wait());
        // SceneManager.LoadScene("BallRoomWinScene");
      }
      else if(playerChoice==3 && computerChoice==1)
      {
        //cwin
        WinnerText.GetComponent<Text>().text = "YOU LOSE! TRY AGAIN!";
      }
    }

    IEnumerator Wait()
    {
      yield return new WaitForSeconds(2);
      // GlobalVariables.kingdomWon = true;
      SceneManager.LoadScene("ArcadeScene");
    }
}
