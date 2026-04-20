class Menu
{
    private Dictionary<string, IMenuItem> menuItems;

    public Menu()
    {
        menuItems = new Dictionary<string, IMenuItem>();
    }

    public void AddItem(string name, IMenuItem item)
    {
        menuItems[name] = item;
    }

    public IMenuItem GetItem(string name)
    {
        if (menuItems.ContainsKey(name))
        {
            return menuItems[name];
        }
        else
        {
            throw new Exception("Menu item not found.");
        }
    }
}