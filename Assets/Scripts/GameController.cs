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

    [Header("Menu03")]
    [SerializeField] TMP_InputField menu_03_input;
    [SerializeField] TMP_Text menu_03_resultText;

    [Header("Menu04")]
    [SerializeField] TMP_InputField menu_04_input_n;
    [SerializeField] TMP_InputField menu_04_input_m;
    [SerializeField] TMP_Text menu_04_resultText;
    private void Start() {
        helper = GetComponent<CrazyMathHelper>();
    }

    private void Update() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

    public void Menu_01_ClearField() {
        menu_01_input.text = string.Empty;
    }

    public void Menu_01_Enter() {
        if (string.IsNullOrWhiteSpace(menu_01_input.text)) {
            menu_01_resultText.text = "Incorrect input";
            return;
        }
        bool isPalindrome = helper.GetIsPalindrome(menu_01_input.text.Replace(" ", "").ToLower());
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
        string result = menu_02_input.text.ToLower().Replace(menu_02_input_substring.text.ToLower(), menu_02_input_new_substring.text.ToLower());
        menu_02_resultText.text = result;
    }

    public void Menu_03_ClearField() {
        menu_03_input.text = string.Empty;
        menu_03_resultText.text = string.Empty;
    }

    public void Menu_03_Enter() {
        if (string.IsNullOrWhiteSpace(menu_03_input.text)) {
            menu_03_resultText.text = "Incorrect input";
            return;
        }
        if (int.TryParse(menu_03_input.text, out int n)) {
            List<int> array = helper.GetRandomSortedArray(n);
            menu_03_resultText.text = $"result: {string.Join(", ", array)}";
            if (array.Count > 400) {
                menu_03_resultText.fontSize = 8;
            } else if (array.Count > 30) {
                menu_03_resultText.fontSize = 24;
            } else {
                menu_03_resultText.fontSize = 72;
            }
        }
    }

    public void Menu_04_ClearField() {
        menu_04_input_n.text = string.Empty;
        menu_04_input_m.text = string.Empty;
        menu_04_resultText.text = string.Empty;
    }

    public void Menu_04_Enter() {
        if (string.IsNullOrWhiteSpace(menu_04_input_n.text) || string.IsNullOrWhiteSpace(menu_04_input_m.text)) {
            menu_04_resultText.text = "Incorrect input";
            return;
        }
        if (int.TryParse(menu_04_input_n.text, out int n)) {
            if (int.TryParse(menu_04_input_m.text, out int m)) {
                (int[,] startArray, int[,] resultArray) = helper.GetRandomSorted2dArray(n, m);
                menu_04_resultText.text = "Start array:\n";
                Show2dArray(startArray);
                menu_04_resultText.text += "\nSorted array:\n";
                Show2dArray(resultArray);
            }
        }
    }

    void Show2dArray(int[,] array) {
        for (int i = 0; i < array.GetLength(0); i++) {
            for (int j = 0; j < array.GetLength(1); j++) {
                if (array[i, j] <= -100) {
                    menu_04_resultText.text += $"{array[i, j]} ";
                } else if (array[i, j] <= -10 || array[i, j] >= 100) {
                    menu_04_resultText.text += $" {array[i, j]} ";
                } else if (array[i, j] <= -1 || array[i, j] >= 10) {
                    menu_04_resultText.text += $"  {array[i, j]} ";
                } else if (array[i, j] < 10) {
                    menu_04_resultText.text += $"   {array[i, j]} ";
                }
            }
            menu_04_resultText.text += '\n';
        }
    }
}
