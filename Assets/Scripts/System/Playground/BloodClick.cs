using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WKMR
{
    [RequireComponent(typeof(ParticleSystem))]
    public class BloodClick : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] _effects;
        [SerializeField] private Image _body;

        private ParticleSystem _mainSystem;

        private void Awake() => _mainSystem = GetComponent<ParticleSystem>();

        public void DoSplash(Vector3 position)
        {
            transform.position = position;
            SetColor();
            _mainSystem.Play();
        }

        private void SetColor()
        {
            foreach (var effect in _effects)
            {
                var main = effect.main;
                main.startColor = _body.color;
            }
        }
    }
}
