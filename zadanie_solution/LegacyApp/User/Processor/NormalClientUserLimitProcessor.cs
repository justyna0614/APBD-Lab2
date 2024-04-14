namespace LegacyApp;

public class NormalClientUserLimitProcessor : IUserLimitProcessor
{
    public ClientType ClientType => ClientType.NormalClient;
    public void Process(User user)
    {
        user.HasCreditLimit = true;
        var userCreditService = new UserCreditService();
        int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        user.CreditLimit = creditLimit;
    }

}