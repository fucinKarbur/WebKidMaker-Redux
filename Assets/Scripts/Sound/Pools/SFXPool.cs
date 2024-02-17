using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public class SFXPool : SourcePool
    {
        private readonly SFXAssets _assets;

        public Dictionary<SoundName, AudioSource> SFXSources { get; private set; } = new();

        public SFXPool(Transform container, SFXAssets assets) : base(container)
        {
            _assets = assets;
            Initiallize();
        }

        protected override void Initiallize()
        {
            foreach (var sound in _assets.SoundClips)
            {
                if (SFXSources.ContainsKey(sound.Name))
                    continue;

                SFXSources.Add(sound.Name, CreateSource(sound));
            }

            foreach (var source in SFXSources)
                Sources.Add(source.Value);
        }
    }
}