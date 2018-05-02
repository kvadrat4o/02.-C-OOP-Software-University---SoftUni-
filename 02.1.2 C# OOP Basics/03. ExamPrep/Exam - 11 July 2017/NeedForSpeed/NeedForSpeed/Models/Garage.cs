using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public  class Garage
{
    private Dictionary<int,Car> parkedCars;

    public Garage()
    {
        this.ParkedCars = new Dictionary<int,Car>();
    }

    public Dictionary<int,Car> ParkedCars
    {
        get { return parkedCars; }
        set { parkedCars = value; }
    }

}