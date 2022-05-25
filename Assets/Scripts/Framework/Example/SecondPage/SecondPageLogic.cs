using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPageLogic : LogicBase
{
    private SecondPageCtrl ctrl;

    private FirstSubPageLogic firstSubPageScreen;

    private SecondSubPageLogic secondSubPageScreen;

    public SecondPageLogic() : base(UIName.SecondPage)
    {
    }

    protected override void OnLoad()
    {
        base.OnLoad();
        ctrl = Ctrl as SecondPageCtrl;

        GlobalEventManager.OnExampleButtonClickEvent += OnExampleButtonClick;

        firstSubPageScreen = new FirstSubPageLogic(ctrl.FirstSubPageCtrl);
        secondSubPageScreen = new SecondSubPageLogic(ctrl.SecondSubPageCtrl);

        ctrl.FirstSubPageCtrl.gameObject.SetActive(!ExampleData.IsSecondSubPage);
        ctrl.SecondSubPageCtrl.gameObject.SetActive(ExampleData.IsSecondSubPage);
    }

    protected override void Dispose()
    {
        base.Dispose();
        firstSubPageScreen.Dispose();
        secondSubPageScreen.Dispose();

        GlobalEventManager.OnExampleButtonClickEvent -= OnExampleButtonClick;
    }

    private void OnExampleButtonClick(bool flag)
    {
        ctrl.FirstSubPageCtrl.gameObject.SetActive(!flag);
        ctrl.SecondSubPageCtrl.gameObject.SetActive(flag);
    }
}
