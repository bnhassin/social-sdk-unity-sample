using UnityEngine;

public class StartScreenUI : MonoBehaviour
{
    public GameObject friendsList;
    public SettingsUI settingsUI;

    public void OpenSettings()
    {
        settingsUI.openSettings();
    }
}
