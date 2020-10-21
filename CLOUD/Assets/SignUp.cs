using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

using UnityEngine.SceneManagement;

public class SignUp : MonoBehaviour
{
    public Text Email;
    public Text Password;

    public Transform Error;

    public static User user = new User();
    public void Submit()
    {
        
        user.Name = Email.text;
        user.Password = Password.text;

        //Debug.Log(CheckIfUserNameExist(user.Name));
        // if(CheckIfUserNameExist(Email.text) == false)
        //{
       
       RestClient.Put(DataBaseConfig.URL + user.Name + "/.json", user);
        LoadMainScene();
        
        SavToBytes.SaveLoginData(user);
        //}
        //else
        //{
        // ShowErrorMessage();

        //}

    }
    

    public void LoadMainScene()
    {
        Debug.Log("Main Screen Loaded");
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator ShowErrorMessage()
    {
        Error.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        Error.gameObject.SetActive(true);
    }
    public void LoadLogIn()
    {
        SceneManager.LoadScene("LogIn");
    }

}
