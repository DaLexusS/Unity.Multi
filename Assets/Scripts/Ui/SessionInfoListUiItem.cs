using UnityEngine;
using UnityEditor.UI;
using TMPro;
using UnityEngine.UI;
using Fusion;
using System;

public class SessionInfoListUiItem : MonoBehaviour
{
    public TextMeshProUGUI sessionNameText;
    public TextMeshProUGUI sessionCountText;
    public Button joinButton;

    SessionInfo sessionInfo;

    public event Action<SessionInfo> onJoinSession;

    public void SetInformation(SessionInfo sessionInfo)
    {
        this.sessionInfo = sessionInfo;

        sessionNameText.text = sessionInfo.Name;
        sessionCountText.text = $"{sessionInfo.PlayerCount}/{sessionInfo.MaxPlayers}";

        bool isJoinButtonActive = true;

        if (sessionInfo.PlayerCount >= sessionInfo.MaxPlayers)
        {
            isJoinButtonActive = false;
        }

        joinButton.gameObject.SetActive(isJoinButtonActive);
    }

    public void OnClick()
    {
        onJoinSession.Invoke(sessionInfo);
    }
}
