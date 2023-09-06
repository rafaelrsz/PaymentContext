using FluentValidator.Validation;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Email : ValueObject
  {
    public Email(string address)
    {
      Address = address;

      AddNotifications(new ValidationContract()
        .Requires()
        .IsEmail(Address, "Email.Address", "Invalid email address!"));
    }

    public string Address { get; private set; }
  }
}