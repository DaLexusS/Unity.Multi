using UnityEngine;
using UnityEditor.UI;
using Fusion;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class SessionListUiHandler : MonoBehaviour
{
    public static UnityAction<string> onLobbyCreated;

    public TextMeshProUGUI statusText;

    public GameObject sessionItemListPrefab;
    public GameObject sessionList;
    public GameObject LobbyList;

    public VerticalLayoutGroup verticalLayoutGroup;

    private string _lastLobbyName;

    private void OnEnable()
    {
        NetworkManager.onJoinedLobby += DisableLobbyList;
    }

    private void OnDisable()
    {
        NetworkManager.onJoinedLobby -= DisableLobbyList;
    }
    public void ClearList()
    {
        foreach (Transform child in verticalLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }

        statusText.gameObject.SetActive(false);
    }

    public void UpdateName(string lobbyName)
    {
        _lastLobbyName = lobbyName;
    }

    private void DisableLobbyList()
    {
        LobbyList.SetActive(false);
        sessionItemListPrefab.SetActive(true);
    }

    public void AddToList(SessionInfo sessionInfo)
    {
        SessionInfoListUiItem addedSessionItem = Instantiate(sessionItemListPrefab, verticalLayoutGroup.transform).GetComponent<SessionInfoListUiItem>();

        addedSessionItem.SetInformation(sessionInfo);
    }




    public void OnNoSessionFound()
    {
        statusText.text = "No game session found.";
        statusText.gameObject.SetActive(true);
    }
}
