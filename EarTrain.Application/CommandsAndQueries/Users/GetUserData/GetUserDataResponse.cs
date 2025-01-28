using EarTrain.Core.Models;

namespace EarTrain.Application.CommandsAndQueries.Users.GetUserData
{
    public class GetUserDataResponse
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public int ETCoinsAmount { get; set; }
        public int TrainingsCompletedAmount { get; set; }
        public int SuccessfullyCompletedTrainingsAmount { get; set; }
    }
}
