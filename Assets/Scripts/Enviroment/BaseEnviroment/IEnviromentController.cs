
public interface IEnviromentController
{
    void SwitchEnviromentOn<T>(params object[] parameters) where T : Enviroment;
    void SwitchEnviromentBack();
}
