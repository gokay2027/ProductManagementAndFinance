namespace ProductManagementAndFinanceApi.Models.Command.User
{
    public class UserChangePasswordInputModel
    {
        public Guid? Id { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}