using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "ItemData", order = 0)]
public class ItemData : ScriptableObject
{
    [SerializeField] private bool _colorable;
    [SerializeField] private  int _order;
    [SerializeField] private  Sprite _icon;
    [SerializeField] private ItemType _type;

}