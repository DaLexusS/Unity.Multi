using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SessionInfoListUiItem : MonoBehaviour
{
    public TMP_Text sessionNameText;
    public TMP_Text sessionCountText;
    public Button joinButton;

    private SessionInfo sessionInfo;

    public void SetInformation(SessionInfo sessionInfo)
    {
        this.sessionInfo = sessionInfo;

        sessionNameText.text = sessionInfo.Name;
        sessionCountText.text = $"{sessionInfo.PlayerCount}/{sessionInfo.MaxPlayers}";

        joinButton.interactable = sessionInfo.PlayerCount < sessionInfo.MaxPlayers;

        joinButton.onClick.RemoveAllListeners();
        joinButton.onClick.AddListener(() =>
        {
            JoinSession(sessionInfo.Name);
        });
    }

    private void JoinSession(string sessionName)
    {
        var runner = FindObjectOfType<NetworkRunner>();
        runner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.Shared,
            SessionName = sessionName,
            SceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>()
        });
    }
}
