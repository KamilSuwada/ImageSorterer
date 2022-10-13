using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Organizator_Zdjec
{
    public partial class MainVC : Form
    {
        // Properties:



        public string sourceDirectory { get; set; }
        public string destinationDirectory { get; set; }
        public bool deleteAfterSorting { get; set; }
        public int numberOfPictures { get; set; }
        public List<string> filesToSort { get; set;}
        public Label taskLabel
        {
            get
            {
                return this.currentTaskLabel;
            }
        }


        // Initialiser:



        public MainVC()
        {
            InitializeComponent();

            initialSetup();
        }



        public void initialSetup()
        {
            this.sourceDirectory = null;
            this.destinationDirectory = null;
            this.filesToSort = null;

            this.currentTaskLabel.Visible = false;
            this.progressBar.Value = 0;
            this.progressBar.Minimum = 0;
            this.progressBar.Visible = false;

            this.sourceFolderTextBox.Text = "";
            this.destinationFolderTextBox.Text = "";
        }



        public void resetSelf()
        {
            this.sourceDirectory = null;
            this.destinationDirectory = null;
            this.deleteAfterSorting = false;
            this.numberOfPictures = 0;
            this.filesToSort = null;

            this.sourceFolderTextBox.Text = null;
            this.destinationFolderTextBox.Text = null;
            this.currentTaskLabel.Text = null;

            this.deleteDestinationImagesCheckBox.CheckState = CheckState.Unchecked;

            this.currentTaskLabel.Visible = false;
            this.progressBar.Value = 0;
            this.progressBar.Visible = false;

            this.sourceButton.Visible = true;
            this.sourceButton.Enabled = true;
            this.destinationButton.Visible = true;
            this.destinationButton.Enabled = true;
            this.sortButton.Visible = true;
            this.sortButton.Enabled = true;

            this.sourceLabel.Visible = true;
            this.destinationLabel.Visible = true;

            this.deleteDestinationImagesCheckBox.Visible = true;
            this.deleteDestinationImagesCheckBox.Enabled = true;
        }



        // Delegate methods:



        private void deleteDestinationImagesCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (deleteDestinationImagesCheckBox.CheckState == CheckState.Checked) { this.deleteAfterSorting = true; }
            else { deleteAfterSorting = false; }
        }



        // Buttons:



        private void sourceButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    List<string> filesToBeSorted = Directory.GetFiles(fbd.SelectedPath).ToList<string>();

                    this.sourceFolderTextBox.Text = fbd.SelectedPath;
                    this.sourceDirectory = fbd.SelectedPath;
                    this.numberOfPictures = filesToBeSorted.Count;
                    this.filesToSort = filesToBeSorted;

                    MessageBox.Show("Znaleziono plikow do sortowania: " + filesToBeSorted.Count.ToString(), "Informacja");
                }
            }
        }



        private void destinationButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    List<string> filesToBeSorted = Directory.GetFiles(fbd.SelectedPath).ToList<string>();

                    this.destinationFolderTextBox.Text = fbd.SelectedPath;
                    this.destinationDirectory = fbd.SelectedPath;
                }
            }
        }



        private void sortButton_Click(object sender, EventArgs e)
        {
            if (this.sourceDirectory == null) { return; }
            if (this.destinationDirectory == null) { return; }
            if (this.numberOfPictures < 1) { return; }

            if (this.deleteAfterSorting == true)
            {
                DialogResult dialogResult = MessageBox.Show("Wybrano opcje usuniecia plikow zrodlowych po zakonczeniu operacji, czy napewno chcesz kontynuowac? Zalecam usuwac pliki samemu po sortowaniu.", "Czy napewno?", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.Cancel) { return; }
            }

            this.currentTaskLabel.Text = "Przygotowanie do sortowania rozpoczete...";
            this.currentTaskLabel.Visible = true;
            this.progressBar.Visible = true;

            this.sourceButton.Visible = false;
            this.sourceButton.Enabled = false;
            this.destinationButton.Visible = false;
            this.destinationButton.Enabled = false;
            this.sortButton.Visible = false;
            this.sortButton.Enabled = false;

            this.sourceLabel.Visible = false;
            this.destinationLabel.Visible = false;

            this.deleteDestinationImagesCheckBox.Visible = false;
            this.deleteDestinationImagesCheckBox.Enabled = false;

            // SORTING:
            FileSorter sorter = new FileSorter(this.filesToSort, ref currentTaskLabel, ref progressBar, this);
        }
    }
}
