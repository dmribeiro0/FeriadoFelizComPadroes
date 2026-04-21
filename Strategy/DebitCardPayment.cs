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
        paymentStatus.SetStatus("Processing payment.");
        paymentStatus.SetStatus("Payment processed.");
        Console.WriteLine($"Paid {amount} using Debit Card.");
    }
}