using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotEvolutionPage : PageUI
{
    [SerializeField] private EnviromentController _enviromentController;
    [SerializeField] private Button _buttonBack;

    private void Start()
    {
        _buttonBack.onClick.AddListener(GoBack);
    }
    public override void SetActivate(bool value, params object[] parameters)
    {
        base.SetActivate(value, parameters);
    }

    private void GoBack()
    {
        PageController.SwitchPageBack();
        _enviromentController.SwitchEnviromentBack();
    }
}
