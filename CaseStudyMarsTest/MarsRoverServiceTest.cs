using CaseStudyMars;
using CaseStudyMars.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CaseStudyMarsTest
{
    [TestClass]
    public class MarsRoverServiceTest
    {
        public MarsRoverService _marsRoverService;
        public Validator _validator;

        [TestInitialize]
        public void Initialize()
        {
            _validator = new Validator();
            _marsRoverService = new MarsRoverService(_validator);
        }

        [TestMethod]
        public void GenerateUpperRightCoordinates_Valid_Success()
        {

            RectangleDto result = _marsRoverService.GenerateUpperRightCoordinates("5 5");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateUpperRightCoordinates_InValid_ThrownException()
        {
             _marsRoverService.GenerateUpperRightCoordinates("Hatalı");
        }

        [TestMethod]
        public void GenerateInitialPosition_Valid_Success()
        {
            PositionDto result = _marsRoverService.GenerateInitialPosition("1 2 N");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInitialPosition_InValid_ThrownException()
        {
             _marsRoverService.GenerateInitialPosition("Hatalı");
        }

        [TestMethod]
        public void GenerateInstruction_Valid_Success()
        {

            char[] result = _marsRoverService.GenerateInstruction("MLRL");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateInstruction_InValid_ThrownException()
        {
             _marsRoverService.GenerateInstruction("Hatalı");
        }


        [TestMethod]
        public void CalculatePosition_Valid_Success()
        {
            RectangleDto rectangle = new RectangleDto() { X = 5, Y = 5 };
            List<RoverDto> rovers = new List<RoverDto>();

            RoverDto rover = new RoverDto()
            {
                Position = new PositionDto () { X  = 1, Y = 2 , Facing = "N" },
                Direction = new char[9] { 'L','M','L','M','L','M','L','M','M' }
            };
            rovers.Add(rover);

            rover = new RoverDto()
            {
                Position = new PositionDto() { X = 3, Y = 3, Facing = "E" },
                Direction = new char[10] { 'M', 'M', 'R', 'M', 'M', 'R', 'M', 'R', 'R', 'M' }
            };

            rovers.Add(rover);

            List<PositionDto> result = _marsRoverService.CalculatePosition(rectangle, rovers);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePosition_InValid_ThrownException()
        {
            RectangleDto rectangle = new RectangleDto() { X = 2, Y = 2 };
            List<RoverDto> rovers = new List<RoverDto>();

            RoverDto rover = new RoverDto()
            {
                Position = new PositionDto() { X = 1, Y = 2, Facing = "N" },
                Direction = new char[2] { 'M', 'M' }
            };
            rovers.Add(rover);

            _marsRoverService.CalculatePosition(rectangle, rovers);
        }
    }
}
