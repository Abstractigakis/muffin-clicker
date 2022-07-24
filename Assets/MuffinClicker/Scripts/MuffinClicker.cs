using UnityEngine;
using TMPro;

/// <summary>

/// </summary>
public class MuffinClicker : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private float _w, _x, _y, _z;

    [SerializeField]
    private TextMeshProUGUI _textRewardPrefab;

    [SerializeField]
    private Texture2D[] _desserts;

    public void OnMuffinClicked()
    {
        int addedMuffins = _gameManager.AddMuffins();
        CreateTextRewardPrefab(addedMuffins);
    }

    private void CreateTextRewardPrefab(int addedMuffins)
    {
        TextMeshProUGUI textRewardClone = Instantiate(_textRewardPrefab, transform);
        Vector2 randomVector = MyToolbox.GetRandomVector2(_w, _x, _y, _z);
        textRewardClone.transform.localPosition = randomVector;
        textRewardClone.text = $"+{addedMuffins}";
    }
}
