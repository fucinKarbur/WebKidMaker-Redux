using UnityEngine;
using UnityEngine.UI;
using WKMR.Coloring;

namespace WKMR.Clothing
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class ItemButton : MonoBehaviour
    {
        private Image _image;
        private Button _button;
        
        private ItemData _data;
        private ItemSpawner _spawner;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _button = GetComponent<Button>();
        }

        private void Start() => _button.onClick.AddListener(Spawn);

        private void OnDestroy() => _button.onClick.RemoveListener(Spawn);

        public void Initialize(ItemData data, ItemSpawner spawner)
        {
            _data = data;
            _spawner = spawner;
            SetImage();
        }

        private void SetImage()
        {
            _image.sprite = _data.Icon;
            _image.SetNativeSize();
        }

        private void Spawn() => _spawner.Spawn(_data);
    }
}