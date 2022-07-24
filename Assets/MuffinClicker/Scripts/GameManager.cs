using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 1. handles the button click
/// 2. keep track of our total muffins
/// 3. crit logic
/// </summary>
public class GameManager : MonoBehaviour
{

    public UnityEvent<int> OnTotalMuffinsChanged;

    [SerializeField]
    private int _muffinsPerSecond = 0;

    
    private int _totalMuffins = 0;
    private int _muffinsPerClick;
    private float _muffinsPerSecondTimer;

    private int TotalMuffins
    {
        get
        {
            return _totalMuffins;
        }

        set
        {
            _totalMuffins = value;
            OnTotalMuffinsChanged.Invoke(_totalMuffins);
        }
    }

    [SerializeField]
    private int _muffinsCollectedPerClick = 1;
   
    [Range(0f, 1f)]
    [SerializeField]
    private float _critChance = 0.01f;



    /// <summary>
    /// Ads muffins to the total muffins
    /// </summary>
    /// <returns>return the added muffins</returns>
    public int AddMuffins()
    {
        int addedMuffins;
        if (Random.value <= _critChance)
        {
            addedMuffins = _muffinsCollectedPerClick * 10;
        }
        else
        {
            addedMuffins = _muffinsCollectedPerClick;
        }

        TotalMuffins += addedMuffins;


        return addedMuffins;
    }

    void Start()
    {
        TotalMuffins = 0;
    }

    private void Update()
    {
        _muffinsPerSecondTimer += Time.deltaTime;
        if (_muffinsPerSecondTimer >= 1.0f)
        {
            _muffinsPerSecondTimer -= 1.0f;
            TotalMuffins += _muffinsPerSecond;
        }

    }

    public bool TryPurchaseUpgrade(int currentCost, int level, UpgradeType upgradeType)
    {
        if (TotalMuffins >= currentCost)
        {
            TotalMuffins -= currentCost;
            level++;

            if (upgradeType == UpgradeType.Muffin)
            {
                _muffinsCollectedPerClick = 1 + level * 2;
            } else if (upgradeType == UpgradeType.SugarRush)
            {
                _muffinsPerSecond = level;
            } else if (upgradeType == UpgradeType.FancyMuffin)
            {
                //_muffinsPerSecond = level;
            }
            return true;
        }

        return false;
    }

    public bool TryPurchaseSugarRush(int currentCost)
    {
        if (TotalMuffins >= currentCost)
        {
            TotalMuffins -= currentCost;
            return true;
        }

        return false;
    }

}
