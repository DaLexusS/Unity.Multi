using Fusion;
using UnityEngine;

public class SessionListUiHandler : MonoBehaviour
{
    public GameObject sessionItemPrefab;
    public Transform sessionListContainer;

    public void ClearList()
    {
        foreach (Transform child in sessionListContainer)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddToList(SessionInfo sessionInfo)
    {
        GameObject item = Instantiate(sessionItemPrefab, sessionListContainer);
        SessionUiManager ui = item.GetComponent<SessionUiManager>();
        ui.SetInformation(sessionInfo);
    }
}
