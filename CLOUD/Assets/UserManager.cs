using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

using UnityEngine.SceneManagement;
public class UserManager : MonoBehaviour
{
    public Text Profile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Profile.text = getUser().Name;
    }
    public User getUser()
    {
        User u = new User();
        if (LogIn.user.Name != null)
        {
            u = LogIn.user;
        }
        else if (SignUp.user.Name != null)
        {
            u = SignUp.user;
        }
        else
        {
            u = SavToBytes.GetLoginData();
        }
        return u;
    }
}
