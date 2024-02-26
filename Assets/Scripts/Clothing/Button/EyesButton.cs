namespace WKMR
{
    public class EyesButton : ItemButton
    {
        protected override void SetItem(ItemTemplate spawned)
        {
            var eyestemplate = spawned as EyesTemplate;

            eyestemplate.GetData(Item as EyesData);
            base.SetItem(spawned);
        }
    }
}