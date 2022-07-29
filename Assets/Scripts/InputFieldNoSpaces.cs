using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldNoSpaces : MonoBehaviour
{
    TMPro.TMP_InputField inputField;
    void Start() {
        inputField = GetComponent<TMPro.TMP_InputField>();
    }

    public void Validate() {
        if (inputField != null) {
            if (inputField.text.Length < 1) {
                return;
            }
            var lastCharacter = inputField.text[inputField.text.Length - 1];
            if (lastCharacter == ' ') {
                inputField.text = inputField.text.Remove(inputField.text.Length - 1);
            }
        }
    }
}
