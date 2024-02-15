using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    // with this script i can add scenes and easily call them up with a manager.
    //to call a scene
    //mainManager = this;
    //    gameMainButton.onClick.AddListener(() =>
    //    {
    //        Loader.Load(Loader.Scene.GameMain);
    //    });
public enum Scene
    {
        GameMain,
        MainMenu,
    }
    private static Scene targetScene;
    public static void Load(Scene targetScene)
    {
        Loader.targetScene = targetScene;
        Debug.Log("Loading scene set to: " + targetScene.ToString());
        SceneManager.LoadScene(targetScene.ToString(), LoadSceneMode.Single);
    }
    public static void LoaderCallback()
    {
        Debug.Log("LoaderCallback called. Loading scene: " + targetScene.ToString());
        SceneManager.LoadScene(targetScene.ToString(), LoadSceneMode.Single);
    }
}

