namespace CustomerFlow.Core.Domain.Enums;

public enum SendTypeCommunication
{
    Email = 1,
    Sms = 2,
    Push = 3,
    Voicemail = 4,
}

public static class SendTypeExtensions
{
    public static string ToValue(this SendTypeCommunication sendType) => sendType switch
    {
        SendTypeCommunication.Email => "email",
        SendTypeCommunication.Sms => "sms",
        SendTypeCommunication.Push => "push",
        SendTypeCommunication.Voicemail => "voicemail",
        _ => throw new ArgumentOutOfRangeException(nameof(sendType), sendType, null)
    };
}
