using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SplashScreenController : MonoBehaviour
{
    public TextMeshProUGUI pressAnyKeyText;
    public RectTransform titleText;
    public float fadeSpeed = 2f;
    public float dropAmount = 30f;
    public float dropDuration = 0.4f;
    public float flySpeed = 500f;

    private bool fadingOut = true;
    private float alpha = 1f;
    private bool canProceed = false;
    private bool animationStarted = false;
    private Vector2 initialTitlePosition;
    private float dropTimer = 0f;
    private bool flyingUp = false;

    private float currentFlySpeed = 0f;
    public float flyAcceleration = 1000f;

    void Start()
    {
        initialTitlePosition = titleText.anchoredPosition;
        Invoke("EnableInput", 1f); 
    }

    void Update()
    {
        if (!animationStarted)
        {
            AnimatePressAnyKey();

            if (canProceed && Input.anyKeyDown)
            {
                animationStarted = true;
            }
        }
        else
        {
            AnimateTitleAndExit();
        }
    }

    void AnimatePressAnyKey()
    {
        alpha += (fadingOut ? -1 : 1) * Time.deltaTime * fadeSpeed;
        alpha = Mathf.Clamp01(alpha);

        if (alpha <= 0f) fadingOut = false;
        if (alpha >= 1f) fadingOut = true;

        var color = pressAnyKeyText.color;
        color.a = alpha;
        pressAnyKeyText.color = color;
    }

    void AnimateTitleAndExit()
    {
        var color = pressAnyKeyText.color;
        color.a = Mathf.MoveTowards(color.a, 0f, Time.deltaTime * fadeSpeed);
        pressAnyKeyText.color = color;

        if (!flyingUp)
        {
            dropTimer += Time.deltaTime;
            float progress = dropTimer / dropDuration;
            float easedProgress = Mathf.SmoothStep(0, 1, progress);

            titleText.anchoredPosition = initialTitlePosition - new Vector2(0, dropAmount * easedProgress);

            if (progress >= 1f)
            {
                flyingUp = true;
            }
        }
        else
        {
            currentFlySpeed += flyAcceleration * Time.deltaTime;
            titleText.anchoredPosition += new Vector2(0, currentFlySpeed * Time.deltaTime);

            if (titleText.anchoredPosition.y > Screen.height + 200f)
            {
                SceneManager.LoadScene("Lobby");
            }
        }
    }

    void EnableInput()
    {
        canProceed = true;
    }
}
