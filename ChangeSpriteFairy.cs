using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSpriteFairy : MonoBehaviour
{
    private SpriteRenderer renderer;
    public Sprite fairy1;
    public Sprite fairy2;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = fairy1;
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
      renderer.sprite = fairy2;
      StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
      yield return new WaitForSeconds(1);
      renderer.sprite = fairy1;
    }
}
