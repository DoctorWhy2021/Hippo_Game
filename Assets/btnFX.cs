    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource myFX;
    [SerializeField]
    private AudioClip clickFX;
    // Start is called before the first frame update

    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }
}
