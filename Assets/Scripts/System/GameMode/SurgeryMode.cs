using UnityEngine;
using UnityEngine.UI;
using WKMR.System;

namespace WKMR
{
    public class SurgeryMode : Mode
    {
        public SurgeryMode(Image image, Kid kid, GameObject[] required, GameObject[] unneeded) : base(image, kid, required, unneeded)
        {
        }

        public override void Enter()
        {
            Kid.PrepareForSurgery();
            base.Enter();
        }
    }
}