namespace CG.Common.RandomGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using CG.Common.RandomGenerator.DTO;

    using Newtonsoft.Json;

    public class RandomOMXDataGenerator : IRandomOMXDataGenerator
    {
        private Random rnd;

        public RandomOMXDataGenerator()
        {
            this.rnd = new Random();    
        }

        public IList<string> GenerateRandomData(string fileLocation)
        {
            var currentDirectory = DirectoryLocator.GetCurrentDirectory(fileLocation);
            
            var json = File.ReadAllText(currentDirectory);

            var jsonObjects = JsonConvert.DeserializeObject<ObjectStructureDTO[]>(json);
            var categoryNames = new List<string>();
            foreach (var jsonObject in jsonObjects)
            {
                categoryNames.Add(jsonObject.Title);
            }
            return categoryNames;
        }

        public int GenerateRandomNumber(int min, int max)
        {
            return this.rnd.Next(min, max + 1);
        }
    }
}