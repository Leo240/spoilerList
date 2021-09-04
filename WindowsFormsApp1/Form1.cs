using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Resources;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string updateFolder = "";
        ProgressDialogBox pdb1;

        private int SamplesPerSpoiler { get; set; } = 1;
        public List<string> SetFolders { get; set; } = new List<string>();
        public List<string> SetArchives { get; set; } = new List<string>();

        public Form1()
        {            
            InitializeComponent();
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop);
                Array.Sort(fileList, new NaturalStringComparer());
                string studioPattern = @"\[.*?\]";
                string datePattern = @"\d{4}-\d{2}-\d{2}";

                Spoiler spoiler = new Spoiler();

                foreach(string file in fileList)
                {
                    Regex rgxStudio = new Regex(studioPattern);
                    Regex rgxDate = new Regex(datePattern);

                    Match matchStudio = rgxStudio.Match(file.Substring(0));
                    Match matchDate = rgxDate.Match(file);

                    spoiler.SetName = matchStudio.Value;
                    spoiler.Date = matchDate.Value;
                    Console.WriteLine(spoiler.SetName + " " + spoiler.Date);
                }

                
                
                if (dataGridView1.Rows.Count < fileList.Length)
                {
                    dataGridView1.Rows.Add(fileList.Length - dataGridView1.Rows.Count);                    
                }                
                
                for (int i = 0; i < fileList.Length; i++)
                {                                        
                    dataGridView1.Rows[i].Cells[0].Value = Path.GetFileName(fileList[i]);
                    dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }
            }           
        }

        private void btnInsertLinks_Click(object sender, EventArgs e)
        {
            string input = Clipboard.GetText().Trim(' ');
            List<string> links = new List<string>();

            string linkPattern = @"((?i)\[url=.*?\]\[img\].*?\[\/url\](?-i))";
            Regex rgx = new Regex(linkPattern);

            foreach (Match m in rgx.Matches(input))
            {                
                links.Add(m.Value);
            }
                        
            if (dataGridView1.Rows.Count < links.Count)
            {
                dataGridView1.Rows.Add(links.Count - dataGridView1.Rows.Count);
            }

            for (int i = 0; i < links.Count; i++)
            {
                dataGridView1.Rows[i].Cells[1].Value = links[i];
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void btnApplyPattern_Click(object sender, EventArgs e)
        {
            string column1 = "";
            string column2 = "";
            string output = "";
            int i;
            int j=0;

            if (dataGridView1.Columns[1] != null)
            {
                for (i = 0; i < dataGridView1.RowCount; i++)
                {
                    if((string)dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        column1 += dataGridView1.Rows[i].Cells[0].Value + "|";
                    }

                    if ((string)dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        column2 += dataGridView1.Rows[i].Cells[1].Value + "|";
                    }
                }

                string[] setNames = column1.Split('|');   
                string[] links = column2.Split('|');

                for (i = 0; i < setNames.Length - 1; i++)
                {
                    string pattern = tbPattern.Text;
                    int k = 0;

                    if(links[0] == "")
                    {
                        MessageBox.Show(Properties.Resources.MsgNoLinks);
                        break;
                    }
                    else if (j < links.Length)
                    {
                        pattern = pattern.Replace(@"[name]", setNames[i]);
                        while (pattern.Contains($"[link{k}]"))
                        {
                            try
                            {
                                pattern = pattern.Replace($"[link{k}]", links[j]);
                            }
                            catch(System.IndexOutOfRangeException)
                            {
                                pattern = pattern.Replace($"[link{k}]", "");
                            }
                            
                            k++;
                            j++;
                        }
                        
                        output += pattern;
                    }
                    else
                    {
                        break;
                    } 
                }
            }

            Console.WriteLine("Значение из метода - " + j.ToString());

            tbOutput.Text = output;
        }

        private void btnCreateSamples_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (SetFolders.Count != 0)
                {
                    CopyFilesWithProgress();

                    using (pdb1 = new ProgressDialogBox())
                    {
                        pdb1.Owner = this;
                        pdb1.lblMaximum.Text = SetFolders.Count.ToString();
                        pdb1.progressBar1.Minimum = 1;
                        pdb1.progressBar1.Maximum = SetFolders.Count * SamplesPerSpoiler;

                        pdb1.ShowDialog();
                    }                    
                }
                else if (SetArchives.Count != 0)
                {
                    CopyArchivesWithProgress();

                    using (pdb1 = new ProgressDialogBox())
                    {
                        pdb1.Owner = this;
                        pdb1.lblMaximum.Text = SetArchives.Count.ToString();
                        pdb1.progressBar1.Minimum = 1;
                        pdb1.progressBar1.Maximum = SetArchives.Count * SamplesPerSpoiler;

                        pdb1.ShowDialog();
                    }
                }
            }            
        }

        private void btnChooseSource_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                SetFolders.Clear();
                SetArchives.Clear();
                updateFolder = Path.GetDirectoryName(openFileDialog1.FileName);

                if(Directory.GetDirectories(updateFolder).Length != 0)
                {
                    SetFolders.AddRange(Directory.GetDirectories(updateFolder));

                    Console.WriteLine($"Всего папок: {SetFolders.Count}");
                } 
                else if(Directory.GetFiles(updateFolder, "*.zip").Length != 0)
                {
                    SetArchives.AddRange(Directory.GetFiles(updateFolder, "*.zip"));

                    Console.WriteLine($"Всего архивов: {SetArchives.Count}");
                    Console.WriteLine($"Имя архива: {SetArchives.ElementAt<string>(0)}");
                }
                else
                {
                    MessageBox.Show("Папки с фотосетами не найдены. \r\n Попробуйте подняться на уровень выше.");
                }
            }
            
        }

        private void btnApplyPatternOptions_Click(object sender, EventArgs e)
        {
            string pattern = "[spoiler=\"[name]\"][/spoiler]";
            string links = "";

            if(tbImagesPerSpoiler.Text != "")
            {
                SamplesPerSpoiler = int.Parse(tbImagesPerSpoiler.Text);

                for (int i = 0; i < int.Parse(tbImagesPerSpoiler.Text); i++)
                {
                    links += $@"[link{i}]";
                }
            }
            else
            {
                MessageBox.Show("Укажите количество примеров!");
            }
            
            tbPattern.Text = pattern.Replace(@"][/", $@"]{links}[/");
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string input = tbOutput.Text;
            string result = "";
            string pattern = @"(?i)(\[spoiler=.*?\[url=.*?].*?\[\/img]\[\/url]\[\/spoiler])(?-i)";
            
            var spoilers = Regex.Matches(input, pattern).Cast<Match>().Select(m => m.Value).ToArray();
                        
            Array.Sort(spoilers, new NaturalStringComparer());

            tbOutput.Text = "";

            foreach(string spoiler in spoilers)
            {
                result += spoiler;
            }

            tbOutput.Text = result;
        }
        
        private async void CopyFilesWithProgress()
        {                          
            string resultFolder = folderBrowserDialog1.SelectedPath;
            
            if (!resultFolder.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            {
                resultFolder += Path.DirectorySeparatorChar;
            }

            foreach (string setFolder in SetFolders)
            {
                string[] files = Directory.GetFiles(setFolder);
                
                //Console.WriteLine(GetImageDimensions(files).Select(o => o.Height).Distinct().Min().ToString());
                                
                List<int> uniqueImages = new List<int>();
                uniqueImages = FindUniqueSamples(files);

                for (int i = 0; i < SamplesPerSpoiler; i++)
                {
                    if (files.Length != 0)
                    {
                        using (FileStream SourceStream = File.Open(files[uniqueImages[i]], FileMode.Open))
                        {
                            using (FileStream DestinationStream = File.Create(resultFolder + Path.GetFileName(setFolder) + "_" + i.ToString() + ".jpg"))
                            {
                                await SourceStream.CopyToAsync(DestinationStream);
                            }
                        }
                    }      
                        
                    if(pdb1.Visible == true)
                    {
                        pdb1.lblMaximum.Visible = true;
                        if (pdb1.progressBar1.Value < SetFolders.Count * SamplesPerSpoiler)
                        {
                            pdb1.progressBar1.Value += 1;
                            pdb1.lblMaximum.Text = $"{pdb1.progressBar1.Value} из {pdb1.progressBar1.Maximum}";
                        }
                    }      
                }
            }
            pdb1.Close();
            
        }

        private async void CopyArchivesWithProgress()
        {
            string resultFolder = folderBrowserDialog1.SelectedPath;
                
            if (!resultFolder.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            {
                resultFolder += Path.DirectorySeparatorChar;
            }
            foreach (string setArchive in SetArchives)
            {
                using (ZipArchive archive = ZipFile.OpenRead(setArchive))
                {
                    ZipArchiveEntry[] zipArchiveEntries = archive.Entries.ToArray();
                    List<int> uniqueImages = new List<int>();
                    uniqueImages = FindUniqueSamples(zipArchiveEntries);

                    for (int i = 0; i < SamplesPerSpoiler; i++)
                    {
                        if (zipArchiveEntries[uniqueImages[i]].FullName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                            || zipArchiveEntries[uniqueImages[i]].FullName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                        {
                            string destinationPath = Path.GetFullPath(Path.Combine(resultFolder, Path.GetFileName(setArchive) + "_" + i.ToString() + ".jpg"));

                            if (destinationPath.StartsWith(resultFolder, StringComparison.Ordinal))
                            {
                                await Task.Run(() => zipArchiveEntries[uniqueImages[i]].ExtractToFile(destinationPath, true));
                            }
                        }
                            
                        if (pdb1.Visible == true)
                        {
                            pdb1.lblMaximum.Visible = true;
                            if (pdb1.progressBar1.Value < SetArchives.Count * SamplesPerSpoiler)
                            {
                                pdb1.progressBar1.Value += 1;
                                pdb1.lblMaximum.Text = $"{pdb1.progressBar1.Value} {Properties.Resources.Of} {pdb1.progressBar1.Maximum}";
                            }
                        }
                    }
                }
            }

            pdb1.Close();              
                        
        }

        public List<int> FindUniqueSamples(string[] source)
        {
            var rand = new Random();
            List<int> uniqueImages = new List<int>();
            HashSet<int> uniqueIndexes = new HashSet<int>();

            while (uniqueIndexes.Count < SamplesPerSpoiler)
            {
                int item = rand.Next(source.Length);
                if (!uniqueIndexes.Contains(item))
                {
                    uniqueIndexes.Add(item);
                }
                else
                {
                    item = rand.Next(source.Length);
                    uniqueIndexes.Add(item);
                }
            }
            uniqueImages.AddRange(uniqueIndexes);
            uniqueImages.Sort();

            return uniqueImages;
        }

        public List<int> FindUniqueSamples(ZipArchiveEntry[] source)
        {
            var rand = new Random();
            List<int> uniqueImages = new List<int>();
            HashSet<int> uniqueIndexes = new HashSet<int>();

            while (uniqueIndexes.Count < SamplesPerSpoiler)
            {
                int item = rand.Next(source.Length);
                if (!uniqueIndexes.Contains(item))
                {
                    uniqueIndexes.Add(item);
                }
                else
                {
                    item = rand.Next(source.Length);
                    uniqueIndexes.Add(item);
                }
            }
            uniqueImages.AddRange(uniqueIndexes);
            uniqueImages.Sort();

            return uniqueImages;
        }

        public  List<Image> GetImageDimensions(string[] imageLinks)
        {
            List<Image> images = new List<Image>();

            foreach(string imageLink in imageLinks)
            {
                using(FileStream SourceStream = File.Open(imageLink,FileMode.Open))
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(SourceStream, false, false))
                    {
                        Image image = new Image(imageLink, img.Height);
                        images.Add(image);
                    }
                }                                  
            }
            //images.Select(i => i.Name).Where(images)/*.Select(i => i.Height).Distinct().Min()*/;
            return images;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {

            }
        }
    }
}