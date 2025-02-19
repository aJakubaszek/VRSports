using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Abuksigun.Piper;
using UnityEngine;


public class PiperTTS : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;

    [SerializeField]private string text = "One more lib and we are done";

    [SerializeField]private string modelPath;

    [SerializeField]private string espeakDataPath;
    private Piper piper;

    private PiperVoice voice;

    private PiperSpeaker piperSpeaker;

    public async Task SynthesizeText(string text)
    {
        if (text != null){
            this.text = text;
        }
        if (base.gameObject.scene.name == null)
        {
            throw new InvalidOperationException("This script must be attached to a game object in a scene, otherwise AudioSource can't play :(");
        }

        string fullModelPath = Path.Join(Application.streamingAssetsPath, modelPath);
        string fullEspeakDataPath = Path.Join(Application.streamingAssetsPath, espeakDataPath);
        if (piper == null)
        {
            piper = await Piper.LoadPiper(fullEspeakDataPath);
        }

        if (voice == null)
        {
            voice = await PiperVoice.LoadPiperVoice(piper, fullModelPath);
        }

        if (piperSpeaker == null)
        {
            piperSpeaker = new PiperSpeaker(voice);
        }

        await piperSpeaker.ContinueSpeach(text).ContinueWith(delegate (Task x)
        {
            Debug.Log($"Generation finished with status: {x.Status}");
        });
        audioSource.clip = piperSpeaker.AudioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
