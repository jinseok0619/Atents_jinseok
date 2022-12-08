using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    // <summary>
    /// 이 스위치로 열고 닫을 문
    /// </summary>
    public Door targetDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetDoor != null)
            {
                targetDoor.Open();
            }
        }
        Destroy(this.gameObject);
    }

}
