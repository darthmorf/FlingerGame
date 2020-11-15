using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenubutton : MonoBehaviour
{
    [SerializeField] string nextScene;

    public void onClick()
    {
        SceneManager.LoadScene(nextScene);
    }
}
