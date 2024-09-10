using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, playMenu, settingsMenu, shopMenu;

    public GameObject animationBallPrefab;


    void Start()
    {
        OpenMenu(mainMenu);
        SpawnAnimationBalls();
    }

    void SpawnAnimationBalls()
    {
        int amount = Random.Range(5, 10);

        for (int i = 0; i < amount; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));

            GameObject ball = Instantiate(animationBallPrefab, pos, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-500,500), Random.Range(-500, 500)), ForceMode2D.Force);
        }
    }


    void CloseAllMenus()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        settingsMenu.SetActive(false);
        shopMenu.SetActive(false);
    }

    void OpenMenu(GameObject menu)
    {
        CloseAllMenus();
        menu.SetActive(true);
    }

    public void BackButton()
    {
        OpenMenu(mainMenu);
    }

    public void PlayButton()
    {
        OpenMenu(playMenu);
    }

    public void SettingsButton()
    {
        OpenMenu(settingsMenu);
    }
    public void ShopButton()
    {
        OpenMenu(shopMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
