using CaseStudyMars.Dto;
using System;
using System.Collections.Generic;

namespace CaseStudyMars
{
    public class MarsRoverService
    {
        Validator _validator = new Validator();
        public MarsRoverService(Validator validator)
        {
            _validator = validator;
        }
        public RectangleDto GenerateUpperRightCoordinates(string variable)
        {
            string[] coordinates = variable.Split(" ");
            RectangleDto rectangle = new RectangleDto();

            if (_validator.GenerateUpperRightCoordinatesValidate(coordinates))
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
        public PositionDto GenerateInitialPosition(string position)
        {
            PositionDto po = new PositionDto();
            string[] positions = position.Split(" ");

            if (_validator.GenerateInitialPositionValidate(positions))
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
        public char[] GenerateInstruction(string variable)
        {
            char[] directions = variable.ToCharArray();

            if (!_validator.GenerateInstructionValidate(directions))
            {
                Console.WriteLine("Invalid input. Wrong nagivated direction.");
                Environment.Exit(0);
            }

            return directions;
        }
        public List<RoverDto> CalculatePosition(RectangleDto rectangle, List<RoverDto> rovers)
        {
            foreach (var rover in rovers)
            {
                foreach (var direction in rover.Direction)
                {
                    switch (direction)
                    {
                        case ('M'):
                            Move(rover.Position, rovers, rectangle);
                            break;

                        default:
                            Rotate(rover.Position, direction);
                            break;
                    }
                }
            }

            return rovers;
        }
        private PositionDto Move(PositionDto position, List<RoverDto> rovers, RectangleDto rectangle)
        {
            int positionX = position.X;
            int positionY = position.Y;

            if (position.Facing == "N")
            {
                positionY++;
            }

            else if (position.Facing == "S")
            {
                positionY--;
            }

            else if (position.Facing == "E")
            {
                positionX++;
            }

            else
            {
                positionX--;
            }

            if (_validator.MoveValidate(positionX, positionY, rovers, rectangle))
            {
                position.X = positionX;
                position.Y = positionY;
            }

            else
            {
                Console.WriteLine("There is a rover in that position or that position isn't in the plateau.");
                Environment.Exit(0);
            }

            return position;
        }
        private PositionDto Rotate(PositionDto position, char direction)
        {
            string currentFacing = position.Facing;

            if (direction == 'L')
            {
                switch (currentFacing)
                {
                    case ("N"):
                        position.Facing = "W";
                        break;
                    case ("W"):
                        position.Facing = "S";
                        break;
                    case ("S"):
                        position.Facing = "E";
                        break;
                    default:
                        position.Facing = "N";
                        break;
                }
            }

            else
            {
                switch (currentFacing)
                {
                    case ("N"):
                        position.Facing = "E";
                        break;
                    case ("W"):
                        position.Facing = "N";
                        break;
                    case ("S"):
                        position.Facing = "W";
                        break;
                    default:
                        position.Facing = "S";
                        break;
                }
            }

            return position;
        }
    }
}
