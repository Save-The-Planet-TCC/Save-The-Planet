using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public int sceneIndex;
    public InputField userInput;
    public Button playButton;

    public void Play()
    {
        if(!string.IsNullOrEmpty(userInput.text))
        {
            GameData.Instance.SetUsername(userInput.text);
            SceneManager.LoadScene(sceneIndex);
        }
    }

    void Update()
    {
        playButton.interactable = !string.IsNullOrEmpty(userInput.text);
    }
}
