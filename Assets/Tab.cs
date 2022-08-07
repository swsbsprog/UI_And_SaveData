using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tab : MonoBehaviour, IPointerClickHandler
{
    public Image tapIcon;
    public InventoryItem itemBase;
    public List<InventoryItem> items;
    public Animator animator;
    internal void Init(GameData gameData, IInventoryUI inventoryUI)
    {
        itemBase.gameObject.SetActive(true);
        tapIcon.sprite = gameData.tabIcon;
        foreach (var item in gameData.items)
        {
            var newItem = Instantiate(itemBase, itemBase.transform.parent);
            newItem.Init(item);
            newItem.inventoryUI = inventoryUI;
            items.Add(newItem);
        }
        itemBase.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponentInParent<TabGroup>().SelectTab(this);
    }

    public enum State
    {
        NotInit, Active, Inactive
    }
    public State lastState;
    public void SetActiveSate(State state)
    {
        if (this.lastState == state)
            return;
        bool bState = state == State.Active ? true : false;

        items.ForEach(x => x.gameObject.SetActive(bState));
        animator.Play(bState ? "Active": "Inactive");
        this.lastState = state;
    }
}
