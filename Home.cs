using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newGame()
    {
      GlobalVariables.newGame = true;
      SceneManager.LoadScene("Intro Video");
    }

    public void continueGame()
    {
      GlobalVariables.newGame = false;
      SceneManager.LoadScene("AreaSelectionScene");
    }
}
