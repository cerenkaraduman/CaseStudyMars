using CaseStudyMars.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudyMars
{
    public class MarsRoverService
    {
        readonly Validator _validator;
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
                throw new ArgumentException("Invalid input. Wrong upper right coordinates.");
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
                throw new ArgumentException("Invalid input. Wrong initial position.");
            }

            return po;
        }
        public char[] GenerateInstruction(string variable)
        {
            char[] directions = variable.ToCharArray();

            if (!_validator.GenerateInstructionValidate(directions))
            {
                throw new ArgumentException("Invalid input. Wrong instructio.");
            }

            return directions;
        }
        public List<PositionDto> CalculatePosition(RectangleDto rectangle, List<RoverDto> rovers)
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

            return rovers.Select(i => i.Position).ToList();
        }
        private PositionDto Move(PositionDto position, List<RoverDto> rovers, RectangleDto rectangle)
        {
            int positionX = position.X;
            int positionY = position.Y;

            switch (position.Facing)
            {
                case ("N"):
                    positionY++;
                    break;
                case ("S"):
                    positionY--;
                    break;
                case ("E"):
                    positionX++;
                    break;
                default:
                    positionX--;
                    break;
            }

            if (_validator.MoveValidate(positionX, positionY, rovers, rectangle))
            {
                position.X = positionX;
                position.Y = positionY;
            }

            else
            {
                throw new ArgumentException("There is a rover in that position or that position isn't in the plateau.");
            }

            return position;
        }
        private PositionDto Rotate(PositionDto position, char direction)
        {
            string currentFacing = position.Facing;
            string nextFacting;

            if (direction == 'L')
            {
                nextFacting = SpinLeft(currentFacing);
            }

            else
            {
                nextFacting = SpinRight(currentFacing);
            }

            position.Facing = nextFacting;

            return position;
        }
        private string SpinLeft(string currentFacing)
        {
            string nextFacing;
            switch (currentFacing)
            {
                case ("N"):
                    nextFacing = "W";
                    break;
                case ("W"):
                    nextFacing = "S";
                    break;
                case ("S"):
                    nextFacing = "E";
                    break;
                default:
                    nextFacing = "N";
                    break;
            }

            return nextFacing;
        }
        private string SpinRight(string currentFacing)
        {
            string nextFacing;

            switch (currentFacing)
            {
                case ("N"):
                    nextFacing = "E";
                    break;
                case ("W"):
                    nextFacing = "N";
                    break;
                case ("S"):
                    nextFacing = "W";
                    break;
                default:
                    nextFacing = "S";
                    break;
            }

            return nextFacing;
        }
    }
}
