using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothContainer : MonoBehaviour
{
    public void Reset()
    {
        foreach (var item in GetComponentsInChildren<ClothTemplate>())
            Destroy(item.gameObject);
    }
}
