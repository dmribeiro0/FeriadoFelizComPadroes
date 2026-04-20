class RestaurantFactory
{
    public static IRestaurant Create(string restaurant)
    {
        restaurant = restaurant.Trim().ToLower();
        switch (restaurant)
        {
            case "mcdonald's":
                return new McDonalds();
            case "burger king":
                return new BurgerKing();
            default:
                throw new ArgumentException("Invalid restaurant");
        }
    }
}

interface IRestaurant
{
    void SetMenu(Menu menu);
}

class McDonalds : IRestaurant
{
    private Menu menu;

    public void SetMenu(Menu menu)
    {
        // Set McDonald's specific menu
    }
}

class BurgerKing : IRestaurant
{
    private Menu menu;
    
    public void SetMenu(Menu menu)
    {
        // Set Burger King's specific menu
    }
}