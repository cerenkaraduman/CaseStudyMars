using CaseStudyMars.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudyMars
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsRoverService marsRoverService = new MarsRoverService(new Validator());

            Console.WriteLine("Upper-right coordinates of the plateau:");
            RectangleDto rectangle = marsRoverService.GenerateUpperRightCoordinates(Console.ReadLine().FormatInput());

            Console.WriteLine("Rover Count:");
            int roverCount = Console.ReadLine().FormatInput().ConvertInt();

            List<RoverDto> rovers = new List<RoverDto>();
            Console.WriteLine("Please type current coordinates and instruction for all of rovers");
            for (int i = 0; i < roverCount; i++)
            {
                RoverDto rover = new RoverDto();
                rover.Position = marsRoverService.GenerateInitialPosition(Console.ReadLine().FormatInput());
                rover.Direction = marsRoverService.GenerateInstruction(Console.ReadLine().FormatInput());

                rovers.Add(rover);
            }

            List<RoverDto> resultRovers = marsRoverService.CalculatePosition(rectangle,rovers);
            Console.WriteLine("\n");
            resultRovers.Select(j=> j.Position).ToList().ForEach(i => Console.WriteLine($"{i.X } {i.Y} {i.Facing}"));
        }
      
    }
}
