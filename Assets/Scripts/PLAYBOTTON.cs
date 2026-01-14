using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;
public class PLAYBOTTON : MonoBehaviour
{
    public void EscenaInicial()
    {
        SceneManager.LoadScene("MENUMAPAS");
    }
    public void Mapa1()
    {
        SceneManager.LoadScene("PISTA 1");
    }
    public void Mapa2()
    {
        SceneManager.LoadScene("PISTA2");
    }

}
