using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;

public class TimedButtonScript : MonoBehaviour
{

    private bool isLooking;
    private Stopwatch timer;

    [SerializeField]
    private GameObject loader;
    private Slider slider;

    [SerializeField]
    private GameObject filler;
    private Image fill;
    private Color minColor = new Color(1f, 0f, 0f, 0f);
    private Color maxColor = new Color(1f, 0f, 0f, 1f);

    void Awake()
    {
        isLooking = false;
        timer = new Stopwatch();
        slider = loader.GetComponent<Slider>();
        fill = filler.GetComponent<Image>();
    }

    void Update()
    {
        Load(isLooking);
    }

	public void Load(bool looking)
	{
		if (looking)
		{
			timer.Start();
			slider.value = timer.ElapsedMilliseconds;
			fill.color = Color.Lerp(minColor, maxColor, slider.value / slider.maxValue);

			if (slider.value >= slider.maxValue)
			{
				ResetButton();
				isLooking = false;
				gameObject.GetComponent<Button>().onClick.Invoke();
			}

		}
		else
		{
			ResetButton();
		}
	}

	private void ResetButton()
	{
		timer.Reset();
		slider.value = 0;
		fill.color = minColor;
	}

    public void SetIsLooking(bool isLooking)
    {
        this.isLooking = isLooking;
    }
}

public class ButtonController : MonoBehaviour
{
    public GameObject goText;
    public GameObject[] menuItems;

    public void Start()
    {
        menuItems = GameObject.FindGameObjectsWithTag("MenuItem");
        goText = GameObject.Find("GOText");
    }

    public void SetMenuItems(bool isActive)
    {
        foreach (GameObject g in menuItems)
        {
            g.SetActive(isActive);
        }
    }
}
