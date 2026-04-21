class PaymentObserver : IPaymentObserver
{
    public void Update(PaymentSubject subject)
    {
        if (subject is PaymentStatus paymentStatus)
        {
            Console.WriteLine($"Payment status updated: {paymentStatus.GetStatus()}");
        }
    }
}