using AKSoftware.Blazor.Utilities;
using MV.Framework.interfaces;

namespace Domain.Infrastructure.services
{
    /// <summary>
    /// Just pretending we have a login system in place
    /// </summary>
    public class UserService : IUserService
    {
        protected UserInfo _CurrentUser { get; set; }
        protected string _AdminUsername = "admin";
        protected List<UserInfo> _Users;
        //public NavigationManager NavigationManager { get; set; }



        public UserService(List<UserInfo> users)
        {
            _Users = users;
        }
        public bool LogIn(string username, string password)
        {
            if (username == "")
            {
                return false;
            }
            var users = _Users.AsQueryable();
            _CurrentUser = users.Where(x => x.Username == username).SingleOrDefault();
            if (_CurrentUser == null)
            {
                return false;
            }
            NotifyUserChanged();

            return true;
        }

        protected void NotifyUserChanged()
        {
            string valueToSend = _CurrentUser.Username;
            MessagingCenter.Send(this, "OnUserChanged", valueToSend);
        }
        public void LogOut()
        {
            Console.WriteLine(_CurrentUser + " has logged out");
        }

        public UserInfo GetCurrentUser()
        {
            return _CurrentUser;
        }

        public bool IsAdmin()
        {
            if (_CurrentUser.Username == _AdminUsername)
            {
                return true;
            }
            return false;
        }
        public List<UserInfo> GetUsers()
        {
            return _Users;
        }
    }
}
