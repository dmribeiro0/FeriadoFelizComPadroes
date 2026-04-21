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
        menu.AddItem("CheeseBurger", () => new CheeseBurger());
        menu.AddItem("Fries", () => new Fries());
        menu.AddItem("Coke", () => new Coke());
        menu.AddItem("Guarana Antarctica", () => new GuaranaAntarctica());
        menu.AddItem("Milkshake", () => new Milkshake());

        // Add specifics
        menu.AddItem("Whopper", () => new ExtraCheese(new Salad(new CheeseBurger())));
        menu.AddItem("Whopper Bacon", () => new Bacon(new ExtraCheese(new Salad(new CheeseBurger()))));
        menu.AddItem("Double Whopper", () => new ExtraPatty(new ExtraCheese(new Salad(new CheeseBurger()))));
        menu.AddItem("Strawberry Milkshake", () => new Strawberry(new Milkshake()));

        // Combos
        Combo whopperCombo = new ComboFacade.CreateCombo(menu.GetItem("Whopper"), menu.GetItem("Fries"), menu.GetItem("Coke"));
        menu.AddItem("Whopper Combo", () => whopperCombo);

        Combo whopperBaconCombo = new ComboFacade.CreateCombo(menu.GetItem("Whopper Bacon"), menu.GetItem("Fries"), menu.GetItem("Coke"));
        menu.AddItem("Whopper Bacon Combo", () => whopperBaconCombo);

        Combo strawberryMilkshakeCombo = new ComboFacade.CreateCustomCombo(new List<IMenuItem> { menu.GetItem("Strawberry Milkshake"), menu.GetItem("Fries") });
        menu.AddItem("Strawberry Milkshake Combo", () => strawberryMilkshakeCombo);
    }
}