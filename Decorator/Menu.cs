class Menu
{
    private Dictionary<string, Func<IMenuItem>> menuItems = new();

    public void AddItem(string name, Func<IMenuItem> creator)
    {
        menuItems[name] = creator;
    }

    public IMenuItem GetItem(string name)
    {
        if (menuItems.ContainsKey(name))
        {
            return menuItems[name](); // creates a NEW object
        }
        else
        {
            throw new Exception("Menu item not found.");
        }
    }
}