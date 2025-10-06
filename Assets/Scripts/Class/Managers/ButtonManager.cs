using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas playerGroundCanvas;

    void Start()
    {

    }

    void Update()
    {

    }

    public void StartGame()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        playerGroundCanvas.gameObject.SetActive(true);
    }
}
