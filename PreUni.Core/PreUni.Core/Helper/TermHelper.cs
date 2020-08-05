namespace PreUni.Core.Helper
{
    public static class TermHelper
    {
        public static string stringMakeTermFormatAndGet(string term)
        {
            if (int.TryParse(term, out int targetTerm))
            {
                term = "0" + targetTerm.ToString();
            }

            return term;
        }
    }
}