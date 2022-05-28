using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ! 管理所有 UI
public class UIManager : Singleton<UIManager>
{
    private static Dictionary<Type, LogicBase> uiPages = new Dictionary<Type, LogicBase>(); // UI 字典

    public GameObject UIRoot { get; private set; } // UI Root, 用于挂载 UI, UI 相机, Canvas

    public Canvas UICanvas { get; private set; } // UI Canvas

    protected override void Init()
    {
        UIRoot = GameObject.Instantiate(ResourcesManager.Instance.LoadUIPrefab("UIRoot"), transform); // 初始化 UI Root
        UICanvas = UIRoot.GetComponent<Canvas>();
        UICanvas.planeDistance = 100.0f;
    }

    /// <summary>
    /// 获取 UIRoot Transform，主要用于设置父节点
    /// </summary>
    /// <returns>UIRoot Transform</returns>
    public Transform GetUIRootTransform()
    {
        return UIRoot.transform;
    }

    /// <summary>
    /// 获取指定 UI
    /// </summary>
    public LogicBase GetUI(Type type)
    {
        if (!typeof(LogicBase).IsAssignableFrom(type)) // 判断 ScreeBase 是否是 type 的父类, 如果不是则返回 null
            return null;

        LogicBase logicBase = null;

        if (uiPages.TryGetValue(type, out logicBase)) // 检查 UI 字典中是否有该 UI, 如有则返回该 UI
            return logicBase;

        return null;
    }

    /// <summary>
    /// 启用指定 UI<br/>
    /// 如 UI 不存在则创建该 UI
    /// </summary>
    /// <returns>UI</returns>
	public LogicBase LoadUI(Type type)
    {
        LogicBase logicBase = GetUI(type);

        if (logicBase != null) // UI 存在则返回 UI
        {
            // if (logicBase.Ctrl != null && !logicBase.Ctrl.ctrlCanvas.enabled) // 忽略
            //     logicBase.Ctrl.ctrlCanvas.enabled = true;
            return logicBase;
        }

        logicBase = (LogicBase)Activator.CreateInstance(type); // ! UI 不存在时使用 CreateInstance() 创建 type 类型的实例, 会执行相应类型的构造函数
        AddUI(logicBase);                                       // 并添加至 UI Manager 管理

        return logicBase;
    }

    /// <summary>
    /// 关闭指定 UI
    /// </summary>
    /// <returns>false if there is no such UI.</returns>
    public bool CloseUI(Type type)
    {
        LogicBase logicBase = GetUI(type);

        if (logicBase != null) // 如 UI 存在, 则调用 UI 的 OnClose(), UI 关闭的逻辑由其自己实现
        {
            RemoveUI(type); // 默认关闭时删除该 UI
            logicBase.OnClose();
            return true;
        }

        return false;
    }

    /// <summary>
    /// UI 创建时候自动调用, 已集成, 勿手动调用
    /// </summary>
    private void AddUI(LogicBase logicBase)
    {
        uiPages.Add(logicBase.GetType(), logicBase); // 添加到字典中
        logicBase.currentUIRoot.transform.SetParent(GetUIRootTransform());

        logicBase.currentUIRoot.transform.localPosition = Vector3.zero;
        logicBase.currentUIRoot.transform.localScale = Vector3.one;
        logicBase.currentUIRoot.transform.localRotation = Quaternion.identity;
        // logicBase.currentUIRoot.name = logicBase.currentUIRoot.name.Replace("(Clone)", ""); // optional
    }

    /// <summary>
    /// UI 关闭时自动调用, LogicBase 中已集成, 勿手动调用
    /// </summary>
    private void RemoveUI(Type logicBase)
    {
        if (uiPages.ContainsKey(logicBase))  // 根据具体需求决定到底是直接销毁还是缓存
            uiPages.Remove(logicBase);
    }
}

// /// <summary>
// /// 关闭所有 UI<br/>
// /// </summary>
// public void CloseAllUI()
// {
//     List<Type> keys = new List<Type>(uiPages.Keys);
//     foreach (var k in keys)
//     {
//         if (k == typeof(LogicBase))
//         {
//             continue;
//         }
//         if (uiPages.ContainsKey(k))
//             uiPages[k].OnClose();
//     }
// }