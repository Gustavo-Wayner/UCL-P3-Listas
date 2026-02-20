using System;
using System.Diagnostics.Contracts;
using System.Dynamic;

public class Vehicle
{
    protected int occupants;
    protected int wheels;
    protected float tank_capacity;
    protected float tank_level_pcnt;
    private float avg_consumption;
    private float mileage;

    public float GetAvgConsumption()
    {
        return avg_consumption;
    }

    public void SetAvgConsumption( float a )
    {
        avg_consumption = a;
    }

    public float GetMileage()
    {
        return mileage;
    }

    public void SetMileage( float m )
    {
        mileage = m;
    }

    public Vehicle() {}

    public Vehicle( int _occupants, int _wheels, float _tank_capacity, float _tank_level_pcnt, float _avg_consumption, float _mileage )
    {
        occupants = _occupants;
        wheels = _wheels;
        tank_capacity = _tank_capacity;
        tank_level_pcnt = _tank_level_pcnt;
        avg_consumption = _avg_consumption;
        mileage = _mileage;
    }

//     Em pt-br pq ta no comando da questão
    public void Percorrer( float km )
    {
        mileage += km;
        if ( mileage > 999999.0f ) throw new Exception("Quilometragem ultrapassou 999.999");
    }
}

public class Car : Vehicle
{
    private string? model;
    private int doors;

    public Car() : base(){}

    public Car( int _occupants, int _wheels, float _tank_capacity, float _tank_level_pcnt, float _avg_consumption, float _mileage, string _model, int _doors )
    : base( _occupants, _wheels, _tank_capacity, _tank_level_pcnt, _avg_consumption, _mileage )
    {
        model = _model;
        doors = _doors;
    }
}