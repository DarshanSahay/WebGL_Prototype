using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GateTypes
{
    KeyGate,
    CoinGate
}

public class GateLogic : MonoBehaviour
{
    public GateTypes gType;

    [SerializeField] private Animator anim;
    [SerializeField] private CapsuleCollider col;
    [SerializeField] private AudioClip gateOpen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>() != null)
        {
            if(gType == GateTypes.KeyGate)
            {
                if(GameManager.Instance.currentKeys != GameManager.Instance.totalKeys)
                {
                    UIManager.Instance.OpenMessagePanel(UIManager.Instance.keyMessagePanel);
                }
                else
                {
                    anim.SetBool("canOpenDoor", true);
                    AudioManager.Instance.PlaySound(gateOpen);
                    col.enabled = false;
                }
            }
            else if(gType == GateTypes.CoinGate)
            {
                if (GameManager.Instance.currentCoins != GameManager.Instance.totalCoins)
                {
                    UIManager.Instance.OpenMessagePanel(UIManager.Instance.coinMessagePanel);
                }
                else
                {
                    anim.SetBool("canOpenDoor", true);
                    AudioManager.Instance.PlaySound(gateOpen);
                    col.enabled = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            UIManager.Instance.CloseMessagePanel(UIManager.Instance.coinMessagePanel);
            UIManager.Instance.CloseMessagePanel(UIManager.Instance.keyMessagePanel);
        }
    }

}
