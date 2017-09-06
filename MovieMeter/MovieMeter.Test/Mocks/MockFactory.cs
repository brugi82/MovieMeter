using MovieMeter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMeter.Test.Mocks
{
    public static class MockFactory
    {
        public static List<Program> GetPrograms()
        {
            return new List<Program>()
            {
                new Program()
                {
                    Id = "1",
                    Title = "Test 1",
                    ImdbRating = 5.7,
                    ImdbVotes = "12000"

                },
                new Program()
                {
                    Id = "2",
                    Title = "Test 2",
                    ImdbRating = 7.2,
                    ImdbVotes = "43000"

                },
                new Program()
                {
                    Id = "3",
                    Title = "Test 3",
                    ImdbRating = 3.4,
                    ImdbVotes = "39000"

                }
            };
        }

        public static List<Program> GetUpdatedPrograms()
        {
            return new List<Program>()
            {
                new Program()
                {
                    Id = "1",
                    Title = "Test 1",
                    ImdbRating = 6.0,
                    ImdbVotes = "15000"

                },
                new Program()
                {
                    Id = "2",
                    Title = "Test 2",
                    ImdbRating = 7.0,
                    ImdbVotes = "51000"

                },
                new Program()
                {
                    Id = "4",
                    Title = "Test 4",
                    ImdbRating = 9.1,
                    ImdbVotes = "187000"

                },
                new Program()
                {
                    Id = "5",
                    Title = "Test 5",
                    ImdbRating = 5.7,
                    ImdbVotes = "81000"

                }

            };
        }
    }
}
