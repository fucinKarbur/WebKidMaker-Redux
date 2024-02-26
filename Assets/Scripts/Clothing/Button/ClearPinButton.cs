using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public class ClearPinButton : MonoBehaviour
    {
        private PinButton _pinButton;
        private ItemData _pinData;
        private ItemContainer _container;
        
        private ButtonStatus _status => _pinButton.Status;

        public void Awake()
        {
            _pinButton = GetComponentInParent<PinButton>();

            _pinData = _pinButton.ItemData;
            _container = _pinButton.ClothContainer;
        }

        public void ClearPins()
        {
            _container.Reset(_pinData);
            _status.OnCleared(_pinData);
        }
    }
}
