using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour
{
    public Text UserName;
    public Text Password;

    public static User user = new User();
    public void LogInButton()
    {
        RestClient.Get<User>(DataBaseConfig.URL + UserName.text + ".json").Then(response =>
        {
            
            
                if (UserName.text != null )
                {
                    if (Password.text != null )
                    {
                        if ( Password.text != "" )
                        {
                            if (Password.text == response.Password)
                            {
                                LoadMainScene();
                            
                                user.Name = UserName.text;
                                user.Password = Password.text;
                                SavToBytes.SaveLoginData(user);
                            }

                        }

                    }

                }


            

        });

    }
    public void LoadMainScene()
    {
        Debug.Log("Main Screen Loaded");
        SceneManager.LoadScene("MainScene");
    }
    public void LoadSignUp()
    {
        SceneManager.LoadScene("SignUp");
    }
}
