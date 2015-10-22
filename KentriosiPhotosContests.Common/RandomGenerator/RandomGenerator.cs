namespace KentriosiPhotosContests.Common
{
    using System;
    using System.Text;

    public class RandomGenerator : IRandomGenerator
    {
        private readonly string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxvyz";

        private Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }
        /// <summary>
        /// Returns random string where the min and max length include the given value
        /// </summary>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public string RandomString(int minLength = 5, int maxLength = 50)
        {
            var result = new StringBuilder();
            var length = this.random.Next(minLength, maxLength + 1);
            for (int i = 0; i <= length; i++)
            {
                result.Append(Letters[this.random.Next(0, Letters.Length)]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Returns a random integer number inclusive the passed min and max value
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int RandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }
    }
}
