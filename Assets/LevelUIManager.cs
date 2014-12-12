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
		Debug.Log ("Current fuel: " + currentFuel);
		currentXValue = MapValues (currentFuel, 0, maxFuel, minXValue, maxXValue);
		Debug.Log ("Current x value: " + currentXValue);
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
}
