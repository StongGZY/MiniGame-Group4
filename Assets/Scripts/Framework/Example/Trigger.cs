using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.LoadUI(typeof(FirstPageLogic));
    }
}
