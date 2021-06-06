using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Arcade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Home()
    {
      SceneManager.LoadScene("HomeScreenScene");
    }

    public void Back()
    {
      SceneManager.LoadScene("AreaSelectionScene");
    }

    public void RPS()
    {
      SceneManager.LoadScene("RPSArcadeScene");
    }

    public void Matching()
    {
      SceneManager.LoadScene("ArcadeMatch");
    }

    public void Hidden()
    {
       SceneManager.LoadScene("ArcadeHiddenObjectGame");
    }

    public void DressUp()
    {
      SceneManager.LoadScene("DressUpArcade");
    }

}
