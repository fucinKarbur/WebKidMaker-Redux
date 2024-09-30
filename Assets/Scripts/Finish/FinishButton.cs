using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WKMR.Clothing;
using WKMR.System;
using YG;

namespace WKMR
{
    public class FinishButton : MonoBehaviour
    {
        [SerializeField] private ItemContainer[] _containers;
        [SerializeField] private OrganContainer[] _organContainers;
        [SerializeField] private GameObject _finishMessage;

        private readonly int _itemsAmount = 5;
        private readonly int _organsAmount = 3;

        public void TryToFinish()
        {
            if (HasItems() == false)
                MessageManager.Instance.ShowMessage(ErrorType.NotEnoughItems, Vector3.zero);
            else if (HasOrgans() == false)
                MessageManager.Instance.ShowMessage(ErrorType.NotEnoughOrgans, Vector3.zero);
            else
                _finishMessage.SetActive(true);
        }

        private bool HasItems()
        {
            int filledContainers = 0;

            for (int i = 0; i < _containers.Length; i++)
            {
                if (_containers[i].HasItem())
                    filledContainers++;

                if (filledContainers >= _itemsAmount)
                    return true;
            }

            return false;
        }

        private bool HasOrgans()
        {
            if (YandexGame.savesData.ReadyForSurgery == false)
                return true;

            int filledContainers = 0;

            for (int i = 0; i < _organContainers.Length; i++)
            {
                if (_organContainers[i].HasItem())
                    filledContainers++;

                if (filledContainers >= _organsAmount)
                    return true;
            }

            return false;
        }
    }
}