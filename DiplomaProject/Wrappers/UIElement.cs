namespace TestProject1.Wrappers;

public class UIElement : BaseElement
{
    public UIElement(By locator) : base(locator)
    {
    }

    public UIElement(string locator) : base(locator)
    {
    }
}