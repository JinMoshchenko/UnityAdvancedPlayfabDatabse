﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;
    public Text message;


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
        Debug.Log("Successful logic/account create!");
    }
    void OnError(PlayFabError error)
    {
        message.text = error.ErrorMessage;
        Debug.Log("Error while logging in/creating account!");
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
        message.text = "Registered and logged in!";
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
        message.text = "Logged in!";
        Debug.Log("Successful login!");
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
}
