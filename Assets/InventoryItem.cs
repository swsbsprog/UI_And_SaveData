using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public IInventoryUI inventoryUI;
    public Image iconImage;
    private void Start() => spriteName = iconImage?.sprite.name;
    string spriteName;
    public void OnPointerClick(PointerEventData eventData){
        print($"{spriteName} Click");
        inventoryUI.SetSelectedItem(iconImage.sprite, this);
    }

    public void OnPointerEnter(PointerEventData eventData){
        print($"{spriteName} Enter");
        inventoryUI.OnPointerEnter(iconImage.sprite, transform.position);
    }

    public void OnPointerExit(PointerEventData eventData){
        print($"{spriteName} Exit");
        inventoryUI.OnPointerExit(iconImage.sprite);
    }
    public void Init(Sprite item) => iconImage.sprite = item;
}
public interface IInventoryUI
{
    void OnPointerEnter(Sprite sprite, Vector3 position) { }
    void OnPointerExit(Sprite sprite) { }
    void SetSelectedItem(Sprite sprite, InventoryItem inventoryItem);
}