using SwaggerIntegration_CoreWebApi.Model;

namespace SwaggerIntegration_CoreWebApi.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }
}
