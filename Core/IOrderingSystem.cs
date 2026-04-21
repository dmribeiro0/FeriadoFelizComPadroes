interface IOrderingSystem
{
    public void DisplayMenu();
    public void AddToOrder(string itemName);
    public void RemoveFromOrder(string itemName);
    public void DisplayOrder();
    public void SetPaymentMethod(string method);
    public void PlaceOrder();
}