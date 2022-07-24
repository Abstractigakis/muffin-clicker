using UnityEngine;
using UnityEngine.UI;

public class SpawnCandies : MonoBehaviour
{
    [SerializeField]
    private float _candiesPerSecond = 1;

    [SerializeField]
    private GameObject _candyPrefab;

    [SerializeField]
    public Texture[] _candies;

    private float _countdown = 0;

    private void CreateFallingCandiesPrefab()
    {
        GameObject candyClone = Instantiate(_candyPrefab, transform);
        candyClone.transform.localPosition = new Vector2(
            Random.Range(-1400, 1400), 800);

        RawImage imgCmp = candyClone.GetComponent<RawImage>();
        imgCmp.texture = _candies[Random.Range(0, _candies.Length)];
    }

    private void Start()
    {
        resetCountdown();
    }

    private void resetCountdown()
    {
        _countdown = 1 / _candiesPerSecond;
    }

    void Update()
    {
        _countdown -= Time.deltaTime;
        if (_countdown <= 0)
        {
            CreateFallingCandiesPrefab();
            resetCountdown();
        }
    }
}
