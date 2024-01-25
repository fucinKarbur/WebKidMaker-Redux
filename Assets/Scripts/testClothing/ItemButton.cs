using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemButton : MonoBehaviour
{
    [SerializeField] private Palette _palette;
    [SerializeField] private ClearButton _clearButton;
    [SerializeField] private ItemData _item;
    [SerializeField] private Image _icon;
    [SerializeField] private ClothContainer _container;
    [SerializeField] private ClothTemplate _template;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _icon.sprite = _item.Icon;
    }

    private void OnEnable() => _button.onClick.AddListener(Spawn);

    private void OnDisable() => _button.onClick.RemoveListener(Spawn);

    public void Spawn()
    {
        _clearButton.Clear();

        var spawned = Instantiate(_template, _container.transform.position, Quaternion.identity, _container.transform);

        spawned.SetImage(_item.Icon);
        TryToColor(spawned);
    }

    public void TryToColor(ClothTemplate template)
    {
        if (_item.Colorable && _palette != null)
        {
            _palette.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(_palette.gameObject);
            _palette.ColorSend += template.SetColor;
        }
        else
        {
            return;
        }
    }
}