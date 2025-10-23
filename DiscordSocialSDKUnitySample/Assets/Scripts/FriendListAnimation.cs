using UnityEngine;

public class FriendListAnimation : MonoBehaviour
{
    public Animator animator;

    public void ShowFriendsList()
    {
        animator.SetTrigger("Open");
    }
}
