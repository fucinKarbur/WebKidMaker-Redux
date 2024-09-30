using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WKMR.Clothing;
using YG;

namespace WKMR
{
    public class HealthCounter : MonoBehaviour
    {
        [SerializeField] private OrganContainer[] _organContainers;

        public int GetHealthState()
        {
            if (YandexGame.savesData.ReadyForSurgery == false)
                return 100;
            else
                return Calculate();
        }

        private int Calculate()
        {
            List<bool> organs = new();

            foreach (var container in _organContainers)
                organs.Add(container.CheckOrgan());

            var healthy = organs.Where(organ => organ).Count();
            int percentage = (int)((float)healthy / organs.Count * 100);

            return percentage;
        }
    }
}