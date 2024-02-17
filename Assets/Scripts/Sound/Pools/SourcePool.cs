using System.Collections.Generic;
using UnityEngine;

namespace WKMR
{
    public abstract class SourcePool
    {
        protected Transform Container;

        public List<AudioSource> Sources { get; protected set; } = new();

        public SourcePool(Transform container) => Container = container;

        protected virtual void Initiallize() { }

        protected AudioSource CreateSource(SoundClip sound)
        {
            GameObject soundObject = new(sound.Name.ToString());
            soundObject.transform.parent = Container;

            var source = soundObject.AddComponent<AudioSource>();
            source.clip = sound.Clip;

            return source;
        }
    }
}