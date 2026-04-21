class PaymentStatus : PaymentSubject
{
    private string status;

    public void SetStatus(string newStatus)
    {
        status = newStatus;
        NotifyObservers(this);
    }

    public string GetStatus()
    {
        return status;
    }
}