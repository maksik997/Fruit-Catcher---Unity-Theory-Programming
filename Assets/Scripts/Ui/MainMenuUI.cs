using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private Button EasyButton, MediumButton, HardButton;

    private void Start()
    {
        EasyButton.onClick.AddListener(() => {
            MainManager.Instance.Time = 30;
            MainManager.Instance.InitialInterval = 3f;
            StartGame();
        });

        MediumButton.onClick.AddListener(() => {
            MainManager.Instance.Time = 60;
            MainManager.Instance.InitialInterval = 1f;
            StartGame();
        });

        HardButton.onClick.AddListener(() => {
            MainManager.Instance.Time = 90;
            MainManager.Instance.InitialInterval = .5f;
            StartGame();
        });
    }

    public void ExitApp()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
