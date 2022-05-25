using UnityEngine;

// ! 处理子 UI 逻辑, 所有子 UI 都需要继承自 SubLogicBase
public class SubLogicBase
{
    public SubCtrlBase SubCtrl { get; private set; }

    public SubLogicBase(SubCtrlBase subCtrl)
    {
        SubCtrl = subCtrl;
        Init();
    }

    protected virtual void Init()
    {

    }

    public virtual void Dispose()
    {

    }
}