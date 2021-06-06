using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSpriteDance : MonoBehaviour
{
    private SpriteRenderer renderer;
    public Sprite dance1;
    public Sprite dance2;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = dance1;
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
      renderer.sprite = dance2;
      StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
      yield return new WaitForSeconds(1);
      renderer.sprite = dance1;
    }
}
