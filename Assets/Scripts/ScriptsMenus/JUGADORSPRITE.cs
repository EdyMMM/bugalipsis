using UnityEngine;

public class JUGADORSPRITE : MonoBehaviour
{
    int personaje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SELECCIONPERSONAJE.instance != null)
        {
            personaje = SELECCIONPERSONAJE.instance.numpersonaje;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
