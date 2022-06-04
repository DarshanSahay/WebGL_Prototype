using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] private Text coinCountText;
    [SerializeField] private Text keyCountText;

    public GameObject coinMessagePanel;
    public GameObject keyMessagePanel;
    [SerializeField] private GameObject controllerPanel;
    [SerializeField] private GameObject joystickControllerPanel;

    public Button keyboardController;
    public Button joystickController;
    public Button replayButton;

    private void Start()
    {
        keyboardController.onClick.AddListener(SetKeyBoard);
        joystickController.onClick.AddListener(SetJoystick);
    }

    void SetKeyBoard()
    {
        SetGameController(ControllerTypes.KeyBoard);
        joystickControllerPanel.SetActive(false);
    }

    void SetJoystick()
    {
        SetGameController(ControllerTypes.Joystick);
    }

    public void SetGameController(ControllerTypes type)
    {
        GameManager.Instance.cType = type;
        controllerPanel.gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        coinCountText.text = GameManager.Instance.currentCoins + " / " + GameManager.Instance.totalCoins;
        keyCountText.text = GameManager.Instance.currentKeys + " / " + GameManager.Instance.totalKeys;
    }

    public void OpenMessagePanel(GameObject panel)
    {
        panel.gameObject.SetActive(true);
    }

    public void CloseMessagePanel(GameObject panel)
    {
        panel.gameObject.SetActive(false);
    }
}
