using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleData
{
    private static bool isSecondSubPage = false;

    public static bool IsSecondSubPage
    {
        get => isSecondSubPage;
        set
        {
            isSecondSubPage = value;
            GlobalEventManager.OnExampleButtonClick(isSecondSubPage);
        }
    }
}
