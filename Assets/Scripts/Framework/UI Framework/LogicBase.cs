using UnityEngine;

// ! 处理 UI 逻辑, 所有 UIScreen类 必须继承自 LogicBase, 如果 UI 有子 UI, 子 UI 根节点需要继承自 SubScreenBase
public class LogicBase
{
    public GameObject currentUIRoot = null; // 当前 UI 的根节点

    public string currentUIName = ""; // 当前 UI 的名字

    public CtrlBase Ctrl { get; private set; } // 当前 UI 的控制器 controller

    /// <summary>
    /// 构造时加载 UI, 该方法会在 UIManager.OpenUI() 中被 CreateInstance 调用
    /// </summary>
    public LogicBase(string UIName)
    {
        currentUIName = UIName;
        GameObject uiPrefab = ResourcesManager.Instance.LoadUIPrefab(currentUIName);               // 加载 UI Prefab
        currentUIRoot = GameObject.Instantiate(uiPrefab, UIManager.Instance.GetUIRootTransform()); // 实例化 UI
        Ctrl = currentUIRoot.GetComponent<CtrlBase>();                                             // 获取 controller, controller 必须绑定在指定 UI 的根节点中
        OnLoad();                                                                                  // 加载并实例化完成 后执行, 由子类重写
    }

    /// <summary>
    /// 初始化操作, 可重写
    /// </summary>
    protected virtual void OnLoad()
    {
        Debug.Log($"UI Prefab loaded successfully: {this.GetType().ToString()}"); // optional
    }

    /// <summary>
    /// 关闭 UI 时执行的操作。关闭 UI 时 UIManager 会调用, 可重写
    /// </summary>
    public virtual void OnClose()
    {
        Dispose();
    }

    /// <summary>
    /// 释放 UI 所占的资源
    /// </summary>
    protected virtual void Dispose()
    {
        GameObject.Destroy(currentUIRoot);
    }
}

// TODO:
// // 更新UI的层级
// private void UpdateLayoutLevel()
// {
//     var camera = UIManager.Instance.GetUICamera();
//     if (camera != null)
//     {
//         CtrlBase.ctrlCanvas.worldCamera = camera;
//     }

//     CtrlBase.ctrlCanvas.pixelPerfect = true;
// }