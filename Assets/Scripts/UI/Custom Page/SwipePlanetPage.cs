using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipePlanetPage : PageUI
{
    [SerializeField] private EnviromentController _enviromentController;
    [SerializeField] private Button _buttonRobotEvolution;

    private void Start()
    {
        _buttonRobotEvolution.onClick.AddListener(GoToRobotEvolution);
    }

    public override void SetActivate(bool value, params object[] parameters)
    {
        base.SetActivate(value, parameters);
    }

    private void GoToRobotEvolution()
    {
        PageController.SwitchPageOn<RobotEvolutionPage>();
        _enviromentController.SwitchEnviromentOn<RobotEvolutionEnviroment>();
    }
}
