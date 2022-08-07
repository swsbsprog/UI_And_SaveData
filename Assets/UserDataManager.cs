using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public TMP_Text goldText;
    UserData userData;
    public UserData UserData { get
        { 
            if(userData == null)
                userData = GetComponent<SaveData>().userData;
            return userData;
        }
    }     

    private void UpdateGold() => goldText.text = UserData.gold.ToString("N0"); //숫자 천단위로 ","표시됨 (예:1,000)

    private void Start() => UpdateGold();
    public void ChangeGold(int changeAmount)
    {
        UserData.gold += changeAmount;
        UpdateGold();
    }

    public void BuyItem(string buyItemName)
    {
        UserData.haveItem.Add(buyItemName);
        ChangeGold(-10);
    }
    public void SellItem(string sellItemName)
    {
        UserData.haveItem.Remove(sellItemName);
        ChangeGold(5);
    }
}
