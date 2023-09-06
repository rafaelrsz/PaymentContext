using FluentValidator.Validation;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
  public class Student : Entity
  {
    private IList<Subscription> _subscriptions;
    public Student(Name name, Document document, Email email, Address address)
    {
      Name = name;
      Document = document;
      Email = email;
      Address = address;
      _subscriptions = new List<Subscription>();

      AddNotifications(name, document, email, address);
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

    public void AddSubscription(Subscription subscription)
    {
      var hasSubscriptionActive = _subscriptions.Any(p => p.Active);

      AddNotifications(new ValidationContract()
        .Requires()
        .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "You alredy has an active subscription!")
      );
    }
  }
}

