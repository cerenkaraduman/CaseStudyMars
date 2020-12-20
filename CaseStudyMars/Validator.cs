using CaseStudyMars.Dto;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudyMars
{
    public class Validator
    {
        public bool GenerateUpperRightCoordinatesValidate(string[] coordinates)
        {
            bool validateResult = true;
            if (coordinates.Length != Constants.UpperRightPositionLength)
            {
                validateResult = false;
            }

            if (!(coordinates[0].IsInt() || coordinates[1].IsInt()))
            {
                validateResult = false;
            }

            return validateResult;
        }
        public bool GenerateInitialPositionValidate(string[] positions)
        {
            bool validateResult = true;
            int length = positions.Length;
            if (length != Constants.InitialPositionLength)
            {
                validateResult = false;
            }

            for (int i = 0; i < length && validateResult; i++)
            {
                var value = positions[i];

                if (i == length - 1)
                {
                    validateResult = Constants.Direction.Contains(value);
                }

                else
                {
                    validateResult = value.IsInt();
                }
            }

            return validateResult;
        }
        public bool GenerateInstructionValidate(char[] directions)
        {
            bool validateResult = true;

            if (directions.Length == 0)
            {
                validateResult = false;
            }

            for (int i = 0; i < directions.Length && validateResult; i++)
            {
                validateResult = Constants.Instruction.Contains(directions[i].ToString());
            }

            return validateResult;
        }
        public bool MoveValidate(int positionX, int positionY, List<RoverDto> rovers, RectangleDto rectangle)
        {
            bool validateResult = IsThereAnyRoversValidate(positionX, positionY, rovers);

            if (validateResult)
            {
                validateResult = IsCoordinateInThePlateauValidate(positionX, positionY, rectangle);
            };

            return validateResult;
        }
        public bool IsThereAnyRoversValidate(int positionX, int positionY, List<RoverDto> rovers)
        {
            return !rovers.Any(i => i.Position.X == positionX && i.Position.Y == positionY);
        }
        public bool IsCoordinateInThePlateauValidate(int positionX, int positionY, RectangleDto rectangle)
        {
            return !(positionX > rectangle.X || positionY > rectangle.Y || positionX < 0 || positionY <0);
        }
    }
}
