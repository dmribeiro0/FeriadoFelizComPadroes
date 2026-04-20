class MenuItemDecorator : IMenuItem
{
    protected IMenuItem menuItem;

    public MenuItemDecorator(IMenuItem item)
    {
        this.menuItem = item;
    }

    public virtual double GetPrice()
    {
        return menuItem.GetPrice();
    }
}