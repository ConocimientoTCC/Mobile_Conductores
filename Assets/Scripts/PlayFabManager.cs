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
    public Puntaje puntaje;
    public SoundManager soundManager;
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

        if(puntaje == null)
        {
            FindObjectOfType<Puntaje>();
        }
    }

    public void GetPlayerData()
    {

    }

    public void SavePlayerData(string puntajeXD)
    {
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Puntaje", puntajeXD},
                {"Insignia_Preoperacional", "EN POSESIÓN" }
            }
            
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Enviado correctamente");
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

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInputLogin.text,
            TitleId = "44FC9"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnResetError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        alertPanel.SetActive(true);
        alertTitleText.text = "¡Correo enviado!";
        alertText.text = "El enlace de recuperación de tu contraseña se ha enviado exitosamanete a <b>" + emailInputLogin.text + "</b>.";
        alertImage.sprite = Resources.Load<Sprite>("images/alertsCheck");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseOnlyAlert(); });
        soundManager.PlaySuccess1();
    }

    void OnLoginSucess(LoginResult result)
    {
        loggedInPlayfabId = result.PlayFabId;
        alertPanel.SetActive(true);
        alertTitleText.text = "¡Ingreso exitoso!";
        alertText.text = "Bienvenido de vuelta <b>" + result.InfoResultPayload.PlayerProfile.DisplayName + "</b>, nos alegra verte.";
        alertImage.sprite = Resources.Load<Sprite>("images/alertsCheck");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseAlertPanel(); });
        soundManager.PlaySuccess1();
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        loggedInPlayfabId = result.PlayFabId;
        alertPanel.SetActive(true);
        alertTitleText.text = "¡Registro exitoso!";
        alertText.text = "¡Perfecto! Has creado tu cuenta, recuerda que desde el panel de ingreso puedes recuperar tu contraseña en caso de que lo necesites.";
        alertImage.sprite = Resources.Load<Sprite>("images/alertsCheck");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseAlertPanel(); });
        soundManager.PlaySuccess1();

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
            alertText.text = "Asegúrate de haber llenado todos los campos correctamente. Además revisa tu conexión a Internet.";
        }
        Debug.Log(error.ErrorMessage);
        Debug.Log(error.GenerateErrorReport());
        alertPanel.SetActive(true);
        
        alertImage.sprite = Resources.Load<Sprite>("images/alerts_Wrong");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseOnlyAlert(); });
        soundManager.PlayError1();
    }

    void OnResetError(PlayFabError error)
    {
        alertTitleText.text = "Ups...";
        alertText.text = "Asegúrate de llenar correctamente el campo de Correo electrónico antes de presionar -¿Olvidaste tu contraseña-.";
        Debug.Log(error.ErrorMessage);
        Debug.Log(error.GenerateErrorReport());
        alertPanel.SetActive(true);

        alertImage.sprite = Resources.Load<Sprite>("images/alerts_Wrong");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseOnlyAlert(); });
        soundManager.PlayError1();
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Puntaje Global",
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
        alertImage.sprite = Resources.Load<Sprite>("images/alerts_Wrong");
        alertBtn.onClick.AddListener(delegate { masterStart.CloseOnlyAlert(); });
        soundManager.PlayError1();
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("melo");
        
    }
}
