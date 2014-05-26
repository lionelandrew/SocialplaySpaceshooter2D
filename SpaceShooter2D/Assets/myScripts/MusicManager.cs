using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public AudioClip NewMusic; //Pick an audio track to play.

    void Awake()
    {
        var go = GameObject.Find("Socialplay"); //Finds the game object called Game Music, if it goes by a different name, change this.
        go.audio.clip = NewMusic; //Replaces the old audio with the new one set in the inspector.
        go.audio.Play(); //Plays the audio.
    }
}