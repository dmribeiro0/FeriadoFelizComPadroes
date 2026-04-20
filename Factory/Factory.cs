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