interface IOrderingSystem
{
    void DisplayMenu();
    void AddToOrder(string itemName);
    void RemoveFromOrder(string itemName);
    void DisplayOrder();
    void SetPaymentMethod(string method);
    void PlaceOrder();
}