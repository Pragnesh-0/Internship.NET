using System;

public class Employee
{
    private string EmployeeName;
    private int EmployeeNumber;


    public void SetName(string Name)
    {
        this.EmployeeName = Name;
    }

    public void SetNumber(int Number)
    {
        this.EmployeeNumber = Number;
    }

    public string GetName()
    {
        return EmployeeName;
    }

    public int GetNumber()
    {
        return EmployeeNumber;
    }

}
