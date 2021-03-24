using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonCH5 : MonoBehaviour
{

    private Button button;
    private GameManagerCH5 gameManager;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerCH5>();
    }

    void SetDifficulty() {
        gameManager.StartGame(difficulty);
        Debug.Log(gameObject.name + " was clicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
