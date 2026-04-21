class Combo : IMenuItem
{
    private List<IMenuItem> items;
    private double price;

    public Combo()
    {
        this.items = new List<IMenuItem>();
        this.price = 0.0;
    }

    public void AddItem(IMenuItem item)
    {
        this.items.Add(item);
        this.price += item.GetPrice();
    }

    public double GetPrice()
    {
        return this.price;
    }
}