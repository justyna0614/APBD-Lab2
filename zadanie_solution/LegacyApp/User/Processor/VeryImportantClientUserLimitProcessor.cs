namespace LegacyApp;

public class VeryImportantClientUserLimitProcessor : IUserLimitProcessor
{
    public ClientType ClientType => ClientType.VeryImportantClient;
    public void Process(User user)
    {
        user.HasCreditLimit = false;
    }
}