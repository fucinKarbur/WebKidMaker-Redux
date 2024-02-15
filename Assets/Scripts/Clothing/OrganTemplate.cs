using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace WKMR
{
    public class OrganTemplate : ItemTemplate
    {
        public OrganData Organ { get; private set; }
        
        public void GetOrgan(OrganData data) => Organ = data;
    }
}