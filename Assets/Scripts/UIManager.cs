using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text hpText;
    public TMP_Text moneyText;
    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + gameManager.hp;
        moneyText.text = "Money: " + gameManager.money;
    }
}
