using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] NetworkRunner networkRunner;
    public static UnityAction onJoinedLobby;
    public static UnityAction<SessionInfo> onSessionCreated;
    public static UnityAction<string> onLocalPlayerJoined;

    [SerializeField] TMP_InputField playerInput;
    public SessionListUiHandler uiHandler;

    private void OnEnable()
    {
        LobbyItemHandler.onLobbyJoined += JoinLobby;
    }
    private void OnDisable()
    {
        LobbyItemHandler.onLobbyJoined -= JoinLobby;
    }

    private void Start()
    {
        networkRunner.AddCallbacks(this);
    }

    public async void JoinLobby(string lobbyName)
    {

        StartGameResult result = await networkRunner.JoinSessionLobby(SessionLobby.Custom, lobbyName);
        if (result.Ok)
        {
            onJoinedLobby.Invoke();
        }
        else
        {
            Debug.Log("couldn't connect the lobby");
        }
    }
    //public async void StartSession()
    //{

    //    StartGameResult resTask = await networkRunner.StartGame(new StartGameArgs()
    //    {
    //        GameMode = GameMode.Shared,
    //        SessionName = playerInput.text,
    //        PlayerCount = 4,
    //        OnGameStarted = OnGameStarted
    //    });
    //}

    public void OnGameStarted(NetworkRunner obj)
    {
        //onSessionCreated.Invoke(obj.SessionInfo);
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        onLocalPlayerJoined.Invoke(runner.SessionInfo.Name);
        Debug.Log(player.PlayerId);
    }

    void INetworkRunnerCallbacks.OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }

    void INetworkRunnerCallbacks.OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
    }

    void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
    }

    void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }

    void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    void INetworkRunnerCallbacks.OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
    }

    void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }

    void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }

    void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
    }

    void INetworkRunnerCallbacks.OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
    }

    void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
    {
    }

    void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner)
    {
       
    }

    void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        uiHandler.ClearList();

        // Add each session to UI
        foreach (var session in sessionList)
        {
            uiHandler.AddToList(session);
        }
    }

    void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner)
    {    }
}
