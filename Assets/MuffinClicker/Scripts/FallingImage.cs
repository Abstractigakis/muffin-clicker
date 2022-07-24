using TMPro;
using UnityEngine;

public class FallingImage : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed;

    private float _timer;


    void Update()
    {
        transform.Translate(0, -_moveSpeed * Time.deltaTime, 0);
        _timer = _timer + Time.deltaTime;

        if (transform.localPosition.y <= -800)
        {
            Destroy(gameObject);
        }
    }
}
