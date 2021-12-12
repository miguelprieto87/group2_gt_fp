using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public float money;
    public float moneyEarned;
    public float moneyMultiplier = 1;

    public GameObject finishLine;
    public Transform startPosition;
    public GameObject moneyEarnedPanel;
    public TextMeshProUGUI availableMoneyText;
    public TextMeshProUGUI distanceTraveledText;
    public TextMeshProUGUI distanceTraveledMoneyEarnedText;
    public TextMeshProUGUI moneyMultiplierText;
    public TextMeshProUGUI totalMoney;
    public UpgradesShop upgradeScript;
    public LaunchBall lbScript;
    public bool addedPoints = false;

    private float _distanceTraveled;

    void Update()
    {
        if(gameObject.transform.position.x >= finishLine.transform.position.x)
        {
            SceneManager.LoadScene("Game Over");
        }

        _distanceTraveled = transform.position.x - startPosition.position.x;
        distanceTraveledText.text = "Distance: " + Mathf.RoundToInt(_distanceTraveled) + " m";

        if(gameObject.GetComponent<Rigidbody2D>().IsSleeping() && addedPoints == false && lbScript.launched == true)
        {
            DisplayMoneyEarned();
        }
    }

    public void UpdateMoneyDisplay()
    {
        availableMoneyText.text = money.ToString();
    }

    void DisplayMoneyEarned()
    {
        addedPoints = true;
        moneyEarnedPanel.SetActive(true);

        //add earned money
        moneyEarned = _distanceTraveled / 10;
        //show earned money on screen
        distanceTraveledMoneyEarnedText.text = System.Math.Round(moneyEarned, 1).ToString();
        //show bonus
        moneyMultiplierText.text = moneyMultiplier.ToString();
        //multiply earned money by bonus
        moneyEarned *= moneyMultiplier;
        //show final money earned
        totalMoney.text = System.Math.Round(moneyEarned, 1).ToString();
        //add the money earned to the current owned money
        money += moneyEarned;

        UpdateMoneyDisplay();
        upgradeScript.UpdateAllButtons();
    }
}
