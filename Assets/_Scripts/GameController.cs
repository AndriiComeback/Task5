using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    CrazyMathHelper helper;

    [Header("Menu01")]
    [SerializeField] TMP_InputField menu_01_input;
    [SerializeField] TMP_Text menu_01_resultText;

    [Header("Menu02")]
    [SerializeField] TMP_InputField menu_02_input;
    [SerializeField] TMP_InputField menu_02_input_substring;
    [SerializeField] TMP_InputField menu_02_input_new_substring;
    [SerializeField] TMP_Text menu_02_resultText;
    private void Start() {
        helper = GetComponent<CrazyMathHelper>();
    }

    public void Menu_01_ClearField() {
        menu_01_input.text = string.Empty;
    }

    public void Menu_01_Enter() {
        if (string.IsNullOrWhiteSpace(menu_01_input.text)) {
            menu_01_resultText.text = "Incorrect input";
            return;
        }
        bool isPalindrome = helper.GetIsPalindrome(menu_01_input.text);
        if (isPalindrome) {
            menu_01_resultText.text = "It is palindrome.";
        } else {
            menu_01_resultText.text = "It is not palindrome.";
        }
    }

    public void Menu_02_ClearFields() {
        menu_02_input.text = string.Empty;
        menu_02_input_substring.text = string.Empty;
        menu_02_input_new_substring.text = string.Empty;
        menu_02_resultText.text = string.Empty;
    }

    public void Menu_02_Enter() {
        if (string.IsNullOrWhiteSpace(menu_02_input.text) || 
            string.IsNullOrWhiteSpace(menu_02_input_substring.text) || 
            string.IsNullOrWhiteSpace(menu_02_input_new_substring.text)) {
            menu_02_resultText.text = "Incorrect input";
            return;
        }
        string result = menu_02_input.text.Replace(menu_02_input_substring.text, menu_02_input_new_substring.text);
        menu_02_resultText.text = result;
    }
}
