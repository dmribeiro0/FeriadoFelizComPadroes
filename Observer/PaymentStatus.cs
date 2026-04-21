class PaymentStatus : PaymentSubject
{
    private string status = string.Empty;

    public void SetStatus(string newStatus)
    {
        status = newStatus;
        NotifyObservers();
    }

    public string GetStatus()
    {
        return status;
    }
}