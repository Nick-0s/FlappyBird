using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private Button _startButton;
    [SerializeField] private Image _gameOverImage;

    private void OnEnable()
    {
        _bird.Died += OnDied;
    }

    private void OnDisable()
    {
        _bird.Died -= OnDied;
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
        _pipeGenerator.ResetPool();
    }

    private void OnDied()
    {
        Time.timeScale = 0;

        _gameOverImage.gameObject.SetActive(true);
        _startButton.gameObject.SetActive(true);
    }
}
