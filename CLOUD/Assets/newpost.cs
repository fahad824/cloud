using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

using UnityEngine.SceneManagement;


public class newpost : MonoBehaviour
{
    public Text Name;
    public Text Des;

    public void AddANewPost()
    {
        Post post = new Post();
        //post.from = getUser();
        post.Name = Name.text;
        post.Description = Des.text;
        RestClient.Put<Post>(DataBaseConfig.PostsURL + post.Name + "/.json",post);
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
