using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyMathHelper : MonoBehaviour
{
    public bool GetIsPalindrome(string text) {
        if (string.IsNullOrWhiteSpace(text)) {
            return false;
        }
        if (text.Length == 1) {
            return true;
        }
        bool isPalindrome = true;
        for (int i = 0, j = text.Length - 1; i < j; i++, j--) {
            if (text[i] != text[j]) {
                isPalindrome = false;
                break;
            }
        }
        return isPalindrome;
    }
}
