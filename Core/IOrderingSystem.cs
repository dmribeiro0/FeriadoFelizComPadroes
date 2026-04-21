interface IOrderingSystem
{
    void DisplayMenu();
    void AddToOrder(string itemName);
    void RemoveFromOrder(string itemName);
    void DisplayOrder();
    void SetPaymentMethod(IPaymentMethod method);
    void PlaceOrder();
}