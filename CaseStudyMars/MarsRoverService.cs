using CaseStudyMars.Dto;
using System;
using System.Collections.Generic;

namespace CaseStudyMars
{
    public class MarsRoverService
    {
        Validator _validater = new Validator();
        public MarsRoverService(Validator validater)
        {
            _validater = validater;
        }
        public RectangleDto UpperRightCoordinates(string variable)
        {
            string[] coordinates = variable.Split(" ");
            RectangleDto rectangle = new RectangleDto();

            if (_validater.UpperRightCoordinatesValidate(coordinates))
            {
                 rectangle.X = coordinates[0].ConvertInt();
                 rectangle.Y = coordinates[1].ConvertInt();
            }

            else
            {
                Console.WriteLine("Invalid input. Wrong upper right coordinates.");
                Environment.Exit(0);
            }

            return rectangle;
        }
        public PositionDto StartedPosition(string position)
        {
            PositionDto po = new PositionDto();
            string[] positions = position.Split(" ");

            if (_validater.StartedPositionValidate(positions))
            {
                po.X = positions[0].ConvertInt();
                po.Y = positions[1].ConvertInt();
                po.Facing = positions[2];
            }

            else
            {
                Console.WriteLine("Invalid input. Wrong beginnig position.");
                Environment.Exit(0);
            }

            return po;
        }
        public char[] NavigatedDirection(string variable)
        {
            char[] directions = variable.ToCharArray();

            if (!_validater.InstructionValidate(directions))
            {
                Console.WriteLine("Invalid input. Wrong nagivated direction.");
                Environment.Exit(0);
            }

            return directions;
        }   
    }
}
