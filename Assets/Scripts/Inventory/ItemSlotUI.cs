using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    // ���° ��������
    private uint id;

    // �� UI�� ����� ItemSlot
    protected ItemSlot itemSlot;

    private Image itemImage;

    public uint ID => id;
    public ItemSlot ItemSlot => itemSlot;

    public Action<uint> onPointerEnter;      // ���콺 �����Ͱ� �ȿ� ������ ��
    public Action<uint> onPointerExit;       // ���콺 �����Ͱ� ������ ������ ��
    public Action<Vector2> onPointerMove;    // ���콺 �����Ͱ� �ȿ��� ������ ��

    private void Awake()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
    }

    /// <summary>
    /// ���� �ʱ�ȭ �Լ�
    /// </summary>
    /// <param name="id">������ ID</param>
    /// <param name="slot">�� UI�� ������ ItemSlot</param>
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
            // ������ ������ ���������
            itemImage.sprite = null;        // ��Ʈ����Ʈ ����
            itemImage.color = Color.clear;  // ����ȭ
        }
        else
        {
            // ������ ���Կ� �������� ������
            itemImage.sprite = itemSlot.ItemData.itemIcon;  // �ش� ������ �̹��� ǥ��
            itemImage.color = Color.white;                  // ������ȭ
        }
    }

    /// <summary>
    /// EventSystems���� ���콺 �����Ͱ� �� UI ������ ������ ����Ǵ� �Լ�
    /// </summary>
    /// <param name="eventData">���� �̺�Ʈ ������</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        onPointerEnter?.Invoke(ID);
        Debug.Log("1");
    }

    /// <summary>
    /// EventSystems���� ���콺 �����Ͱ� �� UI ������ ������ ����Ǵ� �Լ�
    /// </summary>
    /// <param name="eventData">���� �̺�Ʈ ������</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        onPointerExit?.Invoke(ID);
        
    }

    /// <summary>
    /// EventSystems���� ���콺 �����Ͱ� �� UI �����ȿ��� �����̸� ����Ǵ� �Լ�
    /// </summary>
    /// <param name="eventData">���� �̺�Ʈ ������</param>
    public void OnPointerMove(PointerEventData eventData)
    {
        onPointerMove?.Invoke(eventData.position);  // ��ũ�� ��ǥ�� �Ѱ��ֱ�
        
    }
}
