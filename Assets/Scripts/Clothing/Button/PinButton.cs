using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR
{
    public class PinButton : ItemButton
    {
        [SerializeField] private Transform[] _spawnPoints;

        private PlacePinButton _placeButton;
        private ClearPinButton _clearPinButton;
        private ButtonStatus _status;

        public ItemTemplate LastPin { get; private set; }
        public Transform[] SpawnPoints => _spawnPoints;
        public ButtonStatus Status => _status;

        private void Start()
        {
            _placeButton = GetComponentInChildren<PlacePinButton>();
            _clearPinButton = GetComponentInChildren<ClearPinButton>();
            _status = GetComponent<ButtonStatus>();

            _placeButton.gameObject.SetActive(false);
            _clearPinButton.gameObject.SetActive(false);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Container.Cleared += OnCleared;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Container.Cleared -= OnCleared;
        }

        public override void Spawn()
        {
            if (TryToSpawn())
            {
                LastPin = Instantiate(Template, _placeButton.GetPoint().position, _placeButton.GetRotation(), Container.transform);

                _placeButton.gameObject.SetActive(true);
                _clearPinButton.gameObject.SetActive(true);
                SetItem(LastPin);
            }
        }

        private void OnCleared()
        {
            if (_status.HasSpawned(Item) == false)
            {
                _placeButton.gameObject.SetActive(false);
                _clearPinButton.gameObject.SetActive(false);
            }
        }
    }
}