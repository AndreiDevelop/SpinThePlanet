using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> enviromentElement = new List<GameObject>();
    protected IEnviromentController _enviromentController;
    public IEnviromentController PageController
    {
        get
        {
            return _enviromentController;
        }
        private set
        {
            _enviromentController = value;
        }
    }

    public bool isActivated = false;

    void Awake()
    {
        PageController = transform.parent.GetComponent(typeof(IEnviromentController)) as IEnviromentController;
        DeactivatedElement();
    }

    protected virtual void Start()
    {

    }

    public virtual void SetActivate(bool value, params object[] parameters)
    {
        if (!value && !isActivated || value && isActivated) return;

        foreach (var enviroment in enviromentElement)
        {
            enviroment.SetActive(value);
        }

        if (value) isActivated = true;
        else isActivated = false;
    }

    public virtual void ReOpen()
    {
        foreach (var enviroment in enviromentElement)
        {
            enviroment.SetActive(true);
        }

        isActivated = true;
    }

    protected void DeactivatedElement()
    {
        foreach (var enviroment in enviromentElement)
        {
            enviroment.SetActive(false);
        }
    }
}
