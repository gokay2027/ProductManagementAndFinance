namespace ProductManagementAndFinanceApi.Models.Command.User
{
    public class UserAddInputModel
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}