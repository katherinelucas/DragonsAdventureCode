using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CastleFinal : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip dialog1;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public bool isFinished = false;
    public Button speakerButton;
    public GameObject textBg;
    public GameObject princessSpeaker;
    // Start is called before the first frame update
    void Start()
    {
      GlobalVariables.kingdomWon=true;
    }

    public void Home()
    {
      SceneManager.LoadScene("HomeScreenScene");
    }

    public void AreaSelection()
    {
      GlobalVariables.dressUpWon = true;
      GlobalVariables.kingdomWon=true;
      SceneManager.LoadScene("AreaSelectionScene");
    }

    // Update is called once per frame
    void Update()
    {
      GlobalVariables.dressUpWon = true;
      GlobalVariables.kingdomWon=true;
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
      textBg.SetActive(false);
      princessSpeaker.SetActive(false);
      textDisplay.text = "";
      continueButton.SetActive(false);
      isFinished = true;
    }
}
