namespace LegacyApp;

public interface IUserLimitProcessor
{
    public ClientType ClientType { get; }
    public void Process(User user);
}