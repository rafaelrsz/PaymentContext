using FluentValidator.Validation;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
  public class Name : ValueObject
  {
    public Name(string firstName, string lastName)
    {
      FirstName = firstName;
      LastName = lastName;

      AddNotifications(new ValidationContract()
        .Requires()
        .HasMinLen(FirstName, 3, "Name.FirstName", "FirstName must have at least 3 characters")
        .HasMaxLen(FirstName, 40, "Name.FirstName", "FirstName must not have more then 40 characters")
        .HasMinLen(LastName, 3, "Name.LastName", "LastName must have at least 3 characters")
        .HasMaxLen(LastName, 100, "Name.LastName", "LastName must not have more then 100 characters"));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
  }
}