using System; 
namespace testperformance.Exceptions
{
    
    public class  NotFoundException : Exception 
    {
        public NotFoundException(string message): base(message) {} // builder receives a message 
    }
}