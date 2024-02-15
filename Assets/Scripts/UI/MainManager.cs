using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Button gameMainButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject controlScreen;

    private void Awake()
    {
        Debug.Log("MainManager Awake");
        gameMainButton.onClick.AddListener(() =>
        {  
            Loader.Load(Loader.Scene.GameMain);
        });
        controlsButton.onClick.AddListener(() =>
        {
            controlScreen.SetActive(true);
        });
        backButton.onClick.AddListener(() =>
        {
            controlScreen.SetActive(false);
        });
    }
}
