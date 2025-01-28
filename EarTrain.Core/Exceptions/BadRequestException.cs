using System;


namespace EarTrain.Core.Exceptions
{
    public class BadRequestException(string Message) : Exception(Message)
    {

    }
}
