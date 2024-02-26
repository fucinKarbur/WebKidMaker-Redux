using UnityEngine;
using UnityEngine.UI;
using WKMR.System;

namespace WKMR
{
    public class DefaultMode : Mode
    {
        public DefaultMode(Image image, Kid kid, GameObject[] required, GameObject[] unneeded) : base(image, kid, required, unneeded)
        {
        }

        public override void Enter()
        {
            Kid.SetDefault();
            base.Enter();
        }
    }
}