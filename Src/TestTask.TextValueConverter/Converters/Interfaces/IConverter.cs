namespace TestTask.TextValueConverter.Converters.Interfaces
{
    public interface IConverter
    {
        /// <summary>
        /// Possible input type sufixes (lowercase)
        /// </summary>
        string[] InputSufixes { get; }

        /// <summary>
        /// Output type sufix (lowercase)
        /// </summary>
        string OutputSufix { get; }

        /// <summary>
        /// Sipported SI prefixes list
        /// </summary>
        string[] SupportedSiPrefixes { get; }

        /// <summary>
        /// Extracts value from input string and converts it to coresponding type
        /// </summary>
        /// <param name="input">String which contains value and type sufix (lowercase)</param>
        /// <returns>String which contains converted result value and sufix</returns>
        string Invoke(string input);
    }
}
