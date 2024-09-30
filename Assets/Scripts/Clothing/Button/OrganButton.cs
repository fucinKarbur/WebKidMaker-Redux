using UnityEngine;
using UnityEngine.UI;
using WKMR.Coloring;
using WKMR.System;
using YG;
using Zenject;

namespace WKMR
{
    [RequireComponent(typeof(Button))]
    public class OrganButton : MonoBehaviour
    {
        /* [SerializeField] private OrganData[] _organs;
        [SerializeField] private OrganContainer _container;
        [SerializeField] private OrganTemplate _template;

        private Button _button;
        private Colorer _colorer;
        private int _index = -1;

        [Inject]
        private void Construct(CommonPalette palette)
        {
            _colorer = new(palette);
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable() => _button.onClick.AddListener(Spawn);

        private void OnDisable() => _button.onClick.RemoveListener(Spawn);

        public virtual void Spawn()
        {
            if (TryToSpawn())
            {
                _container.Clear();

                var spawned = Instantiate(_template, _container.transform.position, Quaternion.identity, _container.transform);
                SetOrgan(spawned);
            }
        }

        private bool TryToSpawn()
        {
            if (_container.gameObject.activeInHierarchy)
            {
                return true;
            }
            else
            {
                MessageManager.Instance.ShowMessage(ErrorType.KidClosed);
                return false;
            }
        }

        private void SetOrgan(OrganTemplate spawned)
        {
            var organ = GetOrgan();

            spawned.GetOrgan(organ);
            spawned.SetImage(organ.Icon);
            spawned.gameObject.name = organ.name;
            spawned.transform.localPosition += organ.Offset;

            if (organ.Colorable)
                _colorer.Colorize(spawned);
        }

        private OrganData GetOrgan()
        {
            _index++;

            if (_index >= _organs.Length)
                _index = 0;

            return _organs[_index];
        } */
    }
}