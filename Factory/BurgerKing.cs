class BurgerKing : IRestaurant
{
    private Menu menu;

    public BurgerKing()
    {
        menu = new Menu();
    }
    
    public void SetMenu(Menu menu)
    {
        // Add Base Items
        menu.AddItem("CheeseBurger", new CheeseBurger());
        menu.AddItem("Fries", new Fries());
        menu.AddItem("Coke", new Coke());
        menu.AddItem("Guarana Antarctica", new GuaranaAntarctica());
        menu.AddItem("Milkshake", new Milkshake());

        // Add specifics
        menu.AddItem("Whopper", new ExtraCheese(new Salad(new CheeseBurger())));
        menu.AddItem("Whopper Bacon", new Bacon(new ExtraCheese(new Salad(new CheeseBurger()))));
        menu.AddItem("Double Whopper", new ExtraPatty(new ExtraCheese(new Salad(new CheeseBurger()))));
        menu.AddItem("Strawberry Milkshake", new Strawberry(new Milkshake()));

        /* Note: Add Salad and Strawberry decorators */
    }
}