using NUnit.Framework;
using SokobanCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.test
{
    [TestFixture]
    public class TestClass
    {

        Game _Game;
        Crate _Crate;

        [SetUp]
        public void TestSetup()
        {
            Maze maze = new Maze();
            Field tmpfield;
            Truck tmptruck;
            maze._Truck = new Truck();
            maze._FirstTile = new Wall();
            maze._Length++;
            maze._FirstTile._East = new Destination();
            maze._FirstTile._East._West = maze._FirstTile;
            maze._Length++;
            tmpfield = new Field();
            _Crate = new Crate();
            tmpfield._Movable = _Crate;
            tmpfield._Movable._Field = tmpfield;
            maze._FirstTile._East._East = tmpfield;
            maze._FirstTile._East._East._West = maze._FirstTile._East;
            maze._Length++;
            tmpfield = new Field();
            tmptruck = new Truck();
            tmpfield._Movable = tmptruck;
            maze._Truck = tmptruck;
            tmpfield._Movable._Field = tmpfield;
            maze._FirstTile._East._East._East = tmpfield;
            maze._FirstTile._East._East._East._West = maze._FirstTile._East._East;
            maze._Length++;
            maze._FirstTile._East._East._East._East = new Wall();
            maze._FirstTile._East._East._East._East._West = maze._FirstTile._East._East._East;
            maze._Length++;
            _Game = new Game(maze);
        }


        [Test]
        public void TestMoveOntoThis()
        {
            _Game._Maze._Truck.MoveWest();
            Assert.IsTrue(_Game._Maze._FirstTile._East._Movable == _Crate);
            Assert.IsTrue(_Game._Maze._FirstTile._East._East._Movable == _Game._Maze._Truck);
        }

        [Test]
        public void TestCreation()
        {
            Assert.IsTrue(_Game._Maze._Truck == _Game._Maze._FirstTile._East._East._East._Movable, "Ze zijn niet het zelfde");
        }
    }
}
