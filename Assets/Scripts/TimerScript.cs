using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerScript : MonoBehaviour
{
    public GameObject timerText;
    private Text timerTextComponent;
    private float timeRemaining = 60;
    private float timeSinceLastUpdate = 0f;
    public int sceneBuildIndex;
    // Start is called before the first frame update
    private void Start()
    {
        timerTextComponent = timerText.GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= 1f)
        {
            timeRemaining -= 1f;
            timeSinceLastUpdate = 0f;
            timerTextComponent.text = Mathf.Ceil(timeRemaining).ToString();

            if (timeRemaining <= 0f)
            {
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                timerTextComponent.text = Mathf.Ceil(timeRemaining).ToString();
            }
        }
    }
}
