using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public void PickItem(Transform player)
    {
       transform.SetParent(player);
       transform.localPosition = new Vector3(0,54,0);
    }
}
