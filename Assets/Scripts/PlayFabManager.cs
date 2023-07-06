using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayFabManager : MonoBehaviour
{
    private static PlayFabManager instance;
    [Header("UI Register")]
    public TMP_InputField cedulaInput;
    public TMP_InputField userNameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    [Header("UI Login")]
    public TMP_InputField emailInputLogin;
    public TMP_InputField passwordInputLogin;
    public string loggedInPlayfabId;

    [Header("PANELS")]
    public GameObject gamePanel;
    public GameObject alertPanel;
    public GameObject loginPanel;
    public GameObject registerPanel;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }

    }

    private void Update()
    {
        
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInputLogin.text,
            Password = passwordInputLogin.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucess, OnError);
    }

    public void RegisterButton()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = userNameInput.text,
            Username = cedulaInput.text,
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnLoginSucess(LoginResult result)
    {
        loggedInPlayfabId = result.PlayFabId;
        Debug.Log("Successful login");
        alertPanel.SetActive(true);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        loggedInPlayfabId = result.PlayFabId;
        alertPanel.SetActive(true);
    }

    public void ResetPasswordButton()
    {

    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("YES");
    }
    
    void OnError(PlayFabError error)
    {
        Debug.Log("NO");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Test",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("melo");
        
    }
}
