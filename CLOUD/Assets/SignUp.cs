using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using Packages;

public class SignUp : MonoBehaviour
{
    public Text Email;
    public Text Password;

    public Transform Error;
    public void Submit()
    {
        User user = new User();
        user.Name = Email.text;
        user.Password = Password.text;

        //Debug.Log(CheckIfUserNameExist(user.Name));
        if(CheckIfUserNameExist(Email.text) == false)
        {
           RestClient.Put(DataBaseConfig.URL + user.Name + "/.json", user);
           LoadMainScene();
        }
        else
        {
           ShowErrorMessage();
           
        }
        
    }
    public bool CheckIfUserNameExist(string Name)
    {
        bool Exist = true;
        
        RestClient.Get<User>(DataBaseConfig.URL + Name + ".json").Then(response =>
        {
            Debug.Log(response.Password);
            if (response.Password == "")
            {
                
                Exist = false;
                Debug.Log("U: " + response.Name + "Response: " + Name);
            }
            else if (response.Name == Name)
            {
                Exist = true;
            }

        });
        
        return Exist;
    }

    public void LoadMainScene()
    {
        Debug.Log("Main Screen Loaded");
    }

    IEnumerator ShowErrorMessage()
    {
        Error.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        Error.gameObject.SetActive(true);
    }

}
