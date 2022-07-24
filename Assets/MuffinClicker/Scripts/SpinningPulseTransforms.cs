using UnityEngine;

public class SpinningPulseTransforms : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spinLights;

    [SerializeField]
    float _spinSpeed = 360f;

    [SerializeField]
    private float _waveSpeed, _waveAmplitude, _waveOffset;

    private void Update()
    {
        Vector3 rotation = new Vector3();
        rotation.z = _spinSpeed * Time.deltaTime;

        for (int i = 0; i < _spinLights.Length; i++)
        {
            _spinLights[i].Rotate(rotation);

            float wave = Mathf.Sin(Time.time * _waveSpeed) * _waveAmplitude + _waveOffset;
        }
    }

}
