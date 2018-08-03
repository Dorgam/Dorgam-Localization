using System.Collections;
using System.Collections.Generic;
using Dorgam.Localization.Core;
using UnityEngine;

public class LocalizeAudio : AbstractLocalize
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    protected override void Localize()
    {
        _audio.clip = LocalizationManager.GetTranslation<AudioClip>(Term);
    }
}
