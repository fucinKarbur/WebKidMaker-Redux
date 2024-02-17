using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace WKMR
{
    public class TESTSTUFF : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Reset();
        }

        private void Reset() {
            YandexGame.savesData.SurgeryRefused = false;
        }
    }
}
