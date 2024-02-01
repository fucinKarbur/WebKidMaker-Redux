using UnityEngine;

namespace WKMR
{
    public class ClothContainer : MonoBehaviour
    {
        public void Reset()
        {
            foreach (var item in GetComponentsInChildren<ClothTemplate>())
                Destroy(item.gameObject);
        }
    }
}