using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_LockOn : Test_Base
{
    // Start is called before the first frame update
    void Start()
    {
        ItemData_EquipItem item = GameManager.Inst.ItemData[ItemIDCode.SilverSword] as ItemData_EquipItem;
        GameManager.Inst.Player.Test_AddItem(item);
        GameManager.Inst.Player.Test_UseItem(0);
    }
}
