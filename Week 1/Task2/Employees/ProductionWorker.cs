using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductionWorker : Employee
{
    private int ShiftNumber;
    private double HourlyPayRate;
    public void SetShiftType(int ShiftType)
    {
        this.ShiftNumber = ShiftType;
    }

    public void SetPayRate(double PayRate)
    {
        this.HourlyPayRate = PayRate;
    }
    public string GetShiftNumber()
    {
        if (ShiftNumber == 1)
        {
            return "Day Shift";
        }
        return "Night Shift";
    }

    public double GetHourlyPayRate()
    {
        return HourlyPayRate;
    }
}