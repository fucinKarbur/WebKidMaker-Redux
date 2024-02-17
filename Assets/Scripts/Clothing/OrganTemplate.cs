namespace WKMR
{
    public class OrganTemplate : ItemTemplate
    {
        public OrganData Organ { get; private set; }
        
        public void GetOrgan(OrganData data) => Organ = data;
    }
}