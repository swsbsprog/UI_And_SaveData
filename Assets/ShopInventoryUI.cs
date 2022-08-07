using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryUI : MonoBehaviour, IInventoryUI
{ 
    public UserDataManager userDataManager;
    public SelectedItemInfo selectedItemInfo;
    public List<GameData> categorys;
    public OverUI overUI;
    public Sprite emptySprite;
    public void Awake()=>GetComponentInChildren<TabGroup>().SetInit(categorys, this);
    public void SetSelectedItem(Sprite sprite, InventoryItem inventoryItem) 
        =>selectedItemInfo.SetData(sprite, inventoryItem);
    public void OnPointerEnter(Sprite sprite, Vector3 position)=>overUI.OnPointerEnter(sprite, position);

    public void OnPointerExit(Sprite sprite)=>overUI.OnPointerExit();
    public void OnClickBuyItem()
    {
        if(selectedItemInfo.IsEmpty())
        {
            Debug.LogWarning("아이템을 선택하지 않았습니다");
            return;
        }    
        string buyItemName = selectedItemInfo.icon.sprite.name;
        print($"{buyItemName}을 구입 했다");
        userDataManager.BuyItem(buyItemName);
        selectedItemInfo.Clear();
    }

    public void ShowUI()=>gameObject.SetActive(true);
    public void CloseUI()=>gameObject.SetActive(false);

    public int GetCategoryIndex(string itemName)
    {
        for (int i = 0; i < categorys.Count; i++)
        {
            var index = categorys[i].items.FindIndex(x => x.name == itemName);
            if (index >= 0)
                return i;
        }
        return -1;
    }

    public Sprite GetSprite(string itemName)
    {
        int index = GetCategoryIndex(itemName);
        return categorys[index].items.Find(x => x.name == itemName);
    }
}

[System.Serializable]
public class GameData
{
    public Sprite tabIcon;
    public List<Sprite> items = new List<Sprite>();
}