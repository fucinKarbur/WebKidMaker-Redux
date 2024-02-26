using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WKMR.System;

namespace WKMR
{
    public class ReviewWindow : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private HealthCounter _healthCounter;
        [SerializeField] private KidScreener _screener;
        [SerializeField] private SceneSwitcher _endWindow;

        [Header("Fields")]
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_InputField _nameField;
        [SerializeField] private RawImage _image;

        [Header("Messages")]
        [SerializeField] private GameObject _savedMessage;
        [SerializeField] private GameObject _rejectMessage;

        private Texture2D _kidTexture;
        private int _health;
        private KidSaver _saver;

        private void Awake()
        {
            _kidTexture = _screener.LastScreenShot;
            _health = _healthCounter.GetHealthState();
            _saver = new();
        }

        private void Start()
        {
            _image.texture = _kidTexture;
            //_image.SetNativeSize();
            _healthText.text = _health.ToString() + "%";
        }

        public void Save()
        {
            if (_saver.TryToSave(_kidTexture, _nameField.text, _health))
                _savedMessage.SetActive(true);
            else
            {
                MessageManager.Instance.ShowMessage(ErrorType.KidClosed);
                Close();
            }
        }

        public void RejectSaving()
        {
            _rejectMessage.SetActive(true);
        }

        public void Close()
        {
            _endWindow.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
