using Xunit;

namespace GameOfLife.Tests
{
    public class GameTests
    {
        [Fact]
        private void LiveCellWithLessThan2NeighboursDies()
        {
            var grid = new GameGrid(3,3);
            grid.SetCellAliveAtCoords(new[]{2,1},true);
            grid.SetCellAliveAtCoords(new[]{2,2},true);
            
            //.#.
            //.#.
            //...
            var game = new Game(grid);
            game.ProgressTime();

            var expected = 
                "...\n" + 
                "...\n" +
                "...\n";

            var actual = Output.GridState(grid);
            
            Assert.Equal(expected, actual);
        }
        

        
        [Fact]
        private void LiveCellWithTwoOrThreeLivesNeighboursStaysAlive()
        {
            var grid = new GameGrid(3,3);
            
            //##.
            //##.
            //...
            grid.SetCellAliveAtCoords(new[]{1,1},true);
            grid.SetCellAliveAtCoords(new[]{1,2},true);
            grid.SetCellAliveAtCoords(new[]{2,1},true);
            grid.SetCellAliveAtCoords(new[]{2,2},true);
            
            var game = new Game(grid);
            game.ProgressTime();
            var expected = 
                "##.\n" + 
                "##.\n" +
                "...\n";

            var actual = Output.GridState(grid);
            
            Assert.Equal(expected, actual);
        }
        // [Fact]
        // private void DeadCellWithThreeLivesNeighboursBecomesAlive()
        // {
        //     var grid = new GameGrid(3,3);
        //     
        //     //.#.
        //     //.#.
        //     //.#.
        //     grid.SetCellAliveAtCoords(new[]{2,1},true);
        //     grid.SetCellAliveAtCoords(new[]{2,2},true);
        //     grid.SetCellAliveAtCoords(new[]{2,3},true);
        //     
        //     var game = new Game(grid);
        //     game.ProgressTime();
        //
        //     var expected = 
        //         "...\n" + 
        //         "###\n" +
        //         "...\n";
        //
        //     var actual = Output.GridState(grid);
        //     
        //     Assert.Equal(expected, actual);
        // }
    }
    
}