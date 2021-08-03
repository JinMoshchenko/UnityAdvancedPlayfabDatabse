using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;
    public Text message;
    private Character character;
    private Game game;


    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        message.text = "Welcome!";
        Debug.Log("Successful login with unique device!");
    }
    void OnError(PlayFabError error)
    {
        message.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    #region Registration
    public void Register_B()
    {
        if(passwordInput.text.Length < 6)
        {
            message.text = "Password is too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registered and logged in!");
        SceneManager.LoadScene(1);
    }
    #endregion

    #region Login
    public void Login_B()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Successful login!");
        GetCharacterStats();
        SceneManager.LoadScene(1);
    }
    #endregion

    #region ResetPassword
    public void ResetPassword_B()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "8D3F0"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        message.text = "Password reset mail sent!";
    }
    #endregion

    #region GameData
    public void SaveCharacterStats()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Stats", JsonUtility.ToJson(GameObject.Find("GameContainer").GetComponent<Game>().ReturnClass())}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnCharacterDataSend, OnError);
    }
    void OnCharacterDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successful character data send!");
    }
    public void GetCharacterStats()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnCharacterDataReceived, OnError);
    }
    void OnCharacterDataReceived(GetUserDataResult result)
    {
        Debug.Log("Received character data!");
        if(result.Data != null && result.Data.ContainsKey("Stats"))
        {
            game = GameObject.Find("GameContainer").GetComponent<Game>();
            character = JsonUtility.FromJson<Character>(result.Data["Stats"].Value);
            game.SetUIValues(character);
            game.STRENGTH = character._STRENGTH;
            game.AGILITY = character._AGILITY;
            game.STAMINA = character._STAMINA;
            game.KNOWLEDGE = character._KNOWLEDGE;
            game.ABILITIES = character._ABILITIES;
            game.player.localScale = character._SCALE;
            game.player.position = character._POSITION;
        }
    }
    #endregion
}
