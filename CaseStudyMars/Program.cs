using CaseStudyMars.Dto;
using System;
using System.Collections.Generic;

namespace CaseStudyMars
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsRoverService marsRoverService = new MarsRoverService(new Validator());

            Console.WriteLine("Upper-right coordinates of the plateau:");
            RectangleDto rectangle = marsRoverService.UpperRightCoordinates(Console.ReadLine().FormatInput());

            Console.WriteLine("Rover Count:");
            int roverCount = Console.ReadLine().FormatInput().ConvertInt();

            List<RoverDto> rovers = new List<RoverDto>();
            Console.WriteLine("Please type current coordinates and instruction for all of rovers");
            for (int i = 0; i < roverCount; i++)
            {
                RoverDto ro = new RoverDto();
                ro.StartedPosition = marsRoverService.StartedPosition(Console.ReadLine().FormatInput());
                ro.Direction = marsRoverService.NavigatedDirection(Console.ReadLine().FormatInput());

                rovers.Add(ro);
            }

            //List<Position> result = marsRoverService.CalculatePosition();
        }      
    }
}
