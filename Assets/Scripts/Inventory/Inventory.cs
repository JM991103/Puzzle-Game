using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Inventory
{
    public const int Default_Inventory_Size = 7;
    public const uint TempSlotIndex = 99999;

    /// <summary>
    /// �� �κ��丮�� ������ �ִ� ������ ������ �迭
    /// </summary>
    ItemSlot[] slots = null;

    /// <summary>
    /// ���� �Ŵ����� ������ ������ �Ŵ��� ĳ�̿�
    /// </summary>
    ItemDataManager dataManager;

    public Inventory(int size = Default_Inventory_Size)
    {
        Debug.Log($"{size}ĭ¥�� �κ��丮 ����");
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
            // �κ��丮�� ���� ������ �������� ����.
            ItemSlot emptySlot = FindEmptySlot();
            if (emptySlot != null)
            {
                // ����ִ� ������ ã�Ҵ�.
                emptySlot.AssignSlotItem(data);
                result = true;
            }
            else
            {
                // �κ��丮�� ���� á��.
            }
        }
        else
        {
            // ���� ������ �������� �ִ�.            
        }

        return result;
    }

    /// <summary>
    /// ����ִ� ������ ã�� �Լ�
    /// </summary>
    /// <returns>����ִ� �Լ��� ã���� null�� �ƴϰ� ����ִ� �Լ��� ������ null</returns>
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
    /// �κ��丮�� �Ķ���Ϳ� ���� ������ �������� �ִ��� ã�ƺ��� �Լ�
    /// </summary>
    /// <param name="itemData">ã�� ������</param>
    /// <returns></returns>
    public ItemSlot FindSameItem(ItemData itemData)
    {
        ItemSlot findSlot = null;

        foreach (var slot in slots)
        {
            // ���� ������ �������� �ִ�.
            if (slot.ItemData == itemData)
            {
                findSlot = slot;
                break;
            }
        }

        return findSlot;
    }

    /// <summary>
    /// Ư�� ���Կ��� �������� �����ϴ� �Լ�
    /// </summary>
    /// <param name="slotIndex">�������� ������ �Լ�</param>
    /// <returns>true�� ����, false�� ����</returns>
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
            Debug.Log($"���� : {slotIndex}�� �߸��� �ε��� �Դϴ�.");
        }

        return result;
    }

    /// <summary>
    /// �κ��丮�� ��� �������� ���� �Լ�
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
