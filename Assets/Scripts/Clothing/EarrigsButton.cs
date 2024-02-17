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
                MessageManager.Instance.ShowMessage(ErrorType.NoEars);
                return false;
            }
        }

        private bool HumanlikeEars()
        {
            var ears = _earsContainer.transform.GetComponentInChildren<ItemTemplate>();

            if (ears.Item.Type == ItemType.HumEars)
            {
                return true;
            }
            else
            {
                MessageManager.Instance.ShowMessage(ErrorType.NotHumanEars);
                return false;
            }
        }
    }
}