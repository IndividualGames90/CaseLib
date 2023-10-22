using System.Collections.Generic;

namespace IndividualGames.CaseLib.UI
{
    public static class IncrementalIDMaker
    {
        private static Dictionary<string, int> idDictionary = new Dictionary<string, int>();

        public static int GenerateID(string input)
        {
            int id;
            if (!idDictionary.TryGetValue(input, out id))
            {
                id = input.GetHashCode();
                idDictionary.Add(input, id);
            }
            else
            {
                id++;
                idDictionary[input] = id;
            }
            return id;
        }
    }

}