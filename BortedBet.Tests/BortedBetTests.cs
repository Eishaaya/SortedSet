using System;
using AVL_Bush;
using Xunit;

namespace BortedBet.Tests
{
    public class BortedBetTests
    {
        AVL_Bush.BoardedBets<int> bet;
        public BortedBetTests()
        {
            bet = new BoardedBets<int>();
        }

        [Fact]
        public void EmptyBetHasZeroCount()
        {
            //idk what to do
            Assert.Equal(0, bet.Count);
        }
        [Fact]
        public void EmptyBetdoesnthavestuff()
        {
            Random randy = new Random();
            Assert.NotEqual(randy.Next(1, 100), bet.Count);
        }



        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(65)]
        //[InlineData(100)]
        //[InlineData(1000)]
        //[InlineData(10000)]
        //[InlineData(100000)]
        public void CountMatchesNumInserted(int count)
        {
            Random gen = new Random();

            for (int i = 0; i < count; i++)
            {
                bet.add(gen.Next());
            }

            Assert.Equal(count, bet.Count);
            
        }
    }
}
