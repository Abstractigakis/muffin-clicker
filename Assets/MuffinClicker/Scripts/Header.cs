using System.Collections;
using TMPro;
using UnityEngine;

public class Header : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _totalMuffinsText;

    [SerializeField]
    private TextMeshProUGUI _muffinsPerSecond;

    /// <summary>
    /// Updates the toal muffins text
    /// </summary>
    /// <param name="counter">The total muffins</param>
    public void UpdateTotalMuffins(int counter) 
    { 
        _totalMuffinsText.text = counter == 1 ? "1 muffin" : $"{counter} muffins";
    }

    public void UpdateMuffinsPerSecond(int counter)
    {
        _muffinsPerSecond.text = counter == 1 ? "1 muffin / second" : $"{counter} muffins / second";
    }
}
