using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public class SoundAssets : MonoBehaviour
    {
        private static readonly string _containerName = "container";
        private static readonly string _objectName = "SoundAssets";

        private static SoundAssets _instance;

        [SerializeField] private SoundClip[] _clips;
        [SerializeField] private List<SoundClip> _bgClips;
        [SerializeField] private Transform _container;

        public static SoundAssets Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Instantiate(Resources.Load<SoundAssets>(_objectName));

                return _instance;
            }
        }

        public SoundClip[] SoundClips => _clips;
        public List<SoundClip> BgClips => _bgClips;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }

            SetContainer();
            SourcePool.Initiallize(_container);
        }

        private void SetContainer()
        {
            if (_container == null)
            {
                _container = new GameObject(_containerName).transform;
                _container.parent = transform;
            }
        }
    }
}