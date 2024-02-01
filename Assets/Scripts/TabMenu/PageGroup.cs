using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace WKMR
{
    public class PageGroup : MonoBehaviour
    {
        [SerializeField] private PageControl _control;
        [SerializeField] private List<Page> _pages;
        [SerializeField] private TMP_Text _count;

        public Page Current { get; private set; }
        public int Index { get; private set; } = 0;

        private void Awake()
        {
            _control.gameObject.SetActive(_pages.Count > 1);

            if (Current == null && _pages.Count != 0)
            {
                Current = _pages[Index];
                UpdatePages();
            }
        }

        public void OpenNextPage()
        {
            Index++;

            if (Index == _pages.Count)
                Index = 0;

            OpenPage();
        }

        public void OpenPreviousPage()
        {
            Index--;

            if (Index < 0)
                Index = _pages.Count - 1;

            OpenPage();
        }

        private void OpenPage()
        {
            Current = _pages[Index];
            UpdatePages();
        }

        private void UpdatePages()
        {
            foreach (var page in _pages)
                if (page == Current)
                    page.gameObject.SetActive(true);
                else
                    page.gameObject.SetActive(false);

            if (_control.gameObject.activeSelf)
                UpdateCount();
        }

        private void UpdateCount() => _count.text = Index + 1 + " / " + _pages.Count;
    }
}