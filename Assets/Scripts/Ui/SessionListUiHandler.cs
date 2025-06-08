using UnityEngine;
using UnityEditor.UI;
using Fusion;
using TMPro;
using UnityEngine.UI;

public class SessionListUiHandler : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    public GameObject sessionItemListPrefab;

    public VerticalLayoutGroup verticalLayoutGroup;

    public void ClearList()
    {
        foreach (Transform child in verticalLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }

        statusText.gameObject.SetActive(false);
    }

    public void AddToList(SessionInfo sessionInfo)
    {
        SessionInfoListUiItem addedSessionItem = Instantiate(sessionItemListPrefab, verticalLayoutGroup.transform).GetComponent<SessionInfoListUiItem>();

        addedSessionItem.SetInformation(sessionInfo);

        addedSessionItem.onJoinSession += AddedSessionItem_onJoinSession;
    }

    private void AddedSessionItem_onJoinSession(SessionInfo obj)
    {
        
    }

    public void OnNoSessionFound()
    {
        statusText.text = "No game session found.";
        statusText.gameObject.SetActive(true);
    }
}
