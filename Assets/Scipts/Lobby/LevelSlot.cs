using UnityEngine;
using TMPro;

public class LevelSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int scene;

    public void SetData(LevelData data)
    {
        text.text = data.levelNumber.ToString();
        scene = data.sceneNumber;
    }

    public void Load()
    {
        LevelSelection.Loader.LoadLevel(scene);
    }
}
