using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageUI : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> uIElement = new List<GameObject>();
    protected IPageUIController _pageController;
    public IPageUIController PageController
    {
        get
        {
            return _pageController;
        }
        private set
        {
            _pageController = value;
        }
    }

    public bool isActivated = false;

    void Awake()
    {
        PageController = transform.parent.GetComponent(typeof(IPageUIController)) as IPageUIController;
        DeactivatedElement();
    }

    protected virtual void Start()
    {

    }

    public virtual void SetActivate(bool value, params object[] parameters)
    {
        if (!value && !isActivated || value && isActivated) return;

        foreach (var ui in uIElement)
        {
            ui.SetActive(value);
        }

        if (value) isActivated = true;
        else isActivated = false;
    }

    public virtual void ReOpen()
    {
        foreach (var ui in uIElement)
        {
            ui.SetActive(true);
        }

        isActivated = true;
    }

    protected void DeactivatedElement()
    {
        foreach (var ui in uIElement)
        {
            ui.SetActive(false);
        }
    }

    public void StartLoadBar()
    {
        //_pageUIController.loadBar.StartLoadBar();
    }

    public void StopLoadBar()
    {
        //_pageUIController.loadBar.StopLoadBar();
    }
}
