using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public abstract class SoundAssets : MonoBehaviour
    {
        [SerializeField] protected List<SoundClip> Clips;
        [SerializeField] protected Transform Container;

        protected SourcePool SourcePool;

        public List<SoundClip> SoundClips => Clips;
        public SourcePool Pool => SourcePool;
    }
}