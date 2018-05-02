using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ClinicDispatcher
{
    public IList<Pet> pets { get; set; }

    public IList<Clinic> clinics { get; set; }

    public ClinicDispatcher()
    {
        this.clinics = new List<Clinic>();
        this.pets = new List<Pet>();
    }


    public void Dispatch()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            try
            {
                var input = Console.ReadLine().Split();
                switch (input[0])
                {

                    case "Create":
                        var parameter = input[1];
                        if (parameter == "Clinic")
                        {
                            string clinicName = input[2];
                            int number = int.Parse(input[3]);
                            Clinic clinic = new Clinic(clinicName, number);
                            this.clinics.Add(clinic);
                        }
                        else
                        {
                            string petN = input[2];
                            int age = int.Parse(input[3]);
                            string kind = input[4];
                            Pet currentPet = new Pet(petN, age, kind);
                            this.pets.Add(currentPet);
                        }
                        break;
                    case "Print":
                        string name = input[1];
                        Clinic cl = this.clinics.First(a => a.Name == name);
                        if (input.Length == 3)
                        {
                            int num = int.Parse(input[2]);
                            cl.Print(num - 1);
                        }
                        else
                        {
                            cl.Print();
                        }
                        break;
                    case "Release":
                        name = input[1];
                        cl = this.clinics.First(a => a.Name == name);
                        Console.WriteLine(cl.Release());
                        break;
                    case "HasEmptyRooms":
                        name = input[1];
                        cl = this.clinics.First(a => a.Name == name);
                        Console.WriteLine(cl.HasEmptyRooms());
                        break;
                    case "Add":
                        name = input[2];
                        cl = this.clinics.First(a => a.Name == name);
                        string petName = input[1];
                        Pet pet = this.pets.First(p => p.Name == petName);
                        Console.WriteLine(cl.Add(pet));
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

        }


    }
}