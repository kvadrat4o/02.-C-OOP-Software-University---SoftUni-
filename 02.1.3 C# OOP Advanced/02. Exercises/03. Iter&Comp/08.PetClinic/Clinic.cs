using System;
using System.Collections.Generic;
using System.Text;

public class Clinic
{
    private int numberOfRooms;
    public string Name;
    private IDictionary<int, Pet> Rooms;
    private int countEmptyrooms;
    private int NumberOfRooms
    {
        get { return numberOfRooms; }
        set
        {
            if (value % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            numberOfRooms = value;
        }
    }

    public Clinic(string name, int number)
    {
        this.Name = name;
        this.NumberOfRooms = number;
        this.Rooms = new Dictionary<int, Pet>(number);
        this.countEmptyrooms = number;
        GetRooms();
    }

    private void GetRooms()
    {
        for (int i = 0; i < this.NumberOfRooms; i++)
        {
            this.Rooms[i] = null;
        }
    }

    public bool Add(Pet pet)
    {
        if (this.countEmptyrooms == this.NumberOfRooms)
        {
            this.Rooms[this.Rooms.Count / 2] =  pet;
            this.countEmptyrooms--;
            return true;
        }
        else
        {
            int countTakenRooms = this.NumberOfRooms - this.countEmptyrooms;
            if (countTakenRooms % 2 == 0)
            {
                for (int i = (this.Rooms.Count / 2); i < this.Rooms.Count; i++)
                {
                    if (this.Rooms[i] == null)
                    {
                        this.Rooms[i] =  pet;
                        this.countEmptyrooms--;
                        return true;
                    }
                }
            }
            else if (countTakenRooms == 1)
            {
                this.Rooms[(this.Rooms.Count / 2) - 1] = pet;
                this.countEmptyrooms--;
                return true;
            }
            else
            {
                for (int i = (this.Rooms.Count / 2); i >= 0; i--)
                {
                    if (this.Rooms[i] == null)
                    {
                        this.Rooms[i] =  pet;
                        this.countEmptyrooms--;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.countEmptyrooms > 0;
    }

    public void Print()
    {
        foreach (var item in this.Rooms)
        {
            if (item.Value == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(item.Value);
            }
        }
    }

    public void Print(int n)
    {
        if (this.Rooms[n] == null)
        {
            Console.WriteLine("Room empty");
        }
        else
        {
            Console.WriteLine(this.Rooms[n]);
        }
    }

    public bool Release()
    {
        for (int i = (this.Rooms.Count / 2); i < this.Rooms.Count; i++)
        {
            if (this.Rooms[i] != null)
            {
                this.Rooms[i] = null;
                this.countEmptyrooms++;
                return true;
            }
        }
        for (int i = 0; i <= (this.Rooms.Count / 2); i++)
        {
            if (this.Rooms[i] != null)
            {
                this.Rooms[i] = null;
                this.countEmptyrooms++;
                return true;
            }
        }
        return false;
    }
}