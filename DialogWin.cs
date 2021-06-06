using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogWin : MonoBehaviour
{
  public AudioSource sound;
  public AudioClip dialog1;
  public AudioClip dialog2;

  public TextMeshProUGUI textDisplay;
  public string[] sentences;
  private int index;
  public float typingSpeed;
  public GameObject continueButton;
  public Button speakerButton;
  public bool isFinished = false;
  public GameObject textBg;
  public GameObject princeSpeaker;

  public void Back()
  {
    if(GlobalVariables.dressUpWon == true && GlobalVariables.kingdomWon == true)
    {
      SceneManager.LoadScene("CastleFinal");
    }
    else if(GlobalVariables.dressUpWon == true && GlobalVariables.kingdomWon == false)
    {
      SceneManager.LoadScene("CastleWinScene");
    }
    else
    {
      SceneManager.LoadScene("CastleScene");
    }
  }

  public void AreaSelection()
  {
    SceneManager.LoadScene("AreaSelectionScene");
  }

  void Start()
  {

  }

  public void Home()
  {
    SceneManager.LoadScene("HomeScreenScene");
  }

  public void startDialog()
  {
    speakerButton.interactable = false;
    StartCoroutine(Type());
  }

  // Update is called once per frame
  void Update()
  {
    if(textDisplay.text==sentences[index])
    {
      continueButton.SetActive(true);
    }
    // if(isFinished == true)
    // {
    //   SceneManager.LoadScene("RPSScene");
    // }
  }

 IEnumerator Type()
 {
   if(index==0)
   {
     textBg.SetActive(true);
     princeSpeaker.SetActive(true);
     sound.PlayOneShot(dialog1);
   }

   foreach(char letter in sentences[index].ToCharArray())
   {
     textDisplay.text += letter;
     yield return new WaitForSeconds(0.02f);
   }
 }

 public void nextSentence()
 {
   continueButton.SetActive(false);
   if(index < sentences.Length-1)
   {
     index++;
     if(index==1)
     {
       sound.PlayOneShot(dialog2);
     }
     textDisplay.text = "";
     StartCoroutine(Type());
   }
   else
   {
     textBg.SetActive(false);
     princeSpeaker.SetActive(false);
     textDisplay.text = "";
     continueButton.SetActive(false);
     isFinished = true;
   }
 }
}
