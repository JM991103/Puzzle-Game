using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Inventory
{
    public const int Default_Inventory_Size = 7;
    public const uint TempSlotIndex = 99999;

    /// <summary>
    /// 이 인벤토리가 가지고 있는 아이템 슬롯의 배열
    /// </summary>
    ItemSlot[] slots = null;

    /// <summary>
    /// 게임 매니저가 가지는 아이템 매니저 캐싱용
    /// </summary>
    ItemDataManager dataManager;

    public Inventory(int size = Default_Inventory_Size)
    {
        Debug.Log($"{size}칸짜리 인벤토리 생성");
        slots = new ItemSlot[size];
        for (int i = 0; i < size; i++)
        {
            slots[i] = new ItemSlot((uint)i);
        }

        dataManager = GameManager.Inst.ItemData;
    }

    //public bool AddItem(ItemIDCode code)
    //{
    //    return AddItem(dataManager[code]);
    //}

    public bool AddItem(ItemData data)
    {
        bool result = false;

        ItemSlot targetSlot = FindSameItem(data);
        if (targetSlot == null)
        {
            // 인벤토리에 같은 종류의 아이템이 없다.
            ItemSlot emptySlot = FindEmptySlot();
            if (emptySlot != null)
            {
                // 비어있는 슬롯을 찾았다.
                emptySlot.AssignSlotItem(data);
                result = true;
            }
            else
            {
                // 인벤토리가 가득 찼다.
            }
        }
        else
        {
            // 같은 종류의 아이템이 있다.            
        }

        return result;
    }

    /// <summary>
    /// 비어있는 슬롯을 찾는 함수
    /// </summary>
    /// <returns>비어있는 함수를 찾으면 null이 아니고 비어있는 함수가 없으면 null</returns>
    private ItemSlot FindEmptySlot()
    {
        ItemSlot result = null;
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                result = slot;
                break;
            }
        }
        return result;
    }

    /// <summary>
    /// 인벤토리에 파라메터와 같은 종류의 아이템이 있는지 찾아보는 함수
    /// </summary>
    /// <param name="itemData">찾을 아이템</param>
    /// <returns></returns>
    public ItemSlot FindSameItem(ItemData itemData)
    {
        ItemSlot findSlot = null;

        foreach (var slot in slots)
        {
            // 같은 종류의 아이템이 있다.
            if (slot.ItemData == itemData)
            {
                findSlot = slot;
                break;
            }
        }

        return findSlot;
    }

    /// <summary>
    /// 특정 슬롯에서 아이템을 제거하는 함수
    /// </summary>
    /// <param name="slotIndex">아이템을 제거할 함수</param>
    /// <returns>true면 성공, false면 실패</returns>
    public bool ClearItem(uint slotIndex)
    {
        bool result = false;

        if (IsValidSlotIndex(slotIndex))
        {
            ItemSlot slot = slots[slotIndex];
            slot.ClearSlotItem();
            return true;
        }
        else
        {
            Debug.Log($"실패 : {slotIndex}는 잘못된 인덱스 입니다.");
        }

        return result;
    }

    /// <summary>
    /// 인벤토리의 모든 아이템을 비우는 함수
    /// </summary>
    public void ClearInventory()
    {
        foreach (var slot in slots)
        {
            slot.ClearSlotItem();
        }
    }

    private bool IsValidSlotIndex(uint index) => (index < TempSlotIndex);

}
