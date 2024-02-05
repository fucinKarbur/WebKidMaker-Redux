using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WKMR.System
{
    public class SystemMenu : MonoBehaviour, IPointerExitHandler
    {
        //[SerializeField] private SettingsWindow _settingsWindow;

        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.SetActive(false);
        }
}
}