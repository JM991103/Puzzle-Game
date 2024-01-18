using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    // 몇번째 슬롯인지
    private uint id;

    // 이 UI와 연결된 ItemSlot
    protected ItemSlot itemSlot;

    private Image itemImage;

    public uint ID => id;
    public ItemSlot ItemSlot => itemSlot;

    public Action<uint> onPointerEnter;      // 마우스 포인터가 안에 들어왔을 때
    public Action<uint> onPointerExit;       // 마우스 포인터가 밖으로 나갔을 때
    public Action<Vector2> onPointerMove;    // 마우스 포인터가 안에서 움직일 때

    private void Awake()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
    }

    /// <summary>
    /// 슬롯 초기화 함수
    /// </summary>
    /// <param name="id">슬롯의 ID</param>
    /// <param name="slot">이 UI가 보여줄 ItemSlot</param>
    public virtual void InitializeSlot(uint id, ItemSlot slot)
    {
        this.id = id;
        this.itemSlot = slot;


        onPointerEnter = null;
        onPointerExit = null;
        onPointerMove = null;

    }    

    private void Refresh()
    {
        if (itemSlot.IsEmpty)
        {
            // 아이템 슬롯이 비어있으면
            itemImage.sprite = null;        // 스트라이트 빼고
            itemImage.color = Color.clear;  // 투명화
        }
        else
        {
            // 아이템 슬롯에 아이템이 있으면
            itemImage.sprite = itemSlot.ItemData.itemIcon;  // 해당 아이콘 이미지 표시
            itemImage.color = Color.white;                  // 불투명화
        }
    }

    /// <summary>
    /// EventSystems에서 마우스 포인터가 이 UI 영역에 들어오면 실행되는 함수
    /// </summary>
    /// <param name="eventData">관련 이벤트 정보들</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        onPointerEnter?.Invoke(ID);
        Debug.Log("1");
    }

    /// <summary>
    /// EventSystems에서 마우스 포인터가 이 UI 영역을 나가면 실행되는 함수
    /// </summary>
    /// <param name="eventData">관련 이벤트 정보들</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        onPointerExit?.Invoke(ID);
        
    }

    /// <summary>
    /// EventSystems에서 마우스 포인터가 이 UI 영역안에서 움직이면 실행되는 함수
    /// </summary>
    /// <param name="eventData">관련 이벤트 정보들</param>
    public void OnPointerMove(PointerEventData eventData)
    {
        onPointerMove?.Invoke(eventData.position);  // 스크린 좌표값 넘겨주기
        
    }
}
