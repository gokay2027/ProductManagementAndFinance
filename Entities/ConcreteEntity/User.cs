using Entities.AbstractEntity;

namespace Entities.ConcreteEntity
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //Has
        public List<Storage> Storages { get; private set; } = new List<Storage>();

        public List<Order> Orders { get; private set; } = new List<Order>();

        public Guid FinanceId { get; private set; }
        public Finance Finance { get; private set; }

        public User()
        { }

        public User(string userName, string name, string surname, string email, string password)
        {
            UserName = userName;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }

        public void UpdateUser(string userName, string name, string surname, string email, string password)
        {
            UserName = userName;
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            SetUpdateDate();
        }

        public bool ChangeUserPassword(string userName, string password, string newPassword)
        {
            if (userName.Equals(UserName) && password.Equals(Password))
            {
                Password = newPassword;
                SetUpdateDate();
                return true;
            }
            return false;
        }
    }
}