using System;

public static class GlobalEventManager
{
    /* define event and eventTrigger as below:
     * 1. no return value, one boolean argument
     * public static event Action<bool> OnSomethingHappenEvent; // event
     * public static void OnSomethingHappen(bool flag) { OnSomethingHappenEvent(flag); } // eventTrigger
     *
     * 2. no return value, no argument
     * public static event Action OnSomethingHappenEvent; // event
     * public static void OnSomethingHappen() { OnSomethingHappenEvent(); } // eventTrigger
     *
     * 3. return int value, one float argument
     * public static event Func<int, float> OnSomethingHappenEvent;
     * public static void OnSomethingHappen(float a) { OnSomethingHappenEvent(a); } // eventTrigger
     *
     * 4. return int value, no argument
     * public static event Func<int> OnSomethingHappenEvent;
     * public static void OnSomethingHappen() { OnSomethingHappenEvent(); } // eventTrigger
     *
     * 5. multi argument
     * public static event Func<int, float, double, int, bool> OnSomethingHappenEvent;
     * public static void OnSomethingHappen(float a, double b, int c, bool d) { OnSomethingHappenEvent(a, b, c, d); } // eventTrigger
     */

    public static Action<bool> OnExampleButtonClickEvent;
    public static void OnExampleButtonClick(bool flag) { OnExampleButtonClickEvent(flag); }
}
