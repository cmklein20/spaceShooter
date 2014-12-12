using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class LevelUIManager : MonoBehaviour 
{
	public Text scoreText;
	public Text timeText;
	public double elapsedTime;
	public int maxFuel;
	public RectTransform fuelTransform;
	public Text fuelText;
	public Image visualFuel;
	public float coolDown;

	private int currentFuel;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	private float currentXValue;
	private bool onCD;


	// Use this for initialization
	void Start () 
	{
		if (scoreText == null)
		{
			scoreText = GetComponent<Text>();
			scoreText.text = "Score: 0";
		}

		if (timeText == null)
		{
			timeText = GetComponent<Text>();
			timeText.text = "Time: 0";
		}

		elapsedTime = 0;
		onCD = false;
		cachedY = fuelTransform.position.y;
		maxXValue = fuelTransform.position.x;
		minXValue = fuelTransform.position.x - fuelTransform.rect.width;
		currentFuel = maxFuel;
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateTime ();
		FuelTimer ();
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
		currentXValue = Map (currentFuel, 0, maxFuel, minXValue, maxXValue);
		fuelTransform.position = new Vector3 (currentXValue, cachedY);

		if (currentFuel > maxFuel / 2)
		{
			visualFuel.color = new Color32((byte)Map(currentFuel, maxFuel / 2, maxFuel, 255, 0), 255, 0, 255);
		}
		else
		{
			visualFuel.color = new Color32(255, (byte)Map(currentFuel, 0, maxFuel / 2, 0, 255), 0, 255);
		}
	}

	public void FuelTimer ()
	{
		if (!onCD && currentFuel > 1)
		{
			StartCoroutine(CoolDownDamage());
			Fuel -= 1;
		}
	}
	
	public float Map(float x, float in_min, float in_max, float out_min, float out_max)
	{
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}

	IEnumerator CoolDownDamage ()
	{
		onCD = true;
		yield return new WaitForSeconds(coolDown);
		onCD = false;
	}
}
