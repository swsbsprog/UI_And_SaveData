using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInventoryUI : MonoBehaviour, IInventoryUI
{
    public UserDataManager userDataManager;
    public SelectedItemInfo selectedItemInfo;
    public ShopInventoryUI shopInventoryUI;

    [SerializeField] List<GameData> haveItemCategorys = new List<GameData>();
    public void ShowUI()
    {
        gameObject.SetActive(true);
        InitInventory();
        GetComponentInChildren<TabGroup>().SetInit(haveItemCategorys, this);
    }
    bool completeUI = false;
    public void CloseUI()
    {
        //기존 아이템 삭제.
        gameObject.SetActive(false);
        GetComponentInChildren<TabGroup>().Clear();
    }
    private void InitInventory()
    {
        haveItemCategorys.Clear();
        foreach (var item in shopInventoryUI.categorys)
            haveItemCategorys.Add(new GameData() { tabIcon = item.tabIcon });

        List<string> items = userDataManager.UserData.haveItem;
        foreach (string itemName in items)
        {
            int categoryIndex = shopInventoryUI.GetCategoryIndex(itemName);
            Sprite itemSprite = shopInventoryUI.GetSprite(itemName);
            haveItemCategorys[categoryIndex].items.Add(itemSprite);
        }
    }

    public void SetSelectedItem(Sprite sprite, InventoryItem inventoryItem)
        => selectedItemInfo.SetData(sprite, inventoryItem);
    public void OnClickSellSelectedItem()
    {
        if (selectedItemInfo.IsEmpty())
        {
            Debug.LogWarning("아이템을 선택하지 않았습니다");
            return;
        }

        string sellItemName = selectedItemInfo.icon.sprite.name;
        print($"{sellItemName}을 판매 했다");

        // 데이터 업데이트
        userDataManager.SellItem(sellItemName);
        int categoryIndex = shopInventoryUI.GetCategoryIndex(sellItemName);
        Sprite itemSprite = shopInventoryUI.GetSprite(sellItemName);
        haveItemCategorys[categoryIndex].items.Remove(itemSprite);

        // UI업데이트
        Destroy(selectedItemInfo.selectedItem.gameObject);
        selectedItemInfo.Clear();
    }
}
