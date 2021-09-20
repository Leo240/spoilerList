using System;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public class Spoiler
    {
        private string StudioPattern { get; } = @"\[.*?\]";
        private string DatePattern { get; } = @"\d{4}-\d{2}-\d{2}";
        public string Studio { get; set; }
        public string Date { get; set; }
        public string ModelName { get; set; }
        public string SetName { get; set; }
        public string SpoilerTitle { get; set; }
        public string[] Links { get; set; }

        public Spoiler(string file, int samples)
        {
            Links = new string[samples];

            if (file.Contains(".zip"))
            {
                file = file.Replace(".zip", "");
            }

            SpoilerTitle = Path.GetFileName(file);

            Regex rgxStudio = new Regex(StudioPattern);
            Regex rgxDate = new Regex(DatePattern);

            string[] nameParts = Regex.Split(Path.GetFileName(file), " - ");

            if (nameParts.Length == 4)
            {
                Studio = nameParts[0];
                Date = nameParts[1];
                ModelName = nameParts[2];
                SetName = nameParts[3];
            }
            else if (nameParts.Length == 3)
            {
                Match matchStudio = rgxStudio.Match(Path.GetFileName(nameParts[0]));
                Match matchDate = rgxDate.Match(Path.GetFileName(nameParts[0]));

                Studio = matchStudio.Value;
                Date = matchDate.Value;

                ModelName = nameParts[1];
                SetName = nameParts[2];
            }

        }

    }
}
