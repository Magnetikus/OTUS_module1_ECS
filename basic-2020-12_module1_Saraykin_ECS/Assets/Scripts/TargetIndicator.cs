using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public GameObject value;

    private void Awake()
    {
        value.SetActive(false);
    }
}
