using System;
using System.Collections.Generic;
using System.Text;

public class Robot : IIdentifiable
{
    private string model;

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public Robot(string model)
    {
        Model = model;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string Id { get; set; }
}
