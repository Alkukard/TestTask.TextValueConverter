namespace TestTask.TextValueConverter
{
    public interface IValueConverter
    {
        /// <summary>
        /// Converts value from input test to mentioned output type
        /// </summary>
        /// <param name="inputText">Text to be converted which contains value and type</param>
        /// <param name="type">Type of value shoul be converted to</param>
        /// <returns></returns>
        string Convert(string inputText, string type);
    }
}
