using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator_Zdjec
{
    public class FileSorter
    {
        // Properties:



        private List<ImageFile> files { get; set; }
        private IDictionary<string, List<ImageFile>> sortedImages { get; set; }
        private IDictionary<int, List<string>> gruppedKeys { get; set; }
        private Label statusLabel { get; set; }
        private ProgressBar progressBar { get; set; }
        private int currentTask { get; set; }
        private int numberOfTasks { get; set; }
        private MainVC mainVC { get; set; }
        private bool noErrors { get; set; }


        private bool isTheSameDay(DateTime date1, DateTime date2)
        {
            return (date1.Year == date2.Year && date1.DayOfYear == date2.DayOfYear);
        }


        private bool isYesterdayFromDate(DateTime date1, DateTime date2)
        {
            return (date1.Date.AddDays(1) == date2.Date);
        }


        private bool isTomorrowFromDate(DateTime date1, DateTime date2)
        {
            return (date1.Date.AddDays(-1) == date2.Date);
        }



        // Initiator:



        public FileSorter(List<string> paths, ref Label statusLabel, ref ProgressBar progressBar, MainVC mainVC)
        {
            this.noErrors = true;
            this.numberOfTasks = 2 + (paths.Count);
            if (mainVC.deleteAfterSorting == true) { this.numberOfTasks += paths.Count; }
            this.currentTask = 1;

            this.files = new List<ImageFile>();
            this.sortedImages = new Dictionary<string, List<ImageFile>>();
            this.statusLabel = statusLabel;
            this.progressBar = progressBar;
            this.mainVC = mainVC;
            this.progressBar.Maximum = this.numberOfTasks;

            updateProgressBar();
            prepareForSorting(paths);

            bool unmodified = checkIfImagesAreUnmodified();

            layoutImagesInDictionary(unmodified);
            groupImagesFromDictionary();
            prepareDirectoriesInDestinationAndCopyFiles(unmodified);

            if (mainVC.deleteAfterSorting == true && this.noErrors == true)
            {
                deleteSourceFiles();
            }


            this.mainVC.resetSelf();
        }



        private bool checkIfImagesAreUnmodified()
        {
            bool output = true;

            foreach (ImageFile file in files)
            {
                if (isTheSameDay(file.creationDate, file.modificationDate) == false)
                {
                    return false;
                }
            }

            return true;
        }



        private void updateCurrentTaskDescription(string description)
        {
            this.mainVC.taskLabel.Text = description;
        }



        private void updateProgressBar()
        {
            this.progressBar.Value = this.currentTask;
        }



        private void prepareForSorting(List<string> paths)
        {
            foreach (string path in paths)
            {
                string fileName = Path.GetFileName(path);
                var file = new ImageFile(path);
                this.files.Add(file);
            }
        }



        private void layoutImagesInDictionary(bool creation)
        {
            foreach (ImageFile file in this.files)
            {
                string fileName = Path.GetFileName(file.path);
                string key;

                if (creation == true) { key = file.creationDateString; }
                else { key = file.modificationDateString; }

                if (this.sortedImages.ContainsKey(key) == false)
                {
                    var list = new List<ImageFile>();
                    list.Add(file);
                    this.sortedImages.Add(key, list);
                }
                else
                {
                    this.sortedImages[key].Add(file);
                }
            }
        }



        private void groupImagesFromDictionary()
        {
            List<string> keysList = new List<string>();


            for (int i = 0; i < sortedImages.Count; i++)
            {
                string key = sortedImages.ElementAt(i).Key;
                System.Diagnostics.Debug.WriteLine($"Working on key: {key}");
                DateTime date = DateTime.ParseExact(key, "MM/dd/yyyy", null);
                string newKey = date.ToString("yyyy-MM-dd");


                if (!keysList.Contains(newKey))
                {
                    keysList.Add(newKey);
                    System.Diagnostics.Debug.WriteLine($"New key added: {newKey}");
                }
            }


            keysList.Sort((x, y) => DateTime.ParseExact(x, "yyyy-MM-dd", null).CompareTo(DateTime.ParseExact(y, "yyyy-MM-dd", null)));


            DateTime previousDate = DateTime.ParseExact(keysList[0], "yyyy-MM-dd", null);
            IDictionary<int, List<string>> newKeys = new Dictionary<int, List<string>>();
            int j = 0;


            foreach (string k in keysList)
            {
                DateTime date = DateTime.ParseExact(k, "yyyy-MM-dd", null);

                if (isTheSameDay(date, previousDate))
                {
                    List<string> list = new List<string>();
                    list.Add(k);
                    newKeys.Add(j, list);
                }
                else if (isTomorrowFromDate(date, previousDate))
                {
                    newKeys[j].Add(k);
                }
                else
                {
                    j += 1;
                    List<string> list = new List<string>();
                    list.Add(k);
                    newKeys.Add(j, list);
                }
            }


            this.gruppedKeys = newKeys;
        }



        private void prepareDirectoriesInDestinationAndCopyFiles(bool creation)
        {
            for (int z = 0; z < this.gruppedKeys.Count; z++)
            {
                List<string> keys = this.gruppedKeys.ElementAt(z).Value;
                string directoryName;

                if (keys.Count > 1)
                {
                    directoryName = $"{keys[0]} do {keys[keys.Count - 1]}";
                }
                else
                {
                    directoryName = $"{keys[0]}";
                }


                var path = Path.Combine(mainVC.destinationDirectory, directoryName);


                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                foreach (ImageFile file in files)
                {
                    foreach (string key in keys)
                    {
                        if (creation == true)
                        {
                            if (file.creationDate.ToString("yyyy-MM-dd") == key)
                            {
                                var filePath = Path.Combine(path, Path.GetFileName(file.path));

                                try
                                {
                                    File.Copy(file.path, filePath, true);
                                }
                                catch (IOException iox)
                                {
                                    MessageBox.Show(iox.Message);
                                    this.noErrors = false;
                                }

                                this.currentTask += 1;
                                updateCurrentTaskDescription($"Kopiowanie pliku {Path.GetFileName(file.path)}");
                                updateProgressBar();
                            }
                        }
                        else
                        {
                            if (file.modificationDate.ToString("yyyy-MM-dd") == key)
                            {
                                var filePath = Path.Combine(path, Path.GetFileName(file.path));

                                try
                                {
                                    File.Copy(file.path, filePath, true);
                                }
                                catch (IOException iox)
                                {
                                    MessageBox.Show(iox.Message);
                                    this.noErrors = false;
                                }

                                this.currentTask += 1;
                                updateCurrentTaskDescription($"Kopiowanie pliku {Path.GetFileName(file.path)}");
                                updateProgressBar();
                            }
                        }                        
                    }
                }
            }
        }



        private void deleteSourceFiles()
        {
            foreach (ImageFile file in files)
            {
                if (File.Exists(file.path))
                {
                    File.Delete(file.path);
                    this.currentTask += 1;
                    updateCurrentTaskDescription($"Usuwanie pliku {Path.GetFileName(file.path)}");
                    updateProgressBar();
                }
            }
        }
    }
}
