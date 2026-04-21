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
        paymentStatus.SetStatus("Processing payment.");
        paymentStatus.SetStatus("Payment processed.");
        Console.WriteLine($"Paid {amount} using Credit Card.");
    }
}