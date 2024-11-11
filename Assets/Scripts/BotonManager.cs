using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonManager : MonoBehaviour
{
   

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //obtener boton jugar

    public void jugar()
    {
        //cargar escena de juego
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

}
