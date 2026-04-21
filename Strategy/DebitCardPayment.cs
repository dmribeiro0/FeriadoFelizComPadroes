class DebitCardPayment : IPaymentMethod
{
    // PaymentStatus is used to notify observers about the payment status
    private PaymentStatus paymentStatus;

    public DebitCardPayment()
    {
        paymentStatus = new PaymentStatus();
    }

    public void SetObserver(IPaymentObserver observer)
    {
        paymentStatus.Attach(observer);
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"[Payment | Debit Card] Processing payment of ${amount:0.00}");
        paymentStatus.SetStatus("Processing payment.");
        paymentStatus.SetStatus("Payment processed.");
        Console.WriteLine("[Payment | Debit Card] Payment completed.");
    }
}