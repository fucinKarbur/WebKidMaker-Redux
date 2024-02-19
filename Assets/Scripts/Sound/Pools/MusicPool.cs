using UnityEngine;

namespace WKMR
{
    public class MusicPool : SourcePool
    {
        private readonly MusicAssets _assets;

        public MusicPool(Transform container, MusicAssets assets) : base(container)
        {
            _assets = assets;
            Initiallize();
        }

        protected override void Initiallize()
        {
            if (Sources.Count != 0)
                return;

            CreateSource();
        }

        private void CreateSource()
        {
            var source = CreateSource(_assets.SoundClips[0]);
            source.loop = true;
            source.playOnAwake = true;
            source.Play();

            Sources.Add(source);
        }
    }
}