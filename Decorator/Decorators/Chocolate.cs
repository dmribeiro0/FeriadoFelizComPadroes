class Chocolate : MenuItemDecorator
{
    private double price = 1.0;
    
    public Chocolate(IMenuItem item) : base(item)
    {
    }

    public override double GetPrice()
    {
        return this.price + base.GetPrice();
    }
}