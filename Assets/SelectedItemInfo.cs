using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItemInfo : MonoBehaviour
{
    public Sprite emptySprite;
    public Image icon;
    public TMP_Text text;
    public InventoryItem selectedItem;
    public void SetData(Sprite sprite, InventoryItem selectedItem)
    {
        this.selectedItem = selectedItem;
        icon.sprite = sprite;
        text.text = sprite.name;
    }

    public bool IsEmpty()
    {
        return selectedItem == null;
    }

    internal void Clear()
    {
        icon.sprite = emptySprite;
        selectedItem = null;
    }
}
