using UnityEngine;

public class ProcessView : MonoBehaviour
{
    public void Switch(bool flag)
    {
        gameObject.SetActive(flag);
    }
}