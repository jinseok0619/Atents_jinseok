using UnityEngine;

interface IEquipItem
{
    /// <summary>
    /// 이 장비 아이템이 장착될 부위
    /// </summary>
    EquipPartType EquipPart { get; }

    /// <summary>
    /// 아이템 장비하기
    /// </summary>
    /// <param name="target">아이템을 장비할 대상</param>
    /// <param name="slot">아이템이 둘어있는 인벤토리 슬롯</param>
    void EquipItem(GameObject target, ItemSlot slot);

    /// <summary>
    /// 아이템을 해제하기
    /// </summary>
    /// <param name="target">아이템을 해제할 대상</param>
    /// <param name="slot">아이템이 둘어있는 인벤토리 슬롯</param>
    void UnEquipItem(GameObject target, ItemSlot slot);

    /// <summary>
    /// 아이템이 장비되어있으면 해제하고 해제되어있으면 장비하는 함수
    /// </summary>
    /// <param name="target">장비하고 해제할 대상</param>
    /// <param name="slot">아이템이 둘어있는 인벤토리 슬롯</param>
    /// <returns>true면 아이템 장비. false면 아이템 해제</returns>
    void AutoEquipItem(GameObject target, ItemSlot slot);
}