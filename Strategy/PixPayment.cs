class PixPayment : IPaymentMethod
{
    private PaymentStatus paymentStatus;

    public PixPayment()
    {
        paymentStatus = new PaymentStatus();
    }

    public void SetObserver(IPaymentObserver observer)
    {
        paymentStatus.Attach(observer);
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"[Payment | Pix] Processing payment of ${amount:0.00}");
        paymentStatus.SetStatus("Processing payment.");
        paymentStatus.SetStatus("Payment processed.");
        Console.WriteLine("[Payment | Pix] Payment completed.");
    }
}