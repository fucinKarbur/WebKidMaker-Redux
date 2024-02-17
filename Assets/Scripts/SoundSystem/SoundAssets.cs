using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public class SoundAssets : MonoBehaviour
    {
        private static readonly string _containerName = "container";

        public static SoundAssets Instance;

        [SerializeField] private SoundClip[] _clips;
        [SerializeField] private List<SoundClip> _bgClips;
        [SerializeField] private Transform _container;

        public SoundClip[] SoundClips => _clips;
        public List<SoundClip> BgClips => _bgClips;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
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