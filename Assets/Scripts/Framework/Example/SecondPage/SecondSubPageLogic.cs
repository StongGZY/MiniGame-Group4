using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSubPageLogic : SubLogicBase
{
    private SecondSubPageCtrl subCtrl;

    public SecondSubPageLogic(SubCtrlBase ctrlBase) : base(ctrlBase)
    {
        base.Init();
        subCtrl = SubCtrl as SecondSubPageCtrl;
        subCtrl.ClickButton.onClick.AddListener(OnClick);
    }

    protected override void Init()
    {
        base.Init();

        subCtrl = SubCtrl as SecondSubPageCtrl;
    }

    public override void Dispose()
    {
        subCtrl.ClickButton.onClick.RemoveAllListeners();
        base.Dispose();
    }

    private void OnClick()
    {
        ExampleData.IsSecondSubPage = false;
    }
}
