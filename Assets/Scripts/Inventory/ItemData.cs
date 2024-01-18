using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Scriptable Object/Item Data", order = 1)]
public class ItemData : ScriptableObject
{
    [Header("아이템 기본 데이터")]
    public uint id = 0;                     // 아이템 ID
    [Header("아이템의 이름")]
    public string itemName = "아이템";       // 아이템의 이름
    [Header("아이템의 외형")]
    public Sprite modelPrefab;              // 아이템의 외형을 표시할 프리팹
    [Header("인벤토리에서 보일 스프라이트")]
    public Sprite itemIcon;                 // 아이템이 인벤토리에서 보일 스프라이트
    [Header("한칸에 들어갈 수 있는 최대 누적 개수")]
    public uint maxStackCount = 1;          // 인벤토리 한칸에 들어갈 수 있는 최대 누적 개수
    [Header("아이템의 상세 설명")]
    public string itemDescription;          // 아이템의 상세 설명
}
