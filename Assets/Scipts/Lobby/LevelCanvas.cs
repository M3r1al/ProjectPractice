using UnityEngine;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] private GameObject levelSlotPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private LevelData[] levelData;

    private void Awake() => CreateSlots();

    private void CreateSlots()
    {
        for (int i = 0; i < levelData.Length; i++)
            Instantiate(levelSlotPrefab, parent).GetComponent<LevelSlot>().SetData(levelData[i]);
    }
}

[System.Serializable]
public class LevelData
{
    public int sceneNumber;
    public int levelNumber;
}