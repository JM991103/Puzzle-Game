using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractObj : MonoBehaviour, IPointerClickHandler
{
    [Header("0¹ø ½½·ÔÀÌ ´ÝÈû 1¹ø ½½·ÔÀÌ ¿­¸²")]
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
        // ¸¶¿ì½º ¿ÞÂÊ ¹öÆ°À» ´­·¶À» ¶§
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (key)
            {
                Open();
            }
            else
            {
                Debug.Log("¿­¼è°¡ ¾ø½À´Ï´Ù.");
            }
        }
    }
}
