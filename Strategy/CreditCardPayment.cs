class CreditCardPayment : IPaymentMethod
{
    private PaymentStatus paymentStatus;

    public CreditCardPayment()
    {
        paymentStatus = new PaymentStatus();
    }

    public void SetObserver(IPaymentObserver observer)
    {
        paymentStatus.Attach(observer);
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"[Payment | Credit Card] Processing payment of ${amount:0.00}");
        paymentStatus.SetStatus("Processing payment.");
        paymentStatus.SetStatus("Payment processed.");
        Console.WriteLine("[Payment | Credit Card] Payment completed.");
    }
}