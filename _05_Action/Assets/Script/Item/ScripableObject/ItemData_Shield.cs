using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shield Item Data", menuName = "Scriptable Object/Item Data - Shield", order = 6)]
public class ItemData_Shield : ItemData_EquipItem
{
    [Header("쉴드 데이터")]
    public float DefencePower = 15;

    public override EquipPartType EquipPart => EquipPartType.Shield;

}
