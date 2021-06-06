using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSpriteCat : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip dialog1;
    private SpriteRenderer renderer;
    public Sprite cat1;
    public Sprite cat2;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = cat1;
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
      renderer.sprite = cat2;
      sound.PlayOneShot(dialog1);
      StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
      yield return new WaitForSeconds(1);
      renderer.sprite = cat1;
    }
}
