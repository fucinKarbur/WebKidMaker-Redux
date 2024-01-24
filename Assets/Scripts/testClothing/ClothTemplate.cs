using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]
public class ClothTemplate : MonoBehaviour
{
    private Image _image;
    private RectTransform _transform;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _transform = GetComponent<RectTransform>();
    }

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
        _image.SetNativeSize();
        //_transform.pivot = sprite.pivot;
        //_transform.anchoredPosition = Vector2.zero;
    }
}
