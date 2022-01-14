
using UnityEngine;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour
{

    [SerializeField] private Slider SFX;
    [SerializeField] private AudioSource SFXSource;


    public void SetSFX()
    {
        if (SFX.value >= 0)
        {
            SFXSource.volume = SFX.value;
        }
    }
        
}
