using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#if DISCORD_SOCIAL_SDK_EXISTS
using Discord.Sdk;
#endif


/// <summary>
/// ConnectButton handles the connection to Discord when the user clicks the connect button.
/// It uses the DiscordManager to start the OAuth flow.
/// </summary>
public class ConnectButton : MonoBehaviour
{
    [SerializeField] private Button connectButton;

#if DISCORD_SOCIAL_SDK_EXISTS
    void Start()
    {
        if (connectButton == null)
        {
            Debug.LogError("Connect to Discord button reference is missing, add a button in your scene and attach the ConnectButton script to it. Without it the OAuth flow cannot be started.");
            return;
        }

        if (DiscordManager.Instance == null)
        {
            Debug.LogError("There is no DiscordManager instance in the scene. The DiscordManager handles the connection to Discord through the Social SDK. There is a prefab for the DiscordManager in the prefabs folder that you can drop into the scene.");
            return;
        }

        if (GetComponentInParent<Canvas>() == null)
        {
            Debug.LogError($"The ConnectButton must be placed inside a Canvas.");
        }

        if (EventSystem.current == null)
        {
            Debug.LogError("No EventSystem found! Add one to the scene for UI interactions to work properly. Click Game Object > UI > EventSystem to add one to the scene.");
        }

        connectButton.onClick.AddListener(OnConnectButtonClicked);
        DiscordManager.Instance.OnDiscordStatusChanged += OnStatusChanged;
    }

    private void OnConnectButtonClicked()
    {
        if (DiscordManager.Instance == null)
        {
            Debug.LogError("There is no DiscordManager instance in the scene. The DiscordManager handles the connection to Discord through the Social SDK. There is a prefab for the DiscordManager in the prefabs folder that you can drop into the scene.");
            return;
        }

        DiscordManager.Instance.StartOAuthFlow();
    }

    private void OnStatusChanged(Client.Status status, Client.Error error, int errorCode)
    {
        if (status == Client.Status.Ready)
        {
            gameObject.SetActive(false);
        }
    }
#endif
}
