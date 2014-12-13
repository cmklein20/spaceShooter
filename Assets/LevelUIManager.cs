using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class LevelUIManager : MonoBehaviour 
{
	public Text scoreText;
	public int maxLevelScore = 10;
	public Text timeText;
	public double elapsedTime;
	public int maxFuel;
	public RectTransform fuelTransform;
	public Text fuelText;
	public Image visualFuel;
	public float coolDown;
	public Text displayLevel;
	
	private int currentFuel;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	private float currentXValue;
	private bool onCD;
	private int asteroidPoints;
	private int currentScore;
	private int lastLevel;
	private string winGame;
	private string loseGame;


	// Use this for initialization
	void Start () 
	{
		if (scoreText == null)
		{
			scoreText = GetComponent<Text>();
		}
		scoreText.text = "Score: 0/" + maxLevelScore;

		if (timeText == null)
		{
			timeText = GetComponent<Text>();
		}
		timeText.text = "Time: 0";

		elapsedTime = 0;
		onCD = false;
		cachedY = fuelTransform.position.y;
		maxXValue = fuelTransform.position.x;
		minXValue = fuelTransform.position.x - fuelTransform.rect.width;
		currentFuel = maxFuel;
		asteroidPoints = 10;
		lastLevel = 3;
		winGame = "WinGame";
		loseGame = "LoseGame";
		StartCoroutine (DisplayLevelText("Level " + Application.loadedLevel, 2));
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateTime ();
		FuelTimer ();

		if (currentFuel == 0)
		{
			Application.LoadLevel(loseGame);
		}

		if (LevelWon ())
		{
			if (Application.loadedLevel == lastLevel)
			{
				Application.LoadLevel(winGame);
			}
			else
			{
				LoadNextLevel ();
			}
		}
	}

	public void UpdateTime ()
	{
		if (timeText != null)
		{
			elapsedTime += Time.deltaTime;
			timeText.text = "Time: " + Math.Floor(elapsedTime).ToString();
		}
		else
		{
			timeText = GetComponent<Text>();
		}
	}

	public int Fuel
	{
		get 
		{
			return currentFuel;
		}

		set
		{
			currentFuel = value;
			HandleFuelBar ();
		}
	}

	public void HandleFuelBar ()
	{
		fuelText.text = "Fuel: " + currentFuel;
		currentXValue = MapValues (currentFuel, 0, maxFuel, minXValue, maxXValue);
		fuelTransform.position = new Vector3 (currentXValue, cachedY);

		if (currentFuel > maxFuel / 2)
		{
			visualFuel.color = new Color32((byte)MapValues(currentFuel, maxFuel / 2, maxFuel, 255, 0), 255, 0, 255);
		}
		else
		{
			visualFuel.color = new Color32(255, (byte)MapValues(currentFuel, 0, maxFuel / 2, 0, 255), 0, 255);
		}
	}

	public void FuelTimer ()
	{
		if (!onCD && currentFuel > 0)
		{
			StartCoroutine(CoolDownDamage());
			Fuel -= 1;
		}
	}
	
	public float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}

	IEnumerator CoolDownDamage ()
	{
		onCD = true;
		yield return new WaitForSeconds(coolDown);
		onCD = false;
	}

	public void UpdateScore ()
	{
		if (scoreText != null)
		{
			if (currentScore <= maxLevelScore)
			{
				currentScore += asteroidPoints;
				scoreText.text = "Score: " + currentScore + "/" + maxLevelScore;
			}
		}
		else
		{
			scoreText = GetComponent<Text>();
		}
	}

	public bool LevelWon ()
	{
		if (currentScore == maxLevelScore)
		{
			return true;
		}

		return false;
	}

	public void LoadNextLevel ()
	{
		scoreText.text = "Score: 0/" + maxLevelScore;
		currentFuel = 100;
		currentScore = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	IEnumerator DisplayLevelText (string message, float delay)
	{
		displayLevel.text = message;
		displayLevel.enabled = true;
		yield return new WaitForSeconds(delay);
		displayLevel.enabled = false;
	}

	public void RefillFuel ()
	{
		currentFuel = maxFuel;
	}

	public void LoadMainMenu ()
	{
		Application.LoadLevel ("MainMenu");
	}
}
