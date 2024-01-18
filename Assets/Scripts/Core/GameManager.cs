using InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// 아이템 데이터 관리하는 매니저
    /// </summary>
    ItemDataManager itemData;





    /// <summary>
    /// 아이템 데이터 매니저 (읽기전용) 프로퍼티
    /// </summary>
    public ItemDataManager ItemData => itemData;

    protected override void Initialize()
    {
        base.Initialize();

        itemData = GetComponent<ItemDataManager>();
    }
}
