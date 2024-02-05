using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WKMR.System.PointReacts.Reactions;

namespace WKMR.System.PointReacts
{
        public class PointerApplier : MonoBehaviour,
        IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
        {
                [Header("Size Settings")]
                [SerializeField] private bool _changeSize = false;
                [SerializeField] private Vector3 _increaseSize = new Vector3(.1f, .1f);

                [Header("Material Settings")]
                [SerializeField] private bool _changeMaterial = false;
                [SerializeField] private Material _material;

                [Header("Sound Settings")]
                [SerializeField] private bool _playSound = false;
                [SerializeField] private AudioClip _sound;
                
                private readonly List<Reaction> _reactions = new();

                private Transform _transform;
                private Image _image;
                private AudioSource _source;

                private void Awake()
                {
                        if (_changeSize)
                                OnChangeSize();

                        if (_changeMaterial)
                                OnChangeMaterial();

                        if (_playSound)
                                OnPlaySound();
                }

                private void OnDisable() => SetDefault();

                #region Events
                public void OnPointerEnter(PointerEventData eventData)
                {
#if UNITY_STANDALONE || UNITY_EDITOR
                        React();
#endif
                }

                public void OnPointerExit(PointerEventData eventData)
                {
#if UNITY_STANDALONE || UNITY_EDITOR
                        SetDefault();
#endif
                }

                public void OnPointerClick(PointerEventData eventData)
                {
#if UNITY_STANDALONE == false || UNITY_EDITOR == false
                        React();
#endif
                }

                public void OnPointerUp(PointerEventData eventData)
                {
#if UNITY_STANDALONE == false || UNITY_EDITOR == false
                        SetDefault();
#endif
                }

                #endregion

                #region Reactions
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
                        if (TryGetComponent(out _source) == false)
                                _source = gameObject.AddComponent<AudioSource>();

                        if (_sound != null)
                                _reactions.Add(new SoundPlay(_sound, _source));
                }
                #endregion

                private void React()
                {
                        foreach (var reaction in _reactions)
                                reaction.React();
                }

                private void SetDefault()
                {
                        foreach (var reaction in _reactions)
                                reaction.SetDefault();
                }
        }
}