using WKMR.Coloring;
using Zenject;

namespace WKMR
{
    public class EyesButton : ItemButton
    {
        [Inject]
        private void Construct(EyePalette palette)
        {
            _colorer = new(palette);
        }

        protected override void SetItem(ItemTemplate spawned)
        {
            var eyestemplate = spawned as EyesTemplate;

            eyestemplate.GetData(Item as EyesData);
            base.SetItem(spawned);
        }
    }
}