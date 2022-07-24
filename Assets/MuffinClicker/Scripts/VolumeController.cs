using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private Slider _volumeSlider;
    public void OnVolumeCahgned() {
        AudioListener.volume = _volumeSlider.value;
    }

}
