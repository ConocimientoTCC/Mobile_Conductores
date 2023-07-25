using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.PackageManager;

public class PlayFabManager : MonoBehaviour
{
    private static PlayFabManager instance;
    public Master_Start masterStart;
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
    public TMP_Text alertText;
    public TMP_Text alertTitleText;
    public Image alertImage;
    public Button alertBtn;
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
        if(masterStart == null)
        {
            FindObjectOfType<Master_Start>();
        }
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInputLogin.text,
            Password = passwordInputLogin.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucess, OnError);
        
    }

    public void RegisterButton()
    {
        if(passwordInput.text.Length < 6)
        {
            OnErrorPasswordLength();
            return;
        }
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
        alertPanel.SetActive(true);
        alertTitleText.text = "¡Ingreso exitoso!";
        alertText.text = "Bienvenido de vuelta <b>" + result.InfoResultPayload.PlayerProfile.DisplayName + "</b>, nos alegra verte.";
        alertImage.sprite = Resources.Load<Sprite>("images/alertsCheck");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseAlertPanel(); });
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        loggedInPlayfabId = result.PlayFabId;
        alertPanel.SetActive(true);
        alertTitleText.text = "¡Registro exitoso!";
        alertText.text = "¡Perfecto! Has creado tu cuenta, recuerda que desde el panel de ingreso puedes recuperar tu contraseña en caso de que lo necesites.";
        alertImage.sprite = Resources.Load<Sprite>("images/alertsCheck");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseAlertPanel(); });
        
    }

    public void ResetPasswordButton()
    {

    }

    void OnSuccess(LoginResult result)
    {
        //Debug.Log("YES");
        
    }
    
    void OnError(PlayFabError error)
    {
        if(error.ErrorMessage == "The display name entered is not available.")
        {
            alertTitleText.text = "Error interno: nombre en uso";
            alertText.text = "Por favor utiliza tu segundo apellido, en caso de que vuelvas a ver este mensaje, agrega cualquier letra a tu nombre.";
        }
        else
        {
            alertTitleText.text = "Ups...";
            alertText.text = "Asegúrate de haber llenado todos los campos correctamente.";
        }
        Debug.Log(error.ErrorMessage);
        Debug.Log(error.GenerateErrorReport());
        alertPanel.SetActive(true);
        
        alertImage.sprite = Resources.Load<Sprite>("images/alerts_Wrong");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseOnlyAlert(); });
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

    void OnErrorPasswordLength()
    {
        alertPanel.SetActive(true);
        alertTitleText.text = "Contraseña muy corta";
        alertText.text = "Tu contraseña debe contener mínimo 6 caracteres.";
        alertImage.sprite = Resources.Load<Sprite>("images/alertsCheck");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseOnlyAlert(); });
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("melo");
        
    }
}
