namespace WKMR
{
    public class MusicAssets : SoundAssets
    {
        private static MusicAssets _instance;
        protected MusicPool _sourcePool;

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

            _sourcePool = new MusicPool (Container, this);
            SourcePool = _sourcePool;
        }
    }
}
