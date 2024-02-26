using UnityEngine;
using UnityEngine.UI;
using WKMR.System;

namespace WKMR
{
    public class Mode
    {
        protected Image Image;
        protected Kid Kid;

        private readonly GameObject[] _required;
        private readonly GameObject[] _unneeded;

        public Mode(Image image, Kid kid, GameObject[] required, GameObject[] unneeded)
        {
            Image = image;
            Kid = kid;

            _required = required;
            _unneeded = unneeded;
        }

        public virtual void Enter() => SwitchComponents();

        private void SwitchComponents()
        {
            foreach (var item in _required)
                item.SetActive(true);

            foreach (var item in _unneeded)
                item.SetActive(false);
        }
    }
}
