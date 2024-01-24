using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

[RequireComponent(typeof(RectTransform))]
public class DraggableObject : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _parent;

    private RectTransform _transform;

    public SortingGroup Group { get; private set; }

    private void Awake()
    {
        _transform = _parent == null ?
           GetComponent<RectTransform>() :
           _parent.GetComponent<RectTransform>();

        SetGroup();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        List<DraggableObject> others = FindObjectsOfType<DraggableObject>().
        Where(other => other.Group.sortingLayerName == Group.sortingLayerName).ToList();

        Debug.Log(FindObjectsOfType<DraggableObject>().Length);
        
        int highestSiblingIndex = 0;
        foreach (var draggable in others)
        {
            int siblingIndex = draggable.transform.GetSiblingIndex();
            if (siblingIndex > highestSiblingIndex)
                highestSiblingIndex = siblingIndex;
        }

        // Set the sibling index of the current draggable object to be higher than the highest sibling index
        _transform.SetSiblingIndex(highestSiblingIndex + 1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    private void SetGroup()
    {
        if (_transform.GetComponent<SortingGroup>() == null)
            _transform.AddComponent<SortingGroup>();

        Group = _transform.GetComponent<SortingGroup>();
        Group.sortingLayerName = _transform.TryGetComponent(out Shortcut _) ?
         "exe" : "window";
    }
}