using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot
{
    /// <summary>
    /// �� ������ �ε���(�κ��丮�� ���° �����ΰ�)
    /// </summary>
    uint slotIndex;

    /// <summary>
    /// �� ���Կ� ����ִ� ������
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
    /// �� ������ ������� ����(true�� �����, false�� �����ΰ� ����ִ�.)
    /// </summary>
    public bool IsEmpty => (slotItemData == null);

    /// <summary>
    /// �� ������ �ε���
    /// </summary>
    public uint Index => slotIndex;

    /// <summary>
    /// ���Կ� �������� ����Ǹ� ����Ǵ� ��������Ʈ
    /// </summary>
    public Action onSlotItemChange;

    public ItemSlot(uint index)
    {
        slotIndex = index;
    }

    /// <summary>
    /// �� ���Կ� ������ �������� ������ ������ �ִ� �Լ�
    /// </summary>
    /// <param name="data">�߰��� ������</param>
    /// <param name="count">������ ����</param>
    public void AssignSlotItem(ItemData data, uint count = 1)
    {
        if (data != null)
        {
            ItemData = data;
            Debug.Log($"�κ��丮�� {slotIndex}�� ���Կ� {ItemData.itemName} ������ ����");

        }
        else
        {
            // data�� null�̸� ���� �Լ� ����
            ClearSlotItem();
        }
    }

    /// <summary>
    /// �� ���Կ��� �������� �����ϴ� �Լ�
    /// </summary>
    public void ClearSlotItem()
    {
        ItemData = null;        
    }

}
