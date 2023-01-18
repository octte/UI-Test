using UnityEngine;

public static class ComponentHelper
{
    public static T GetOrAddComponent<T>(this Transform trans) where T : Component
    {
        var target = trans.GetComponent<T>();
        if (target == null)
        {
            target = trans.gameObject.AddComponent<T>();
        }

        return target;
    }
}