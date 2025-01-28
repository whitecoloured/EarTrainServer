using EarTrain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Users.EditUserData
{
    public record class EditUserModel(string Email, string Login, Address Address);
}
