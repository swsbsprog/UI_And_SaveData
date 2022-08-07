using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OverUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text text;
        
    public void OnPointerEnter(Sprite sprite, Vector2 pos)
    {
        transform.position = pos;
        gameObject.SetActive(true);
        SetData(sprite);
    }
    public void OnPointerExit()
    {
        gameObject.SetActive(false);
    }
    void SetData(Sprite sprite)
    {
        icon.sprite = sprite;
        text.text = sprite.name;
    }
}
