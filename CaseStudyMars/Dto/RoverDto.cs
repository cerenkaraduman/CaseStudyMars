namespace CaseStudyMars
{
    public class RoverDto
    {
        public RoverDto()
        {
            Direction = new char[100];
        }
        public PositionDto Position { get; set; }
        public char[] Direction { get; set; }
    }
}
