﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    ATTACK,
    ATTACK_PICKUP,
    BG_AUDIO,
    DASH,
    DASH_PICKUP,
    DOOR,
    FIRE_BURNING,
    FIRE_PICKUP,
    FIRE_PUNCH,
    ICE_FREEZE,
    ICE_PICKUP,
    ICE_PUNCH,
    ICE_SLIDE,
    MENU_BUTTON,
    MENUS, PLAYER_DAMAGE,
    PLAYER_FEEDBACK,
    ROCK_BREAK,
    SPIKE,
    TORCH_LIGHT
}

public struct Range
{
    public float min;
    public float max;

    public Range(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public float RandomValue()
    {
        return UnityEngine.Random.Range(min, max);
    }
}

public class SoundCollection
{
    private AudioClip[] clips;

    public bool HasClips
    {
        get { return clips.Length > 0; }
    }

    public SoundCollection(params string[] soundNames)
    {
        clips = new AudioClip[soundNames.Length];
        for (int i = 0; i < soundNames.Length; i++)
        {
            clips[i] = Resources.Load<AudioClip>(soundNames[i]);
            if (clips[i] == null)
            {
                MonoBehaviour.print($"Can't find clip with name '{soundNames[i]}'");
            }
        }
    }

    public AudioClip RandomClip()
    {
        if (clips.Length == 0)
        {
            return null;
        }
        else
        {
            int index = UnityEngine.Random.Range(0, clips.Length);
            return clips[index];
        }
    }
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public float masterVolumeMult = 1.0f;
    public static readonly Range pitchRange = new Range(0.75f, 1.25f);
    public static readonly Range volRange = new Range(0.75f, 1.0f);

    private AudioSource audioSrc;
    private Dictionary<SoundType, SoundCollection> sounds;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        sounds = new Dictionary<SoundType, SoundCollection>() {
      {SoundType.ATTACK, new SoundCollection("attack") },
      {SoundType.ATTACK_PICKUP, new SoundCollection("attack_pickup") },
      {SoundType.BG_AUDIO, new SoundCollection("bg_audio") },
      {SoundType.DASH, new SoundCollection("dash") },
      {SoundType.DASH_PICKUP, new SoundCollection("dash_pickup") },
      {SoundType.DOOR, new SoundCollection("door") },
      {SoundType.FIRE_BURNING, new SoundCollection("fire_burning") },
      {SoundType.FIRE_PICKUP, new SoundCollection("fire_pickup") },
      {SoundType.FIRE_PUNCH, new SoundCollection("fire_punch") },
      {SoundType.ICE_FREEZE, new SoundCollection("ice_freeze") },
      {SoundType.ICE_PICKUP, new SoundCollection("ice_pickup") },
      {SoundType.ICE_PUNCH, new SoundCollection("ice_punch") },
      {SoundType.ICE_SLIDE, new SoundCollection("ice_slide") },
      {SoundType.MENU_BUTTON, new SoundCollection("menu_button") },
      {SoundType.MENUS, new SoundCollection("menus") },
      {SoundType.PLAYER_DAMAGE, new SoundCollection("player_damage") },
      {SoundType.PLAYER_FEEDBACK, new SoundCollection("player_feedback") },
      {SoundType.ROCK_BREAK, new SoundCollection("rock_break") },
      {SoundType.SPIKE, new SoundCollection("spike") },
      {SoundType.TORCH_LIGHT, new SoundCollection("torch_light") }
    };
    }

    public void PlaySound(SoundType type, bool allowPitchShift = true, bool allowVolShift = true)
    {
        PlaySound(type, audioSrc, allowPitchShift, allowVolShift);
    }

    public void PlayOnce(SoundType type, bool allowPitchShift = true, bool allowVolShift = true)
    {
        PlayOnce(type, audioSrc);
    }
    private void PlayOnce(SoundType type, AudioSource audioSrc)
    {
        if (audioSrc == null)
        {
            audioSrc = this.audioSrc;
        }
        if (sounds.ContainsKey(type) && sounds[type].HasClips)
        {
            if (audioSrc.gameObject.activeSelf)
            {
                audioSrc.clip = sounds[type].RandomClip();
                audioSrc.PlayOneShot(audioSrc.clip, 0.01f);
            }
        }
    }

    private void PlaySound(SoundType type, AudioSource audioSrc, bool allowPitchShift = true, bool allowVolShift = true)
    {
        if (audioSrc == null)
        {
            audioSrc = this.audioSrc;
        }
        if (sounds.ContainsKey(type) && sounds[type].HasClips)
        {
            if (audioSrc.gameObject.activeSelf)
            {
                audioSrc.pitch = allowPitchShift ? pitchRange.RandomValue() : 1.0f;
                audioSrc.volume = allowVolShift ? volRange.RandomValue() : 1.0f;
                audioSrc.volume *= masterVolumeMult;
                audioSrc.clip = sounds[type].RandomClip();
                audioSrc.Play();
            }
        }
    }
}
