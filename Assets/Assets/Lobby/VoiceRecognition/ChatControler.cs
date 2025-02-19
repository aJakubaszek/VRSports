using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Abuksigun.Piper;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;


public class ChatControler : MonoBehaviour
{
    [SerializeField]TextMeshPro text;
    [SerializeField]PiperExample tts;
    
    public async Task<string> GenerateOutputAsync(string prompt){
        HttpClient client = new HttpClient();
        var response = await client.GetAsync($"https://localhost:7151/GPT/content?content={prompt}");
        return await response.Content.ReadAsStringAsync();
    }
}

public record GPTQuery(){
    public string model = "asst_TI9bXgJMcXDQuepdclOTbEAS";
    public List<Message> messages = new();
}

public record Message(){
    public string role = string.Empty;
    public string content = string.Empty;
}
