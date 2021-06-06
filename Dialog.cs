using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
  public AudioSource sound;
  public AudioClip dialog1;
  public AudioClip dialog2;
  public AudioClip dialog3;

  public Sprite dog1;
  public Sprite dog2;
  public SpriteRenderer spriteRenderer;
  public TextMeshProUGUI textDisplay;
  public string[] sentences;
  private int index;
  public float typingSpeed;
  public GameObject continueButton;
  public Button speakerButton;
  public GameObject textBg;
  public GameObject princeSpeaker;
  public GameObject dragonSpeaker;
  // public GameObject dog;
  public bool isFinished = false;

  void Start()
  {
        // spriteRenderer = GetComponent<SpriteRenderer>();
  }

  public void AreaSelection()
  {
    SceneManager.LoadScene("AreaSelectionScene");
  }

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
    if(isFinished == true)
    {
      SceneManager.LoadScene("RPSScene");
    }
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
       princeSpeaker.SetActive(false);
       dragonSpeaker.SetActive(true);
       sound.PlayOneShot(dialog2);
     }
     else if(index==2)
     {
       dragonSpeaker.SetActive(false);
       princeSpeaker.SetActive(true);
       sound.PlayOneShot(dialog3);
     }
     textDisplay.text = "";
     StartCoroutine(Type());
   }
   else
   {
     // index++;
     princeSpeaker.SetActive(false);
     dragonSpeaker.SetActive(false);
     textBg.SetActive(false);
     textDisplay.text = "";
     continueButton.SetActive(false);
     isFinished = true;
   }
 }

 public void changeDog()
 {
   spriteRenderer.sprite = dog2;
   StartCoroutine(Wait());
   spriteRenderer.sprite = dog1;
 }

 IEnumerator Wait()
 {
    yield return new WaitForSeconds(2);
 }
}
