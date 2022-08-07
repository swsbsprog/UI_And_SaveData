using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabGroup : MonoBehaviour
{
    public Tab baseTab;
    public List<Tab> tabs = new List<Tab>();
    public void SetInit(List<GameData> data, IInventoryUI inventoryUI)
    {
        CreateTabs(data, inventoryUI);
        SelectTab(0);
    }   

    private void CreateTabs(List<GameData> data, IInventoryUI inventoryUI)
    {
        baseTab.gameObject.SetActive(true);
        foreach (var item in data)
        {
            var newTab = Instantiate(baseTab, baseTab.transform.parent);
            newTab.Init(item, inventoryUI);
            tabs.Add(newTab);
        }
        baseTab.gameObject.SetActive(false);
    }

    public void SelectTab(Tab selectedTab)
    {
        int thisTabIndex = tabs.FindIndex(x => x == selectedTab);
        SelectTab(thisTabIndex);
    }

    void SelectTab(int tabIndex)
    {
        for (int i = 0; i < tabs.Count; i++)
        {
            Tab.State state = tabIndex == i ? Tab.State.Active : Tab.State.Inactive;
            tabs[i].SetActiveSate(state);
        }
    }

    public void Clear()
    {
        foreach (var tab in tabs)
        {
            tab.items.ForEach(x =>
            {
                if (x == null) return;
                Destroy(x.gameObject);
            });
            Destroy(tab.gameObject);
        }
        tabs.Clear();
    }
}