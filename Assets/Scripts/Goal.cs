using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    //prefab de pelota
    [SerializeField] private GameObject ball;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (this.name.Equals("Porteria2"))
        {
            gameManager.anota(1);
            Debug.Log("gol del 1");
            //nueva posicion de ball 0,0
            ball.transform.position = new Vector2(0, 0);
        }
        if (this.name.Equals("Porteria1"))
        {
            gameManager.anota(2);
            Debug.Log("gol del 2");
             ball.transform.position = new Vector2(0, 0);
            //crear un nuevo objeto bola

        }

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
