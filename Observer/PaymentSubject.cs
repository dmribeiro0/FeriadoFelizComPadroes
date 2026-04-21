class PaymentSubject
{
    private List<IPaymentObserver> observers = new List<IPaymentObserver>();

    public void Attach(IPaymentObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IPaymentObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(this);
        }
    }
}