using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using Abuksigun.Piper;
using HuggingFace.API;
using TMPro;
using UnityEngine;

public class VoiceRecognition : MonoBehaviour
{
        [SerializeField] private ButtonFollowVisual startButton;
        [SerializeField] private ButtonFollowVisual stopButton;
        [SerializeField] private TextMeshPro text;
        [SerializeField] private OpenAI chat;
        [SerializeField] private PiperTTS piperTTS;

        private AudioClip clip;
        private byte[] bytes;
        private bool recording;

        private void Start() {
            startButton.buttonPressed += StartRecording;
            stopButton.buttonPressed += StopRecording;
            stopButton.DisableButton();
        }
        private void Update() {
            if (recording && Microphone.GetPosition(null) >= clip.samples) {
                StopRecording();
            }
        }
            private void StartRecording() {
            text.color = Color.white;
            text.text = "Recording...";
            startButton.DisableButton();
            stopButton.EnableButton();
            clip = Microphone.Start(null, false, 10, 44100);
            recording = true;
        }
            private void StopRecording() {
            var position = Microphone.GetPosition(null);
            Microphone.End(null);
            var samples = new float[position * clip.channels];
            clip.GetData(samples, 0);
            bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
            recording = false;
            SendRecording();
        }

        private void SendRecording() {
            text.color = Color.yellow;
            text.text = "Sending...";
            stopButton.DisableButton();
            HuggingFaceAPI.AutomaticSpeechRecognition(bytes, async response => {
                text.color = Color.white;
                Debug.Log(response);
                string answer = await chat.GenerateOutputAsync(response);
                await piperTTS.SynthesizeText(answer);
                startButton.EnableButton();
            }, error => {
                text.color = Color.red;
                text.text = error;
                startButton.EnableButton();
            });
        }
        private byte[] EncodeAsWAV(float[] samples, int frequency, int channels) {
            using (var memoryStream = new MemoryStream(44 + samples.Length * 2)) {
                using (var writer = new BinaryWriter(memoryStream)) {
                    writer.Write("RIFF".ToCharArray());
                    writer.Write(36 + samples.Length * 2);
                    writer.Write("WAVE".ToCharArray());
                    writer.Write("fmt ".ToCharArray());
                    writer.Write(16);
                    writer.Write((ushort)1);
                    writer.Write((ushort)channels);
                    writer.Write(frequency);
                    writer.Write(frequency * channels * 2);
                    writer.Write((ushort)(channels * 2));
                    writer.Write((ushort)16);
                    writer.Write("data".ToCharArray());
                    writer.Write(samples.Length * 2);

                    foreach (var sample in samples) {
                        writer.Write((short)(sample * short.MaxValue));
                    }
                }
                return memoryStream.ToArray();
            }
        }
}
