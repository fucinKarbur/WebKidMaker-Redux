namespace WKMR
{
    public class SFXAssets : SoundAssets
    {
        private SFXPool _sourcePool;

        private void Awake()
        {
            _sourcePool = new SFXPool(Container, this);
            SourcePool = _sourcePool;
        }

        private void Start() => SourceProvider.SetAssets(this);
    }
}
