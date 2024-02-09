namespace ProductManagementAndFinanceApi.Models.Command.Storage
{
    public class AddStorageInputModel
    {
        public string Name { get; set; }
        public Guid? UserId { get; set; }
        public string Adress { get; set; }
    }
}
