using System; 
namespace testperformance.Exceptions
{
    // Excepción personalizada para cuando una mascota no se encuentra
    public class  NotFoundException : Exception 
    {
        public NotFoundException(string message): base(message) {} // constructor que recibe un mensaje y una excepción interna
    }
}