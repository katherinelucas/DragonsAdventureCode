using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Home()
    {
      SceneManager.LoadScene("HomeScreenScene");
    }

    IEnumerator Wait()
    {
      yield return new WaitForSeconds(8);
      SceneManager.LoadScene("CreditsScene");
    }
}
