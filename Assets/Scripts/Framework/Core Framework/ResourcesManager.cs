using System;
using UnityEngine;

// ! 资源管理
public class ResourcesManager : Singleton<ResourcesManager>
{
    public string UIPrefabPath = "Prefabs/UI/";

    /// <summary>
    /// 加载 UI Prefab
    /// </summary>
    /// <param name="uiName">UI名</param>
    public GameObject LoadUIPrefab(string uiName)
    {
        return Resources.Load<GameObject>(UIPrefabPath + uiName); // 仅负责加载 GameObject
    }
}