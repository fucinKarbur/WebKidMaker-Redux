namespace WKMR
{
    public class OrganContainer : ClothContainer
    {
        public bool CheckOrgan()
        {
            var template = GetComponentInChildren<OrganTemplate>();

            return template != null && template.Organ.IsHealth;
        }
    }
}