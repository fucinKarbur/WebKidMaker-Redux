using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR
{
    public class PlacePinButton : MonoBehaviour
    {
        private PinButton _pinButton;

        private Transform[] _spawnPoints => _pinButton.SpawnPoints;
        private Transform _lastPin => _pinButton.LastPin.transform;

        public void Awake() => _pinButton = GetComponentInParent<PinButton>();

        public void ReplacePin()
        {
            if (_lastPin != null)
            {
                _lastPin.rotation = GetRotation();
                _lastPin.position = GetPoint().position;
            }
        }

        public Transform GetPoint() => _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        public Quaternion GetRotation()
        {
            int z = Random.Range(0, 360);

            return Quaternion.Euler(0, 0, z);
        }
    }
}
