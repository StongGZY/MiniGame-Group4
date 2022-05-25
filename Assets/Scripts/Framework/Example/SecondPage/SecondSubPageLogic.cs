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

    private void OnClick()
    {
        ExampleData.IsSecondSubPage = false;
    }
}
