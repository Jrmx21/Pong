using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int puntosJ1;
    [SerializeField] private int puntosJ2 = 7;
    // Start is called before the first frame update

    [SerializeField] private GameObject textoPuntosJ1;
    [SerializeField] private GameObject textoPuntosJ2;
    [SerializeField] private GameObject ball;

    void Start()
    {
        textoPuntosJ1.GetComponent<TextMeshProUGUI>().text = puntosJ1.ToString();
        textoPuntosJ2.GetComponent<TextMeshProUGUI>().text = puntosJ2.ToString();
    }
    public void anota(int jugNum)
    {

        if (jugNum == 1)
        {
            puntosJ1++;
            textoPuntosJ1.GetComponent<TextMeshProUGUI>().text = puntosJ1.ToString();
            textoPuntosJ2.GetComponent<TextMeshProUGUI>().text = puntosJ2.ToString();
        }
        if (jugNum == 2)
        {
            puntosJ2++;
            textoPuntosJ1.GetComponent<TextMeshProUGUI>().text = puntosJ1.ToString();
            textoPuntosJ2.GetComponent<TextMeshProUGUI>().text = puntosJ2.ToString();
        }
        ball.transform.position = new Vector2(0, 0);
        //direccion aleatoria
        ball.GetComponent<Ball>().direccionAleatoria();
        if (puntosJ1 == 10)
        {
            Debug.Log("gano el jugador 1");
            SceneManager.LoadScene("Ganador1");
        }
        if (puntosJ2 == 10)
        {
            Debug.Log("gano el jugador 2");
            SceneManager.LoadScene("Ganador2");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
