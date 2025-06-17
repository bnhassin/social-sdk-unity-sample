using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class represents a section in the Friends List UI.
/// It manages the collapse/expand functionality and updates the friend count displayed in the section header.
/// Each section corresponds to a specific online status (e.g., In-Game, Online, Offline).
/// </summary>
public class FriendSectionUI : MonoBehaviour
{
    [SerializeField] private Button sectionHeader;
    [SerializeField] private GameObject friendContainer;
    [SerializeField] private Image collapseArrow;
    [SerializeField] private TMP_Text friendCountText;
    [SerializeField] private string sectionName;

    private bool isCollapsed = false;

    void Start()
    {
        sectionHeader.onClick.AddListener(ToggleCollapse);
    }

    public void ToggleCollapse()
    {
        isCollapsed = !isCollapsed;
        friendContainer.SetActive(!isCollapsed);
        collapseArrow.transform.rotation = isCollapsed ? Quaternion.identity : Quaternion.Euler(0, 0, 180);
    }

    public void UpdateSectionFriendCount(int friendCount)
    {
        friendCountText.text = $"{sectionName}  •  {friendCount}";
    }
}
