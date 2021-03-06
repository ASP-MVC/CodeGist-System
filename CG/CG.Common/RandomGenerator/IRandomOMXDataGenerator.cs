﻿namespace CG.Common.RandomGenerator
{
    using System.Collections.Generic;

    public interface IRandomOMXDataGenerator
    {
        IList<string> GenerateRandomData(string fileLocation);

        int GenerateRandomNumber(int min, int max);
    }
}