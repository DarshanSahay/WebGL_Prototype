using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ControllerTypes
{
    KeyBoard,
    Joystick
}

public class GameManager : GenericSingleton<GameManager>
{
    [HideInInspector] public int totalCoins;
    [HideInInspector] public int currentCoins;

    [HideInInspector] public int totalKeys;
    [HideInInspector] public int currentKeys;

    public ControllerTypes cType;

    [SerializeField] private GameObject gameWinPanel;
    [SerializeField] private AudioClip gameWinSound;

    private void Start()
    {
        currentCoins = 0;
        currentKeys = 0;
    }

    public void UpdateKeyCount()
    {
        currentKeys++;
    }

    public void UpdateCoinCount()
    {
        currentCoins++;
    }

    public void SceneReset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>() != null)
        {
            gameWinPanel.SetActive(true);
            AudioManager.Instance.PlaySound(gameWinSound);
            Time.timeScale = 0;
        }
    }
}
