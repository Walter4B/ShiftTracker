using System;

public class TimeManager
{
	internal decimal CalculateTime(TimeSpan startDate, TimeSpan endDate)
	{
		System.TimeSpan difference = endDate.Subtract(startDate);
		decimal minutes = decimal.Parse(string.Format("{0:0}.{1:00}", Math.Truncate(difference.TotalMinutes), difference.Seconds));
		return minutes;
	}
}
