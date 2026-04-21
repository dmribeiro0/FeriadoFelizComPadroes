class McDonalds : IRestaurant
{
    private Menu menu;

    public McDonalds()
    {
        menu = new Menu();
        SetMenu(menu);
    }

    public Menu GetMenu()
    {
        return menu;
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
        menu.AddItem("Big Mac", () => new ExtraBun(new ExtraCheese(new ExtraPatty(new CheeseBurger()))));
        menu.AddItem("Big Mac Bacon", () => new Bacon(new ExtraCheese(new ExtraPatty(new CheeseBurger()))));
        menu.AddItem("Chocolate Milkshake", () => new Chocolate(new Milkshake()));

        // Combos
        menu.AddItem("Big Mac Combo", () => ComboFacade.CreateCombo(menu.GetItem("Big Mac"), menu.GetItem("Fries"), menu.GetItem("Coke")));

        menu.AddItem("Big Mac Bacon Combo", () => ComboFacade.CreateCombo(menu.GetItem("Big Mac Bacon"), menu.GetItem("Fries"), menu.GetItem("Coke")));

        menu.AddItem("Chocolate Milkshake Combo", () => ComboFacade.CreateCustomCombo(new List<IMenuItem> { menu.GetItem("Chocolate Milkshake"), menu.GetItem("Fries") }));
    }
}