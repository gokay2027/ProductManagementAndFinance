namespace ProductManagementAndFinanceApi.Models.Command.User
{
    public class UserUpdateInputModel
    {
        //Id to get user
        public Guid Id { get; set; }

        //Data to be updated
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}