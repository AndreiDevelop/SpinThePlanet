using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageController : PageUIController
{
    private void Start()
    {
        SwitchPageOn<SwipePlanetPage>();
    }
}
