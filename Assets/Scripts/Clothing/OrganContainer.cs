using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WKMR
{
    public class OrganContainer : ClothContainer
    {
        public bool CheckOrgan()
        {
            var template = GetComponentInChildren<OrganTemplate>();

            return template != null && template.Organ.IsHealth;
        }
    }
}