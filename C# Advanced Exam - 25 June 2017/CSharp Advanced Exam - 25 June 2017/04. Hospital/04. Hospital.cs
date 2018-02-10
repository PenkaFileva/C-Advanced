using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();
            var input = Console.ReadLine();

            while (input != "Output")
            {
                var tokens = input.Split(' ');
                var department = tokens[0];
                var firstNameDoctor = tokens[1];
                var lastNameDoctor = tokens[2];
                var patient = tokens[3];
                var doctor = firstNameDoctor + " " + lastNameDoctor;

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<string>();
                }
                departments[department].Add(patient);

                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }
                doctors[doctor].Add(patient);

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                var commands = input.Split(' ');
                if (commands.Length == 1)
                {
                    var currentDepartment = commands[0];
                    var numPatients = departments[currentDepartment].ToList();
                    Console.WriteLine(string.Join(Environment.NewLine, numPatients));
                }
                else
                {
                    bool room = int.TryParse(commands[1], out int result);
                    if (room)
                    {
                        var currentDepartment = commands[0];
                        var currentRoom = int.Parse(commands[1]);
                        var patients = departments[currentDepartment].Skip(currentRoom * 3 - 3).Take(3).ToArray();
                        foreach (var item in patients.OrderBy(x => x))
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        var currentFirstName = commands[0];
                        var currenrLastName = commands[1];
                        var nameDoctor = currentFirstName + " " + currenrLastName;
                        var namesPatient = doctors[nameDoctor].OrderBy(x => x);
                        foreach (var item in namesPatient)
                        {
                            Console.WriteLine(item);
                        }
                    }
                 
                }
                input = Console.ReadLine();
            }
        }
    }
}
