using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPageLogic : LogicBase
{
    private SecondPageCtrl ctrl;

    private FirstSubPageLogic firstSubPageLogic;

    private SecondSubPageLogic secondSubPageLogic;

    public SecondPageLogic() : base(UIName.SecondPage)
    {
    }

    protected override void OnLoad()
    {
        base.OnLoad();
        ctrl = Ctrl as SecondPageCtrl;

        GlobalEventManager.OnExampleButtonClickEvent += OnExampleButtonClick;

        firstSubPageLogic = new FirstSubPageLogic(ctrl.FirstSubPageCtrl);
        secondSubPageLogic = new SecondSubPageLogic(ctrl.SecondSubPageCtrl);

        ctrl.FirstSubPageCtrl.gameObject.SetActive(!ExampleData.IsSecondSubPage);
        ctrl.SecondSubPageCtrl.gameObject.SetActive(ExampleData.IsSecondSubPage);
    }

    protected override void Dispose()
    {
        base.Dispose();
        firstSubPageLogic.Dispose();
        secondSubPageLogic.Dispose();

        GlobalEventManager.OnExampleButtonClickEvent -= OnExampleButtonClick;
    }

    private void OnExampleButtonClick(bool flag)
    {
        ctrl.FirstSubPageCtrl.gameObject.SetActive(!flag);
        ctrl.SecondSubPageCtrl.gameObject.SetActive(flag);
    }
}
