using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private int _level;
    
    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    private TextMeshProUGUI _costText;

    //[SerializeField]
    //private int[] _costPerLevel;

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private float _costPowerScale = 1.5f;

    [SerializeField]
    private UpgradeType _upgradeType;

    private int CurrentCost
    {
        get
        {
            return 5 + Mathf.RoundToInt(Mathf.Pow(_level, _costPowerScale));
        }

    }

    private void Start()
    {
        UpdateUI();

        GetComponent<Button>().onClick.AddListener(OnUpgradeClicked);

        _gameManager.OnTotalMuffinsChanged.AddListener(TotalMuffinsChanged);

    }

    public void TotalMuffinsChanged(int totalMuffins)
    {
        bool canAfford = totalMuffins >= CurrentCost;
        _costText.color = canAfford ? _costText.color = Color.green : Color.red;
    }

    private void UpdateUI()
    {
        _levelText.text = _level.ToString();
        _costText.text = CurrentCost.ToString();
    }

    public void OnUpgradeClicked() {
 
        bool purchasedUpgrade = _gameManager.TryPurchaseUpgrade(CurrentCost, _level, _upgradeType);
        if(purchasedUpgrade)
        {
            _level++;
            UpdateUI();
        }
    }
}
