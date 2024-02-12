using UnityEngine;

namespace WKMR
{
    public class EarrigsButton : ItemButton
    {
        [SerializeField] private ClothContainer _earsContainer;

        public override void Spawn()
        {
            if (TryToSpawn())
            {
                if (HasEars() && HumanlikeEars())
                    base.Spawn();
            }
        }

        private bool HasEars()
        {
            if (_earsContainer.transform.childCount != 0)
            {
                return true;
            }
            else
            {
                MessageManager.Instance.ShowMessage(MessageManager.NoEars);
                return false;
            }
        }

        private bool HumanlikeEars()
        {
            var ears = _earsContainer.transform.GetComponentInChildren<ClothTemplate>();

            if (ears.Item.Type == ItemType.HumEars)
            {
                return true;
            }
            else
            {
                MessageManager.Instance.ShowMessage(MessageManager.NotHumanEars);
                return false;
            }
        }
    }
}