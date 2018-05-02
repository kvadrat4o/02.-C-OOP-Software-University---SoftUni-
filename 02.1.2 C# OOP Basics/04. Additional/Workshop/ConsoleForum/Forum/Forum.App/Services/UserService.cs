namespace Forum.App.Services
{
    using Forum.Data;
    using System.Collections.Generic;
    using System.Linq;
    using static Forum.App.Controllers.SignUpController;
    using Forum.Models;

    public static class UserService
    {
        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData fd = new ForumData();

            bool userExists = fd.Users.Any(u => u.Username == username && u.Password == password);

            return userExists;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validPassword || !validUsername)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData fd = new ForumData();

            bool userAlreadyExists = fd.Users.Any(u => u.Username == username);

            if (!userAlreadyExists)
            {
                int userId = fd.Users.LastOrDefault()?.Id + 1 ?? 1;
                User user = new User(userId, username, password,new List<int>());
                fd.Users.Add(user);
                fd.SaveChanges();
                return SignUpStatus.Success;
            }
            return SignUpStatus.UsernameTakenError;
        }

        internal static User GetUser(int userId)
        {
            var fd = new ForumData();
            User user = fd.Users.Find(u => u.Id == userId);

            return user;
        }

        internal static User GetUser(string username, ForumData fd)
        {
            User user = fd.Users.Find(u => u.Username == username);

            return user;
        }
    }
}
