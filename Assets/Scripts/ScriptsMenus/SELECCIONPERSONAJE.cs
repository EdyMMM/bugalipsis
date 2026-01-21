using UnityEngine;
using UnityEngine.SceneManagement;

public class SELECCIONPERSONAJE : MonoBehaviour
{
    public int numpersonaje = 1;
    public static SELECCIONPERSONAJE instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }
    public void Personaje1()
    {
        numpersonaje = 1;
    }
    public void Personaje2()
    {
        numpersonaje = 2;
    }
    public void Personaje3()
    {
        numpersonaje = 3;
    }

}
