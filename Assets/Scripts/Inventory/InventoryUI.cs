using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    ///// <summary>
    ///// ItemSlotUI�� �ִ� ������. �κ��丮 ũ�� ��ȭ�� ����ؼ� ������ �ֱ�.
    ///// </summary>
    //public GameObject slotPrefab;

    /// <summary>
    /// �� UI�� ������ �κ��丮
    /// </summary>
    Inventory inven;

    /// <summary>
    /// �� �κ��丮�� �ִ� ������ ������ UI
    /// </summary>
    ItemSlotUI[] slotUIs;

    /// <summary>
    /// ������ �� ������ �����ִ� UIâ
    /// </summary>
    DetailInfoUI detail;


    private void Awake()
    {
        Transform slotParent = transform.GetChild(0);
        slotUIs = new ItemSlotUI[slotParent.childCount];
        for (int i = 0; i < slotParent.childCount; i++)
        {
            Transform child = slotParent.GetChild(i);
            slotUIs[i] = child.GetComponent<ItemSlotUI>();
        }

        detail = GetComponentInChildren<DetailInfoUI>();
    }

    /// <summary>
    /// ���콺�� ���Կ� ���� �� �ش� ���Կ� �ִ� �������� �� ���� â���� �� �� �ֵ��� �����ϰ� ���� �Լ�
    /// </summary>
    /// <param name="slotID"></param>
    private void OnItemDetailOn(uint slotID)
    {
        detail.Open(slotUIs[slotID].ItemSlot.ItemData); // ��� ������ ������ ������ �Ѱ��ָ� ����
    }    

    /// <summary>
    /// ���콺�� ������ ������ �� ������â�� �ݴ� �Լ�
    /// </summary>
    /// <param name="_"></param>
    private void OnItemDetailOff(uint _)
    {
        detail.Close();
    }

    /// <summary>
    /// ���콺�� ���Ծȿ��� ������ �� ����Ǵ� �Լ�
    /// </summary>
    /// <param name="pointerPos">���콺 �������� ��ũ�� ��ǥ</param>
    private void OnPointerMove(Vector2 pointerPos)
    {
        if (detail.IsOpen)
        {
            detail.MovePosition(pointerPos);
        }
    }
}
