using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public Tab baseTab;
    public Tab[] tabs;

    public GameData[] category;
    private void Awake()
    {
        CreateTabs();
        SelectTab(0);
    }

    private void CreateTabs()
    {
        foreach (var item in category)
        {
            var newTab = Instantiate(baseTab);
            newTab.Init(item);
        }
    }

    public void SelectTab(int tabIndex)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActiveSate(tabIndex == i);
        }
    }
}

[System.Serializable]
public class GameData
{
    public Sprite tabIcon;
    public Sprite[] items;
}