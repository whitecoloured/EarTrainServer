using System;

namespace EarTrain.Core.Exceptions
{
    public class NotFoundException(string Message) : Exception(Message)
    {
        
    }
}
