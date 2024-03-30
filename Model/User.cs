using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace CampusNex.Model
{

    internal abstract class User
    {
        // Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public Image UserImage { get; set; }

        // Constructor
        public User()
        {
            // Default constructor
        }

        // Methods
        // Getters
        public string GetUsername()
        {
            return Username;
        }

        public string GetPassword()
        {
            return Password;
        }

        public int GetUserId()
        {
            return UserId;
        }

        public string GetRole()
        {
            return Role;
        }

        public string GetEmail()
        {
            return Email;
        }

        public Image GetUserImage()
        {
            return UserImage;
        }

        // Setters
        public void SetUsername(string username)
        {
            Username = username;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }

        public void SetRole(string role)
        {
            Role = role;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetUserImage(Image image)
        {
            UserImage = image;
        }

        // Other methods
        public bool ValidateUser(string username, string password)
        {
            // Implement validation logic here
            return true; // Example: Always return true for now
        }

        public void FetchData(string username)
        {
            // Implement data fetching logic here
        }

        public void SearchSociety(string keyword)
        {
            // Implement society search logic here
        }
    }

}
