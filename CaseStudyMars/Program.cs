using CaseStudyMars.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudyMars
{
    class Program
    {
        static void Main()
        {
            MarsRoverService marsRoverService = new MarsRoverService(new Validator());

            Console.WriteLine("Upper-right coordinates of the plateau:");
            RectangleDto rectangle = marsRoverService.GenerateUpperRightCoordinates(Console.ReadLine().FormatString());

            Console.WriteLine("Rover Count:");
            int roverCount = Console.ReadLine().FormatString().ConvertInt();

            List<RoverDto> rovers = new List<RoverDto>();
            Console.WriteLine("Please type current coordinates and instruction for all of rovers");
            for (int i = 0; i < roverCount; i++)
            {
                RoverDto rover = new RoverDto();
                rover.Position = marsRoverService.GenerateInitialPosition(Console.ReadLine().FormatString());
                rover.Direction = marsRoverService.GenerateInstruction(Console.ReadLine().FormatString());

                rovers.Add(rover);
            }

            List<PositionDto> resultRovers = marsRoverService.CalculatePosition(rectangle,rovers);
            Console.WriteLine("\n");
            resultRovers.ForEach(i => Console.WriteLine($"{i.X } {i.Y} {i.Facing}"));
        }
      
    }
}
