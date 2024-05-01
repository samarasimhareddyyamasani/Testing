using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Scenes : MonoBehaviour
{
    [SerializeField] private Image panel;
    public void LoadScenes(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OpenPanel()
    {
        panel.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        panel.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
