using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarManager
{
    private Dictionary<int, Car> cars;

    private Dictionary<int, Race> races;

    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        if (type == "Show")
        {
            this.cars.Add(id, new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
        }
        else
        {
            this.cars.Add(id, new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
        }
    }
    public string Check(int id)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.cars[id].ToString());
        return sb.ToString().TrimEnd();
    }
    public void Open(int id, string type, int length, string route, int prizePool)
    {

        switch (type)
        {
            case "Casual":
                this.races.Add(id, new CasualRace(length, route, prizePool));
                break;
            case "Drag":
                this.races.Add(id, new DragRace(length, route, prizePool));
                break;
            case "Drift":
                this.races.Add(id, new DriftRace(length, route, prizePool));
                break;
        }
        //if (type == "Drift")
        //{
        //    this.races.Add(id, new DriftRace(length, route, prizePool));
        //}
        //else if (type == "Drag")
        //{
        //    this.races.Add(id, new DragRace(length, route, prizePool));
        //}
        //else
        //{
        //    this.races.Add(id, new CasualRace(length, route, prizePool));
        //}
    }
    public void Participate(int carId, int raceId)
    {
        var race = this.races.SingleOrDefault(r => r.Key == raceId).Value;
        var car = this.cars.SingleOrDefault(r => r.Key == carId).Value;
        if (!this.garage.ParkedCars.Any(pc => pc.Key == carId))
        {
            race.Participants.Add(car);
        }
    }
    public string Start(int id)
    {
        StringBuilder sb = new StringBuilder();
        var race = this.races.SingleOrDefault(a => a.Key == id).Value;
        if (race.Participants.Count <= 3 && race.Participants.Count > 0)
        {
            sb.AppendLine(race.ToString());
        }
        return sb.ToString().TrimEnd();
    }
    public void Park(int id)
    {
        var car = this.cars.SingleOrDefault(c => c.Key == id).Value;
        if (this.races.Any(r => r.Value.Participants.Any(p => p.ToString() != car.ToString())))
        {
            this.garage.ParkedCars.Add(id, car);
        }
    }
    public void Unpark(int id)
    {
        var car = this.cars.SingleOrDefault(c => c.Key == id).Value;
        this.garage.ParkedCars.Remove(id);
    }
    public void Tune(int tuneIndex, string addOn)
    {
        if (this.garage.ParkedCars.Count != 0)
        {
            Dictionary<int, Car> tempCars = new Dictionary<int, Car>();
            foreach (var car in this.garage.ParkedCars)
            {
                var ca = car.Key;
                var va = car.Value;
                va.HorsePower += tuneIndex;
                va.Suspension += tuneIndex / 2;

                if (car.GetType().ToString() == "Show")
                {
                    ShowCar scar = new ShowCar(va.Brand, va.Model, va.YearOfProduction, va.HorsePower, va.Acceleration, va.Suspension, va.Durability);
                    scar.Stars += tuneIndex;
                    tempCars.Add(ca, scar);
                }
                else if (car.GetType().ToString() == "Performance")
                {
                    PerformanceCar pcar = new PerformanceCar(va.Brand, va.Model, va.YearOfProduction, va.HorsePower, va.Acceleration, va.Suspension, va.Durability);
                    pcar.AddOns.Add(addOn);
                    tempCars.Add(ca, pcar);
                }
            }
            this.garage.ParkedCars = tempCars;
        }
    }

}
