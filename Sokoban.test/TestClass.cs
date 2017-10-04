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
            maze._FirstTile._East = new Destination(null);
            maze._FirstTile._East._West = maze._FirstTile;
            maze._Length++;
            tmpfield = new Field(null);
            _Crate = new Crate();
            maze.crates.Add(_Crate);
            tmpfield._Movable = _Crate;
            tmpfield._Movable._Field = tmpfield;
            maze._FirstTile._East._East = tmpfield;
            maze._FirstTile._East._East._West = maze._FirstTile._East;
            maze._Length++;
            tmpfield = new Field(null);
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
            maze._AmountOfDestinations = 1;
        }


        [Test]
        public void TestMoveOntoThis()
        {
            _Game._Maze._Truck.MoveWest();
            Field tmp = (Field) _Game._Maze._FirstTile._East;
            Assert.IsTrue(tmp._Movable == _Crate);
            tmp = (Field)_Game._Maze._FirstTile._East._East;
            Assert.IsTrue(tmp._Movable == _Game._Maze._Truck);
        }

        [Test]
        public void TestCreation()
        {
            Field tmp = (Field)_Game._Maze._FirstTile._East._East._East;
            Assert.IsTrue(_Game._Maze._Truck == tmp._Movable, "Ze zijn niet het zelfde");
        }

        [Test]
        public void TestTruckWon()
        {
            Assert.IsTrue(!_Game.CheckTruckWon());
            _Game._Maze._Truck.MoveWest();
            Assert.IsTrue(_Game.CheckTruckWon());
        }
    }
}
