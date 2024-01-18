using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Scriptable Object/Item Data", order = 1)]
public class ItemData : ScriptableObject
{
    [Header("������ �⺻ ������")]
    public uint id = 0;                     // ������ ID
    [Header("�������� �̸�")]
    public string itemName = "������";       // �������� �̸�
    [Header("�������� ����")]
    public Sprite modelPrefab;              // �������� ������ ǥ���� ������
    [Header("�κ��丮���� ���� ��������Ʈ")]
    public Sprite itemIcon;                 // �������� �κ��丮���� ���� ��������Ʈ
    [Header("��ĭ�� �� �� �ִ� �ִ� ���� ����")]
    public uint maxStackCount = 1;          // �κ��丮 ��ĭ�� �� �� �ִ� �ִ� ���� ����
    [Header("�������� �� ����")]
    public string itemDescription;          // �������� �� ����
}
