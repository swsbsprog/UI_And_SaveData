using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public Tab baseTab;
    public Tab[] tabs;
    private void Awake()
    {
        CreateTabs();
        SelectTab(0);
    }

    private void CreateTabs()
    {
        foreach (var item in tabs)
        {
            var newTab = Instantiate(baseTab);
            newTab.Init(item);
        }
    }

    public void SelectTab(int tabIndex)
    {
        var currentTab = tabs[tabIndex];
        CreateItems(currentTab);
    }

    private void CreateItems(Tab currentTab)
    {
        throw new NotImplementedException();
    }
}
[System.Serializable]
public class TabInfo
{
    public Sprite tabIcon;
    public Sprite[] items;
}