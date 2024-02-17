namespace WKMR.System.PointReacts.Reactions
{
    public class SoundPlay : Reaction
    {
        private readonly SoundPlayer _player;

        public SoundPlay(SoundName sound)
        {
            _player = new (sound);
        }

        public override void React() => _player.PlaySound();

        public override void SetDefault() { }
    }
}