using ZKP.Models;
namespace ZKP.Services
{
    public interface IEntertainmentService
    {
        EntertainmentResponse CheckIfAdult(string phoneNumber);
    }
}