using UnityEngine;

[CreateAssetMenu(fileName = "DiscordSocialSDKConfig", menuName = "Config/Discord Social SDK")]
public class DiscordSocialSDKConfig : ScriptableObject
{
    [SerializeField] private ulong applicationId;

    public ulong ApplicationId => applicationId;
}
