using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageBotoes : MonoBehaviour
{
    public GameObject defaultScreen;
    public GameObject creditosScreen;

    // Start is called before the first frame update
    void Start()
    {
        defaultScreen = GameObject.Find("Default");
        creditosScreen = GameObject.Find("CreditosScreen");
        ReturnToMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("Main_menu");
    }

    public void ReturnToMenu()
    {
        defaultScreen.SetActive(true);
        creditosScreen.SetActive(false);
    }

    public void LoadFase1()
    {
        SceneManager.LoadScene("Lab5_RPGSetup");
    }
    public void LoadFase2()
    {
        SceneManager.LoadScene("Lab5_RPGSetup2");
    }
    public void Creditos()
    {
        defaultScreen.SetActive(false);
        creditosScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Saiu do game");
        Application.Quit();
    }
    public void ResetGame()     // Faz os botoes de fim de jogo voltar´à tela inicial
    {

    }
}
