using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Gamepad Manager class
public class GamepadManager : MonoBehaviour
{
    public int GamepadCount = 4; // Number of gamepads to support

    private List<X360_Gamepad> gamepads;     // Holds gamepad instances

    public static GamepadManager Instance; // Singleton instance

    // Initialize on 'Awake'
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        // Lock GamepadCount to supported range
        GamepadCount = Mathf.Clamp(GamepadCount, 1, 4);

        gamepads = new List<X360_Gamepad>();

        // Create specified number of gamepad instances
        for (int i = 0; i < GamepadCount; ++i)
        {
            gamepads.Add(new X360_Gamepad(i + 1));
        }
    }

    // Normal unity update
    void Update()
    {
        for (int i = 0; i < gamepads.Count; ++i)
            gamepads[i].Update();
    }

    // Refresh gamepad states for next update
    public void Refresh()
    {
        for (int i = 0; i < gamepads.Count; ++i)
            gamepads[i].Refresh();
    }

    // Return specified gamepad
    // (Pass index of desired gamepad, eg. 1)
    public X360_Gamepad GetGamepad(int index)
    {
        for (int i = 0; i < gamepads.Count;)
        {
            // Indexes match, return this gamepad
            if (gamepads[i].Index == (index - 1))
                return gamepads[i];
            else
                ++i;
        }

        Debug.LogError("[GamepadManager]: " + index + " is not a valid gamepad index!");

        return null;
    }

    // Return number of connected gamepads
    public int ConnectedTotal()
    {
        int total = 0;

        for (int i = 0; i < gamepads.Count; ++i)
        {
            if (gamepads[i].IsConnected)
                total++;
        }

        return total;
    }

    public bool GetButtonAny(string button)
    {
        for (int i = 0; i < gamepads.Count; ++i)
        {
            // Gamepad meets both conditions
            if (gamepads[i].IsConnected && gamepads[i].GetButton(button))
                return true;
        }

        return false;
    }

    public bool GetButtonDownAny(string button)
    {
        for (int i = 0; i < gamepads.Count; ++i)
        {
            // Gamepad meets both conditions
            if (gamepads[i].IsConnected && gamepads[i].GetButtonDown(button))
                return true;
        }

        return false;
    }
}