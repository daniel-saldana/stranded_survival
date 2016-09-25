using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public enum TimeClock {Twelve, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven}

public class DayAndNight : MonoBehaviour
{
    public TimeClock timeOfDay;

    public float sec;
    public int min;
    public int hour;

    public bool am;

    public Text hourDisplay;
    public Text minDisplay;

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        sec += Time.deltaTime * 3;
        HoursOfDay();
    }

    public void HoursOfDay()
        {

        if (sec >= 60)
        {
            min += 1;
            sec = 0;
        }

        if (min >= 60)
        {
            hour += 1;
            min = 1;
        }

        if (hour >= 12)
        {
            am = !am;
            hour = 0;
        }

        minDisplay.text = "0  " + min;
        if(min >= 10)
        {
            minDisplay.text = "" + min;
        }
        switch (hour)
             {
                case 0:
                timeOfDay = TimeClock.Twelve;
                hourDisplay.text = "12:"; 
                break;

            case 1:
                timeOfDay = TimeClock.One;
                hourDisplay.text = "1:";
                break;

            case 2:
                timeOfDay = TimeClock.Two;
                hourDisplay.text = "2:";
                break;

            case 3:
                timeOfDay = TimeClock.Three;
                hourDisplay.text = "3:";
                break;

            case 4:
                timeOfDay = TimeClock.Four;
                hourDisplay.text = "4:";
                break;

            case 5:
                timeOfDay = TimeClock.Five;
                hourDisplay.text = "5:";
                break;

            case 6:
                timeOfDay = TimeClock.Six;
                hourDisplay.text = "6:";
                break;

            case 7:
                timeOfDay = TimeClock.Seven;
                hourDisplay.text = "7:";
                break;

            case 8:
                timeOfDay = TimeClock.Eight;
                hourDisplay.text = "8:";
                break;

            case 9:
                timeOfDay = TimeClock.Nine;
                hourDisplay.text = "9:";
                break;

            case 10:
                timeOfDay = TimeClock.Ten;
                hourDisplay.text = "10:";
                break;

            case 11:
                timeOfDay = TimeClock.Eleven;
                hourDisplay.text = "11:";
                break;

            default:

                timeOfDay = TimeClock.Twelve;
                break;

        }
        
        
        }
       
}
