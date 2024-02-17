namespace WKMR
{
    public class SFXAssets : SoundAssets
    {
        private static SFXAssets _instance;
        private SFXPool _sourcePool;

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

            _sourcePool = new SFXPool(Container, this);
            SourcePool = _sourcePool;
            
            SourceProvider.SetAssets(this);
        }
    }
}
