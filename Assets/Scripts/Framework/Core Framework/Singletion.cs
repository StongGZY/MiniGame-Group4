using UnityEngine;

// ! 单例类的基类, 类型参数必须是 Component
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance; // 静态单例

    /// <summary>
    /// 获取单例<br/>
    /// 如果挂载单例组件的 GameObject 不存在，构建一个挂载了该 Component 的 GameObject, 并返回新创建的单例<br/>
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            string objectName = typeof(T).Name;
            GameObject gObject = GameObject.Find(objectName); // 场景中 GameObject 名字应当与类名相匹配

            if (gObject != null) // 若场景中已经存在挂载了该脚本的 gameObject
                _instance = gObject.GetComponent<T>(); // 实例等于场景中已挂载好的组件
            else
            {
                gObject = new GameObject(objectName);
                GameObject gameRoot = GameObject.Find("GameRoot"); // 挂载到 GameRoot 下
                if (gameRoot == null)
                    gameRoot = new GameObject("GameRoot");

                // DontDestroyOnLoad(gameRoot);
                gObject.transform.SetParent(gameRoot.transform);
                _instance = gObject.AddComponent<T>();        // 此时由于 AddComponent<T>() 导致的脚本初始化,
                                                              // 程序会跳转到 Awake 处执行初始化
            }

            return _instance;
        }
        private set => _instance = value;
    }

    /// <summary>
    /// Unity 自动调用, 执行初始化, 可由子类重写
    /// </summary>
    protected virtual void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        Init();
    }

    /// <summary>
    /// 挂载脚本的 GameObject 销毁时自动调用, 确保静态单例的销毁
    /// </summary>
    protected virtual void OnDestroy()
    {
        if (_instance != null) // && _instance.gameObject == gameObject)
            _instance = null;
    }

    /// <summary>
    /// 初始化, 由子类重写
    /// </summary>
    protected virtual void Init()
    {

    }
}