using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
  public AudioSource sound;
  public AudioClip dialog1;
  public AudioClip dialog2;
  public AudioClip dialog3;
  public AudioClip dialog4;

  public TextMeshProUGUI textDisplay;
  public string[] sentences;
  private int index;
  public float typingSpeed;
  public GameObject continueButton;
  public Button speakerButton;
  public bool isFinished = false;
  public GameObject textBg;
  public GameObject princessSpeaker;
  public GameObject dragonSpeaker;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void AreaSelection()
    {
      SceneManager.LoadScene("AreaSelectionScene");
    }

    public void Home()
    {
      SceneManager.LoadScene("HomeScreenScene");
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
        SceneManager.LoadScene("DressUp");
      }
    }

    public void Back()
    {
      SceneManager.LoadScene("AreaSelectionScene");
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
        textBg.SetActive(true);
        princessSpeaker.SetActive(true);
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
      textBg.SetActive(true);
      index++;
      if(index==1)
      {
        princessSpeaker.SetActive(false);
        sound.PlayOneShot(dialog2);
        dragonSpeaker.SetActive(true);
      }
      else if(index==2)
      {
        dragonSpeaker.SetActive(false);
        sound.PlayOneShot(dialog3);
        princessSpeaker.SetActive(true);
      }
      else if(index==3)
      {
        sound.PlayOneShot(dialog4);
        princessSpeaker.SetActive(true);
      }
      textDisplay.text = "";
      StartCoroutine(Type());
    }
    else
    {
      princessSpeaker.SetActive(false);
      dragonSpeaker.SetActive(false);
      textBg.SetActive(false);
      // index++;
      textDisplay.text = "";
      continueButton.SetActive(false);
      isFinished = true;
    }
  }
}
