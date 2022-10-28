using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Bug there");
            Destroy(this);
            return;
        }
        Instance = this as T;
    }
}