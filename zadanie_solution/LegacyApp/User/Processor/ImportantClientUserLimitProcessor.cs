namespace LegacyApp;

public class ImportantClientUserLimitProcessor : IUserLimitProcessor
{
    public ClientType ClientType => ClientType.ImportantClient;

    public void Process(User user)
    {
        user.HasCreditLimit = true;
        var userCreditService = new UserCreditService();
        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        creditLimit *= 2;
        user.CreditLimit = creditLimit;
    }
}