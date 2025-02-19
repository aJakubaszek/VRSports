VR Sports is a virtual reality game that lets players experience prototypes of various sports, including bowling, darts, a shooting range, and basketball. The game was built using HDRP, primarily to experiment with ray tracing in the shooting range scene.

It features an AI assistant powered by OpenAI's ChatGPT-3.5 Turbo. Players can interact with the assistant by pressing a button in the Lobby scene, after which their voice is transcribed into text and sent to ChatGPT. The response is then read aloud using PiperTTS. The assistant provides information based on an initial prompt sent at startup (chat history is not maintained, as the Assistant API was scrapped for this purpose).

To use the assistant, you need to insert your OpenAI API key and Hugging Face key into their respective scripts.

[Simple showcase](https://www.youtube.com/watch?v=_0D68AvtQ_I)
