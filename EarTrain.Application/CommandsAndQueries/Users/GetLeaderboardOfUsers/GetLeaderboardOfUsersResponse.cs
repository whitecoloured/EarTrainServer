using System;

namespace EarTrain.Application.CommandsAndQueries.Users.GetLeaderboardOfUsers
{
    public class GetLeaderboardOfUsersResponse
    {
        public Guid ID { get; set; }
        public string UserLogin { get; set; }
        public int SuccessfulTrainingsAmount { get; set; }
    }
}
