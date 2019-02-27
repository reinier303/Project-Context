using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshGamepads : MonoBehaviour
{
    // Normal unity update
    void Update()
    {
        GamepadManager.Instance.Refresh();
    }
}
