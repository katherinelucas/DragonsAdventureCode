using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CastleWin : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip dialog1;
    public AudioClip dialog2;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public bool isFinished = false;
    public GameObject arrow;
    public Button speakerButton;
    public GameObject textBg;
    public GameObject princessSpeaker;
    // Start is called before the first frame update
    void Start()
    {
      arrow.SetActive(false);
    }

    public void Home()
    {
      SceneManager.LoadScene("HomeScreenScene");
    }

    public void AreaSelection()
    {
      SceneManager.LoadScene("AreaSelectionScene");
    }

    // Update is called once per frame
    void Update()
    {
      if(textDisplay.text==sentences[index])
      {
        continueButton.SetActive(true);
      }
    }

    public void Back()
    {
      SceneManager.LoadScene("AreaSelectionScene");
    }

    public void Castle()
    {
      if(GlobalVariables.kingdomWon == false)
      {
        SceneManager.LoadScene("BallRoomScene");
      }
      else if(GlobalVariables.kingdomWon == true)
      {
        SceneManager.LoadScene("BallRoomWinScene");
      }
    }

    public void startDialog()
    {
      speakerButton.interactable = false;
      StartCoroutine(Type());
    }

    IEnumerator Type()
    {
      if(index==0)
      {
        sound.PlayOneShot(dialog1);
        princessSpeaker.SetActive(true);
        textBg.SetActive(true);
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
        // textBg.SetActive(true);
        index++;
        if(index==1)
        {
          // princessSpeaker.SetActive(true);
          sound.PlayOneShot(dialog2);
        }
        textDisplay.text = "";
        StartCoroutine(Type());
      }
      else
      {
        textBg.SetActive(false);
        princessSpeaker.SetActive(false);
        textDisplay.text = "";
        continueButton.SetActive(false);
        arrow.SetActive(true);
        isFinished = true;
      }
    }
}
