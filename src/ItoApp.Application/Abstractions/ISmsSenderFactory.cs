namespace ItoApp.Application.Abstractions;

public interface ISmsSenderFactory
{
    ISmsSender GetSender(string providerName);
}


