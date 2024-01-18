using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    ///// <summary>
    ///// ItemSlotUI가 있는 프리팹. 인벤토리 크기 변화에 대비해서 가지고 있기.
    ///// </summary>
    //public GameObject slotPrefab;

    /// <summary>
    /// 이 UI가 보여줄 인벤토리
    /// </summary>
    Inventory inven;

    /// <summary>
    /// 이 인벤토리에 있는 아이템 슬롯의 UI
    /// </summary>
    ItemSlotUI[] slotUIs;

    /// <summary>
    /// 아이템 상세 정보를 보여주는 UI창
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
    /// 마우스가 슬롯에 들어갔을 때 해당 슬롯에 있는 아이템을 상세 정보 창에서 볼 수 있도록 설정하고 여는 함수
    /// </summary>
    /// <param name="slotID"></param>
    private void OnItemDetailOn(uint slotID)
    {
        detail.Open(slotUIs[slotID].ItemSlot.ItemData); // 대상 슬롯의 아이템 데이터 넘겨주며 열기
    }    

    /// <summary>
    /// 마우스가 슬롯을 나갔을 때 상세정보창을 닫는 함수
    /// </summary>
    /// <param name="_"></param>
    private void OnItemDetailOff(uint _)
    {
        detail.Close();
    }

    /// <summary>
    /// 마우스가 슬롯안에서 움직일 때 실행되는 함수
    /// </summary>
    /// <param name="pointerPos">마우스 포인터의 스크린 좌표</param>
    private void OnPointerMove(Vector2 pointerPos)
    {
        if (detail.IsOpen)
        {
            detail.MovePosition(pointerPos);
        }
    }
}
