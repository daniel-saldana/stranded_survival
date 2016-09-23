using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//public enum DayOrNight { Day, Night}
public enum TimeClock {Twelve, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven}

public class DayAndNight : MonoBehaviour
{

  //  public DayOrNight currentDay;

    public TimeClock timeOfDay;

    public float min;
    public int hour;

    public bool am;

    public Text displayTime;

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        min += Time.deltaTime * 3;
        HoursOfDay();
    }

    public void HoursOfDay()
        {

        if (min >= 60)
        {
            hour += 1;
            min = 0;
        }

        if (hour >= 12)
        {
            am = !am;
            hour = 0;
        }

        switch (hour)
             {
                case 0:
                timeOfDay = TimeClock.Twelve;
                displayTime.text = "12:00"; 
                break;

            case 1:
                timeOfDay = TimeClock.One;
                displayTime.text = "1:00";
                break;

            case 2:
                timeOfDay = TimeClock.Two;
                displayTime.text = "2:00";
                break;

            case 3:
                timeOfDay = TimeClock.Three;
                displayTime.text = "3:00";
                break;

            case 4:
                timeOfDay = TimeClock.Four;
                displayTime.text = "4:00";
                break;

            case 5:
                timeOfDay = TimeClock.Five;
                displayTime.text = "5:00";
                break;

            case 6:
                timeOfDay = TimeClock.Six;
                displayTime.text = "6:00";
                break;

            case 7:
                timeOfDay = TimeClock.Seven;
                displayTime.text = "7:00";
                break;

            case 8:
                timeOfDay = TimeClock.Eight;
                displayTime.text = "8:00";
                break;

            case 9:
                timeOfDay = TimeClock.Nine;
                displayTime.text = "9:00";
                break;

            case 10:
                timeOfDay = TimeClock.Ten;
                displayTime.text = "10:00";
                break;

            case 11:
                timeOfDay = TimeClock.Eleven;
                displayTime.text = "11:00";
                break;

            default:

                timeOfDay = TimeClock.Twelve;
                break;

        }
        
        
        }
       
}
