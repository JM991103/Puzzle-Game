using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractObj : MonoBehaviour, IPointerClickHandler
{
    [Header("0�� ������ ���� 1�� ������ ����")]
    public Sprite[] sprite = new Sprite[2];

    SpriteRenderer door;

    [SerializeField]
    bool isOpen;
    public bool key = false;

    private void Awake()
    {
        door = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        door.sprite = sprite[0];
    }

    void Open()
    {
        door.sprite = sprite[1];
    }

    void Close()
    {
        door.sprite = sprite[0];
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        // ���콺 ���� ��ư�� ������ ��
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (key)
            {
                Open();
            }
            else
            {
                Debug.Log("���谡 �����ϴ�.");
            }
        }
    }
}
