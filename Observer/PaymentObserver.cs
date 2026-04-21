class PaymentObserver : IPaymentObserver
{
    public void Update(PaymentStatus status)
    {
        Console.WriteLine($"Payment status updated: {status.GetStatus()}");
    }
}