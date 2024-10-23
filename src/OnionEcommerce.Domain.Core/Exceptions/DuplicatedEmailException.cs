namespace OnionEcommerce.Domain.Core.Exceptions;

public class DuplicatedEmailException : Exception
{
    public DuplicatedEmailException(string email) : base($"Email {email} is already in use.") { }
}
