using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotkeyManager : MonoBehaviour
{
    public List<Button> hotkeyButtons;
    public Color normalColor;
    public Color pressedColor;
    public Color normalTextColor;
    public Color pressedTextColor;

    private KeyCode[] hotkeyCodes = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };

    private void Start()
    {
        InitializeButtonColors();
    }

    private void InitializeButtonColors()
    {
        for (int i = 0; i < hotkeyButtons.Count; i++)
        {
            Button button = hotkeyButtons[i];
            Text buttonText = button.GetComponentInChildren<Text>();

            // Store the initial normal text color
            normalTextColor = buttonText.color;

            // Set the initial colors
            SetButtonColors(button, normalColor, normalTextColor);
        }
    }

    private void Update()
    {
        for (int i = 0; i < hotkeyButtons.Count; i++)
        {
            if (Input.GetKeyDown(hotkeyCodes[i]))
            {
                PressHotkey(i, true);
            }
            else if (Input.GetKeyUp(hotkeyCodes[i]))
            {
                PressHotkey(i, false);
            }
        }
    }

    public void PressHotkey(int index, bool isPressed)
    {
        if (index < 0 || index >= hotkeyButtons.Count)
        {
            Debug.LogError("Invalid hotkey index");
            return;
        }

        Button button = hotkeyButtons[index];

        if (isPressed)
        {
            SetButtonColors(button, pressedColor, pressedTextColor);
        }
        else
        {
            SetButtonColors(button, normalColor, normalTextColor);
        }
    }

    private void SetButtonColors(Button button, Color backgroundColor, Color textColor)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = backgroundColor;
        button.colors = colors;

        Text buttonText = button.GetComponentInChildren<Text>();
        buttonText.color = textColor;
    }
}
