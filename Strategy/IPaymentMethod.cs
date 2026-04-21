interface IPaymentMethod
{
    void SetObserver(IPaymentObserver observer);
    void Pay(double amount);
}


