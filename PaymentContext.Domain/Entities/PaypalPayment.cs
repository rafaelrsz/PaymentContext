namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(string transactionCode,
                             DateTime paidDate,
                             DateTime expireDate,
                             decimal total,
                             decimal totalPaid,
                             string owner,
                             string document,
                             string address,
                             string email) : base(paidDate, expireDate, total, totalPaid, owner, document, address, email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}