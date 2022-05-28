using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSubPageLogic : SubLogicBase
{
    private FirstSubPageCtrl subCtrl;

    public FirstSubPageLogic(SubCtrlBase ctrlBase) : base(ctrlBase)
    {
        base.Init();
        subCtrl = SubCtrl as FirstSubPageCtrl;
        subCtrl.ClickButton.onClick.AddListener(OnClick);
    }

    protected override void Init()
    {
        base.Init();

        subCtrl = SubCtrl as FirstSubPageCtrl;
    }

    public override void Dispose()
    {
        subCtrl.ClickButton.onClick.RemoveAllListeners();
        base.Dispose();
    }

    private void OnClick()
    {
        ExampleData.IsSecondSubPage = true;
    }
}
