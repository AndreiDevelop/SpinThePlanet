public interface IPageUIController
{
    void SwitchPageOn<T>(params object[] parameters) where T : PageUI;
    void SwitchPageBack();
}
