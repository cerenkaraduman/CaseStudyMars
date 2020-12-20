namespace CaseStudyMars
{
    public class Validator
    {
        public bool UpperRightCoordinatesValidate(string[] coordinates)
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
        public bool StartedPositionValidate(string[] positions)
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
        public bool InstructionValidate(char[] directions)
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

    }
}
