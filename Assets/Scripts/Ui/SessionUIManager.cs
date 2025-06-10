using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SessionUiManager : MonoBehaviour
{
    public TMP_Text sessionNameDisplay;
    public Button joinButton;

    private SessionInfo sessionInfo;

    public void SetInformation(SessionInfo info)
    {
        sessionInfo = info;
        sessionNameDisplay.text = sessionInfo.Name;
        joinButton.interactable = sessionInfo.PlayerCount < sessionInfo.MaxPlayers;

        joinButton.onClick.RemoveAllListeners();
        joinButton.onClick.AddListener(() => JoinSession());
    }

    private void JoinSession()
    {
        Debug.Log($"Joining session: {sessionInfo.Name}");

        // Call your NetworkManager here to join (e.g., use a singleton, event, or reference)
        FindObjectOfType<NetworkManager>().JoinLobby(sessionInfo.Name);
    }
}
