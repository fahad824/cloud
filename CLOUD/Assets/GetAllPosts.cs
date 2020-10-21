using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

using UnityEngine.SceneManagement;
public class GetAllPosts : MonoBehaviour
{
    public Post post;


    // Update is called once per frame
    void Update()
    {
        RestClient.Get<Post>(DataBaseConfig.PostsURL + ".json").Then(response =>
        { 
         post = response;
            Debug.Log(response );
        });
    }
}
