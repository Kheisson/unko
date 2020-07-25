using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Animation anim;
    public AnimationClip fadeOut;

    private void Awake()
    {
        text.gameObject.SetActive(false);
    }


    public void WaveAnimator(int level)
    {
        anim.clip = fadeOut;
        text.SetText($"Wave   {level} ");
        text.gameObject.SetActive(true);
        anim.Play();
    }


}
