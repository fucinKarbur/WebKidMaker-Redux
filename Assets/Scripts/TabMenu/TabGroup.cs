using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private List<TabButton> _buttons = new();
    [SerializeField] private Material _selected;
    [SerializeField] private Material _hovered;

    private List<PageGroup> _tabsContent = new();

    private TabButton _current;

    private void Start()
    {
        foreach(var tab in _buttons)
        _tabsContent.Add(tab.PageGroup);

        if (_current == null)
            OnSelected(_buttons[0]);
    }

    public void OnEnter(TabButton button)
    {
        ResetButtons();

        if (_current != button)
            button.Background.material = _hovered;
    }

    public void OnExit() => ResetButtons();

    public void OnSelected(TabButton button)
    {
        _current = button;
        ResetButtons();
        UpdatePages();
        button.Background.material = _selected;
    }

    private void ResetButtons()
    {
        foreach (var button in _buttons)
        {
            if (_current == button)
                continue;

            button.Background.material = null;
        }
    }

    private void UpdatePages()
    {
        foreach (var group in _tabsContent)
        {
            if (group == null)
                continue;

            if (_current.PageGroup == group)
                group.gameObject.SetActive(true);
            else
                group.gameObject.SetActive(false);
        }
    }
}