using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImportExportPanel : MonoBehaviour {

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button copyButton;
    [SerializeField] private Button loadButton;

    public void SetUpImport() {
        // Clear Field
        inputField.text = "";
        inputField.readOnly = false;

        // Hide Copy Button
        copyButton.gameObject.SetActive(false);
        // Show Load Button
        loadButton.gameObject.SetActive(true);
        // Show Panel
        ShowPanel();
    }

    public void SetUpExport() {
        // Serialize Lines
        byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(DrawManager.instance.SerializeJson());
        string json = System.Convert.ToBase64String(plainTextBytes);
        // Populate TextArea with json
        inputField.text = json;

        inputField.readOnly = true;

        // Hide Load Button
        loadButton.gameObject.SetActive(false);
        // Show Copy Button
        copyButton.gameObject.SetActive(true);
        // Show Panel
        ShowPanel();

    }

    public void CopyText() {
        GUIUtility.systemCopyBuffer = inputField.text;
        Debug.Log("Text copied to clipboard: " + inputField.text);
    }

    public void LoadLines() {
        DrawManager.instance.ClearLines();
        byte[] base64EncodedBytes = System.Convert.FromBase64String(inputField.text);
        DrawManager.instance.DeserializeJson(System.Text.Encoding.UTF8.GetString(base64EncodedBytes));
    }

    private void ShowPanel() {
        gameObject.SetActive(true);
    }

    public void HidePanel() {
        gameObject.SetActive(false);
    }
}
