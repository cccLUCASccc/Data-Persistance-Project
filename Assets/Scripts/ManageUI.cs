using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageUI : MonoBehaviour
{
    public void StartGame()
    {
        Manager.Instance.name = GameObject.Find("InputField").transform.Find("TextInput").GetComponent<Text>().text;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject.Find("BestPlayer").GetComponent<Text>().text = "Best Player : " + Manager.Instance.bestplayerName + ", score : " + Manager.Instance.bestScore + "";
        }
        else
        {
            GameObject.Find("BestPlayer1").GetComponent<Text>().text = "Best Player : " + Manager.Instance.bestplayerName + ", score : " + Manager.Instance.bestScore + "";
        }
    }
}
