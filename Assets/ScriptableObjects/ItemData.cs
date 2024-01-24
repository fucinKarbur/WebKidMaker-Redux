using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "ItemData", order = 0)]
public class ItemData : ScriptableObject
{
    //[SerializeField] private  int _order;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ItemType _type;
    [SerializeField] private bool _colorable;

    public Sprite Icon => _icon;
    public ItemType Type => _type;
    public bool Colorable => _colorable;
}