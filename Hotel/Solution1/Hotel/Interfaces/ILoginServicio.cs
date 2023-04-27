using Modelos;

namespace Hotel.Interfaces
{
    public interface ILoginServicio
    {
        Task<bool> ValidarUsuario(Login login);
    }
}
