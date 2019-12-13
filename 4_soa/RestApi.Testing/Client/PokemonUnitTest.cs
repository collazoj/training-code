using System.Linq;
using RestApi.Client.Controllers;
using RestApi.Data;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Testing.Client
{
    public class PokemonUnitTest
    {
        [Fact]
        public void Test_GetAllPokemon()
        {
          //httpclient - use this to make a call to our service
          var sut = new PokemonController(new PokemonDbContext());
          var actual = sut.Get();         //actual is an IActionResult

          Assert.True(actual. >0);        //we want a list
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_GetPokemon(int id)
        {
          var sut = new PokemonController(new PokemonDbContext());
          var actual = sut.Get(id);

          Assert.False(string.IsNullOrWhiteSpace(actual.Name));
        }
    }
}
