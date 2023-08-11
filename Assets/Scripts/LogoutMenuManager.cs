using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoutMenuManager : MonoBehaviour
{

    public PlayFabManager playFabManager;
    public Button leaderboardBtn;
    public GameObject leaderboardCanvas;
    public Transform rowsParent;
    // Start is called before the first frame update
    void Start()
    {
        playFabManager = GameObject.FindAnyObjectByType<PlayFabManager>();
        leaderboardBtn.onClick.AddListener(delegate { playFabManager.GetLeaderboardLogout(); });
        Invoke("FindLeaderboardInPlayFab",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindLeaderboardInPlayFab()
    {
        playFabManager.FindLeaderboardLogout();
    }
}
