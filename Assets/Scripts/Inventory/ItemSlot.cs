using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot
{
    /// <summary>
    /// 이 슬롯의 인덱스(인벤토리의 몇번째 슬롯인가)
    /// </summary>
    uint slotIndex;

    /// <summary>
    /// 이 슬롯에 들어있는 아이템
    /// </summary>
    ItemData slotItemData = null;

    public ItemData ItemData
    {
        get => slotItemData;
        private set
        {
            if (slotItemData != value)
            {
                slotItemData = value;
                onSlotItemChange?.Invoke();
            }
        }
    }

    /// <summary>
    /// 이 슬롯이 비었는지 여부(true면 비었고, false면 무엇인가 들어있다.)
    /// </summary>
    public bool IsEmpty => (slotItemData == null);

    /// <summary>
    /// 이 슬롯의 인덱스
    /// </summary>
    public uint Index => slotIndex;

    /// <summary>
    /// 슬롯에 아이템이 변경되면 실행되는 델리게이트
    /// </summary>
    public Action onSlotItemChange;

    public ItemSlot(uint index)
    {
        slotIndex = index;
    }

    /// <summary>
    /// 이 슬롯에 지정된 아이템을 지정된 갯수로 넣는 함수
    /// </summary>
    /// <param name="data">추가할 아이템</param>
    /// <param name="count">설정된 개수</param>
    public void AssignSlotItem(ItemData data, uint count = 1)
    {
        if (data != null)
        {
            ItemData = data;
            Debug.Log($"인벤토리에 {slotIndex}번 슬롯에 {ItemData.itemName} 아이템 설정");

        }
        else
        {
            // data가 null이면 비우는 함수 실행
            ClearSlotItem();
        }
    }

    /// <summary>
    /// 이 슬롯에서 아이템을 제거하는 함수
    /// </summary>
    public void ClearSlotItem()
    {
        ItemData = null;        
    }

}
