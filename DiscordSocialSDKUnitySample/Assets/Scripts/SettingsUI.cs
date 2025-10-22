using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    public GameObject friendsList;
    public GameObject settingsPanel;
    public GameObject connectToDiscordPanel;
    public GameObject accountLinkedPanel;

    public void openSettings()
    {
        settingsPanel.SetActive(true);
        Debug.Log("Settings panel opened!");
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenDiscord()
    {
        string discordUrl = "https://discord.gg/discord-developers";
        Application.OpenURL(discordUrl);
    }

    public void OpenConnectToDiscord()
    {
        settingsPanel.SetActive(false);
        connectToDiscordPanel.SetActive(true);
    }

    public void CancelConnectToDiscord()
    {
        connectToDiscordPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void StartAuthFlow()
    {

    }

    public void ShowAccountLinked()
    {
        connectToDiscordPanel.SetActive(false);
        settingsPanel.SetActive(false);
        accountLinkedPanel.SetActive(true);
    }
    
    public void FinishAccountLinked()
    {
        connectToDiscordPanel.SetActive(false);
        settingsPanel.SetActive(false);
        accountLinkedPanel.SetActive(false);
    }
}
