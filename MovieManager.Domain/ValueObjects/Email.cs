namespace MovieManager.Domain.ValueObjects;

public class Email : ValueObject
{
    public string UserName { get; set; }
    public string DomainName { get; set; }

    public static Email For(string email)
    {
        var emailObj = new Email();
        try
        {
            var index = email.IndexOf("@", StringComparison.Ordinal);
            emailObj.UserName = email[..index];
            emailObj.DomainName = email[(index + 1)..];
        }
        catch (Exception exception)
        {
            throw new EmailException(email, exception);
        }

        return emailObj;

    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}