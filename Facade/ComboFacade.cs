class ComboFacade
{
    public static Combo CreateCombo(IMenuItem mainCourse, IMenuItem side, IMenuItem drink)
    {
        Combo combo = new Combo();
        combo.AddItem(mainCourse);
        combo.AddItem(side);
        combo.AddItem(drink);
        return combo;
    }

    public static Combo CreateCustomCombo(List<IMenuItem> items)
    {
        Combo combo = new Combo();
        foreach (var item in items)
        {
            combo.AddItem(item);
        }
        return combo;
    }
}