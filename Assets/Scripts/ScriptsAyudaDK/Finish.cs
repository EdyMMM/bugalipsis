using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public Canvas finish;
    int currentIndex;

    private void Awake()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;        // Esto solo es para obtener la escena actual  (Si nos vamos a "File > Build Profiles", hay un botón que dice Open Scene List, ahí están las escenas enumeradas)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        finish.gameObject.SetActive(true);                              // Agarra el canvas de la meta y lo muestra
    }

    public void SiguienteNivel()
    {
        finish.gameObject.SetActive(false);                             // Apaga el canvas de la meta, no es necesario pero sirve apagarlo por si acaso

        int nextIndex = currentIndex + 1;                               // Esto es para obtener la escena siguiente 

        if (nextIndex < SceneManager.sceneCountInBuildSettings)         // Checa que no se pase de la cantidad de escenas que hay y cause un error, solo es un por si acaso
        {
            SceneManager.LoadScene(nextIndex);                          // Carga la ssiguiente escena si se cumple lo de arriba
        }
        else
        {
            Debug.Log("No hay más niveles");                            // Solo dice "Se acabaron los niveles" en consola, no lo ves en el juego
        }
    }

    public void Reiniciar()
    {
        finish.gameObject.SetActive(false);

        SceneManager.LoadScene(currentIndex);                           // Carga la misma escena en la que está
    }

    public void MainMenu()
    {
        finish.gameObject.SetActive(false);

        SceneManager.LoadScene("MENU PRINCIPAL");                      // Como siempre queremos que lleve al menu principal, aqui esta bien poner el nombre
    }
}
