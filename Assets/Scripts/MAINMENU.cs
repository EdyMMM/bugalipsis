using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
    [SerializeField] HORMIGA antAndLevelData;

    

    public void SelectLevel(string  assignedLevelName)
    {
        antAndLevelData.levelName = assignedLevelName;
    }

    public void SelectAntSkin(Sprite assignedAntSkin)
    {
        antAndLevelData.antSkin = assignedAntSkin;
    }


    public void StartGame()
    {
        SceneManager.LoadScene(antAndLevelData.levelName);
    }
}
