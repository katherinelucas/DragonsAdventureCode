using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSprite1 : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip dialog1;
    private SpriteRenderer renderer;
    public Sprite dog1;
    public Sprite dog2;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = dog1;
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
      renderer.sprite = dog2;
      sound.PlayOneShot(dialog1);
      StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
      yield return new WaitForSeconds(1);
      renderer.sprite = dog1;
    }
}
