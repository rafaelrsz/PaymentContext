using FluentValidator.Validation;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
  public abstract class Payment : Entity
  {
    protected Payment(DateTime paidDate,
                      DateTime expireDate,
                      decimal total,
                      decimal totalPaid,
                      string owner,
                      Document document,
                      Address address,
                      Email email)
    {
      Number = Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpper();
      PaidDate = paidDate;
      ExpireDate = expireDate;
      Total = total;
      TotalPaid = totalPaid;
      Owner = owner;
      Document = document;
      Address = address;
      Email = email;


      AddNotifications(new ValidationContract()
        .Requires()
        .IsGreaterThan(0, Total, "Payment.total", "Total must be greater than 0!")
        .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "TotalPaid is less than Total!")
      );
    }

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Owner { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
  }
}