#if UNITY_EDITOR
using UnityEditor;
using System.Linq;

/// <summary>
/// Detects the presence of the Discord Social SDK and adds the DISCORD_SOCIAL_SDK_EXISTS define symbol if it is present.
/// Without this all of the code using the Discord Social SDK will not compile and Unity will start with errors in safe mode.
/// 
/// In your own game you can safely remove this file once the Discord Social SDK package is installed.
/// </summary>
[InitializeOnLoad]
public class DiscordSocialSDKDetector
{
    static DiscordSocialSDKDetector()
    {
        var discordSocialSDKExists = System.AppDomain.CurrentDomain.GetAssemblies()
            .Any(a => a.GetName().Name == "Discord.Sdk");
            
        var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        var definesList = defines.Split(';').ToList();
        
        if (discordSocialSDKExists && !definesList.Contains("DISCORD_SOCIAL_SDK_EXISTS"))
        {
            definesList.Add("DISCORD_SOCIAL_SDK_EXISTS");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, string.Join(";", definesList));
        }
        else if (!discordSocialSDKExists && definesList.Contains("DISCORD_SOCIAL_SDK_EXISTS"))
        {
            definesList.Remove("DISCORD_SOCIAL_SDK_EXISTS");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, string.Join(";", definesList));
        }
    }
}
#endif