using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UIElements;

public class RestartPrefab : MonoBehaviour
{
    [SerializeField] private GameObject _restartPrefab;
    [SerializeField] private GameObject _canvas;
    private GameObject _restartButton;

    

    private void Start()
    {
        _restartButton = Instantiate(_restartPrefab, _canvas.transform);
        _restartButton.SetActive(false);
    }

    public void ShowRestartButton()
    {
        _restartPrefab.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
