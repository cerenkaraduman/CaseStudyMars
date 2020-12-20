namespace CaseStudyMars
{
    public class RoverDto
    {
        public RoverDto()
        {
            Direction = new char[100];
        }
        public PositionDto StartedPosition { get; set; }
        public char[] Direction { get; set; }
    }
}
