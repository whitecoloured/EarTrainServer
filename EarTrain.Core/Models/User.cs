using EarTrain.Core.Enums;
using System;
using System.Collections.Generic;

namespace EarTrain.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public Address Address { get; set; }
        public int ETCoinsAmount { get; set; }
        public int TrainingsCompletedAmount { get; set; }
        public int SuccessfullyCompletedTrainingsAmount { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }

        public User()
        {
            Role = UserRole.User;
        }

        public static User Create(string Login, string Email, string Password, Address Address)
        {
            return new()
            {
                Login = Login,
                Email = Email,
                Password = Password,
                Address = Address
            };
        }
    }
}
