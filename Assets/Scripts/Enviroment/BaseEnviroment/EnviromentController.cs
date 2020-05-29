using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour, IEnviromentController
{
    private List<Enviroment> _enviroments;
    private Stack<Enviroment> _enviromentsHistory;

    void Awake()
    {
        _enviroments = new List<Enviroment>();
        _enviromentsHistory = new Stack<Enviroment>();
        _enviroments.AddRange(GetComponentsInChildren<Enviroment>());
    }

    #region IEnviromentController

    /// <summary>
    /// go to page type T where T:Page
    /// </summary>
    /// <typeparam name="T">go to page type T</typeparam>
    public void SwitchEnviromentOn<T>(params object[] parameters) where T : Enviroment
    {
        Enviroment enviromentActvate = null;
        foreach (var enviroment in _enviroments)
        {
            if (enviroment.GetType() == typeof(T))
            {
                enviromentActvate = enviroment;
                //PageSetActivate(page);
                _enviromentsHistory.Push(enviroment);
            }
            else
            {
                enviroment.SetActivate(false);
            }
        }
        enviromentActvate.SetActivate(true, parameters);
    }

    public void SwitchEnviromentBack()
    {
        //_pagesHistory.Peek().isActivated = false;
        print(_enviromentsHistory.Peek().GetType());
        _enviromentsHistory.Pop();
        print(_enviromentsHistory.Peek().GetType());
        Enviroment enviromentActvate = null;
        foreach (var enviroment in _enviroments)
        {
            if (enviroment.GetType() == _enviromentsHistory.Peek().GetType())
            {
                enviromentActvate = enviroment;
                //PageSetActivate(page);
            }
            else
            {
                enviroment.SetActivate(false);
            }
        }
        enviromentActvate.ReOpen();
    }

    #endregion IMenuController

    private void DeactivateEnviroments()
    {
        foreach (var enviroment in _enviroments)
        {
            enviroment.SetActivate(false);
        }
    }
}
