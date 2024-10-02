using UnityEngine;
using WKMR.System;

namespace WKMR.Clothing
{
    public class ClearButton : MonoBehaviour
    {
        [field: SerializeField] public ItemContainer Container { get; private set; }

        public void Clear()
        {
            if (Container.gameObject.activeInHierarchy)
                Container.Clear();
            else
                MessageManager.Instance.ShowMessage(ErrorType.KidClosed);
        }
    }
}