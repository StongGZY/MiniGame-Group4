using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPageLogic : LogicBase
{
    private FirstPageCtrl ctrl;

    public FirstPageLogic() : base(UIName.FirstPage)
    {
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        ctrl = Ctrl as FirstPageCtrl;
        ctrl.ClickButton.onClick.AddListener(OnButtonClick);
    }

    protected override void Dispose()
    {
        base.Dispose();

        ctrl.ClickButton.onClick.RemoveAllListeners();
    }

    private void OnButtonClick()
    {
        UIManager.Instance.LoadUI(typeof(SecondPageLogic));
        UIManager.Instance.CloseUI(typeof(FirstPageLogic));
    }
}
