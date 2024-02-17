using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WKMR.System.PointReacts.Reactions;

namespace WKMR.System.PointReacts
{
    public abstract class PointerApplier : MonoBehaviour
        {
                [Header("Size Settings")]
                [SerializeField] private bool _changeSize = false;
                [SerializeField] private Vector3 _increaseSize = new Vector3(.1f, .1f);

                [Header("Material Settings")]
                [SerializeField] private bool _changeMaterial = false;
                [SerializeField] private Material _material;

                [Header("Sound Settings")]
                [SerializeField] private bool _playSound = false;
                [SerializeField] private SoundName _sound;

                private readonly List<Reaction> _reactions = new();

                private Transform _transform;
                private Image _image;

                private void Start()
                {
                        if (_changeSize)
                                OnChangeSize();

                        if (_changeMaterial)
                                OnChangeMaterial();

                        if (_playSound)
                                OnPlaySound();
                }

                private void OnDisable() => SetDefault();

                private void OnChangeSize()
                {
                        _transform = GetComponent<Transform>();
                        _reactions.Add(new Scaling(_increaseSize, _transform));
                }

                private void OnChangeMaterial()
                {
                        if (TryGetComponent(out _image) == false)
                                _image = gameObject.AddComponent<Image>();

                        if (_material != null)
                                _reactions.Add(new MaterialChange(_material, _image));
                }

                private void OnPlaySound()
                {
                        _reactions.Add(new SoundPlay(_sound));
                }

                protected void React()
                {
                        foreach (var reaction in _reactions)
                                reaction.React();
                }

                protected void SetDefault()
                {
                        foreach (var reaction in _reactions)
                                reaction.SetDefault();
                }
        }
}