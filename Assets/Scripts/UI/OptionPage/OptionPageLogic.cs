using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPageLogic : LogicBase
{
    private OptionPageCtrl ctrl;

    public OptionPageLogic() : base(UIName.OptionPage)
    {
        
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        ctrl = Ctrl as OptionPageCtrl;
        ctrl.ReturnButton.onClick.AddListener(OnReturnButtonClick);
        ctrl.QuickSaveButton.onClick.AddListener(OnQuickSaveButtonClick);
        ctrl.SaveButton.onClick.AddListener(OnSaveButtonClick);
        ctrl.LoadButton.onClick.AddListener(OnLoadButtonClick);
        ctrl.OptionButton.onClick.AddListener(OnOptionButtonClick);
        ctrl.ResignButton.onClick.AddListener(OnResignButtonClick);
        ctrl.RestartButton.onClick.AddListener(OnRestartButtonClick);
        ctrl.MenuButton.onClick.AddListener(OnMenuButtonClick);
        ctrl.DesktopButton.onClick.AddListener(OnDesktopButtonClick);
        
    }

    protected override void Dispose()
    {
        ctrl.ReturnButton.onClick.RemoveAllListeners();
        ctrl.QuickSaveButton.onClick.RemoveAllListeners();
        ctrl.SaveButton.onClick.RemoveAllListeners();
        ctrl.LoadButton.onClick.RemoveAllListeners();
        ctrl.OptionButton.onClick.RemoveAllListeners();
        ctrl.ResignButton.onClick.RemoveAllListeners();
        ctrl.RestartButton.onClick.RemoveAllListeners();
        ctrl.MenuButton.onClick.RemoveAllListeners();
        ctrl.DesktopButton.onClick.RemoveAllListeners();
        base.Dispose();
    }

    private void OnButtonClick()
    {
        UIManager.Instance.LoadUI(typeof(SecondPageLogic));
        UIManager.Instance.CloseUI(typeof(FirstPageLogic));
    }

    private void OnReturnButtonClick()
    {

    }

    private void OnQuickSaveButtonClick()
    {

    }

    private void OnSaveButtonClick()
    {

    }

    private void OnLoadButtonClick()
    {

    }

    private void OnOptionButtonClick()
    {

    }

    private void OnResignButtonClick()
    {

    }

    private void OnRestartButtonClick()
    {

    }

    private void OnMenuButtonClick()
    {

    }

    private void OnDesktopButtonClick()
    {

    }


}
