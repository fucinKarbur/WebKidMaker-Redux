using UnityEngine;
using UnityEngine.EventSystems;

public class Shortcut : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Window _window;

    private bool IsOpen => _window.gameObject.activeSelf;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging == false)
            if (IsOpen == false)
                _window.gameObject.SetActive(true);
    }
}