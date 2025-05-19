using TMPro;
using UnityEngine;

public class CompletePanelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsCount;
    [SerializeField] private TextMeshProUGUI escapeTime;

    private void OnEnable()
    {
        coinsCount.text = CoinController.count.ToString();
        escapeTime.text = GetTime(GameController.completeTime);
    }

    private string GetTime(float time)
    {
        int h = (int)(time / 3600);
        int m = (int)(time / 60 % 60);
        int s = (int)(time % 60);
        if (h > 0)
            return h.ToString() + ":" + m.ToString() + ":" + s.ToString();
        return m.ToString() + ":" + s.ToString();
    }

    public void Restart() => GameController.Instance.RestartLevel();

    public void Continue() => GameController.Instance.QuitLevel();
}
