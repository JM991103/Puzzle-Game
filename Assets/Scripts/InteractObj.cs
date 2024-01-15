using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractObj : MonoBehaviour
{
    public TalkManager talkManager;

    [Header("0�� ������ ���� 1�� ������ ����")]
    public Sprite[] sprite = new Sprite[2];

    SpriteRenderer door;

    [SerializeField]
    bool isOpen;
    public bool key = false;

    public string[] defaultText;
    public string[] afterText;

    bool isTextAction;

    private void Awake()
    {
        door = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        door.sprite = sprite[0];
    }

    public void Open()
    {
        door.sprite = sprite[1];
    }

    public void Close()
    {
        door.sprite = sprite[0];
    }
}
