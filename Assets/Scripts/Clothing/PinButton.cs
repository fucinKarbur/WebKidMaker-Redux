using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR
{
    public class PinButton : ItemButton, IPointerClickHandler
    {
        [SerializeField] private Transform[] _spawnPoints;

        private ClothTemplate _lastSpawned;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right && _lastSpawned != null)
            {
                _lastSpawned.transform.rotation = GetRotation();
                _lastSpawned.transform.position = GetPoint().position;
            }
        }

        public override void Spawn()
        {
            if (TryToSpawn())
            {
                _lastSpawned = Instantiate(Template, GetPoint().position, GetRotation(), Container.transform);
                SetItem(_lastSpawned);
            }
        }

        private Transform GetPoint() => _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        private Quaternion GetRotation()
        {
            int z = Random.Range(0, 360);

            return Quaternion.Euler(0, 0, z);
        }
    }
}
