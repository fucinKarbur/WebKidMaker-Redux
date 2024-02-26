using UnityEngine;

namespace WKMR
{
    public class OrganContainer : ItemContainer
    {
        [SerializeField] private BloodClick _clickEffect;

        public BloodClick BloodClick => _clickEffect;

        public bool CheckOrgan()
        {
            var template = GetComponentInChildren<OrganTemplate>();

            return template != null && template.Organ.IsHealth;
        }
    }
}