using FF3PR.Data.Master;
using FF3PRRando.Shufflers;
using FF3PRRando.Utility;

namespace FF3PRRando
{
    public partial class FF3PRRandoForm : Form
    {
        public FF3PRRandoForm()
        {
            InitializeComponent();
            int seed = Guid.NewGuid().GetHashCode();
            seed = seed < 0 ? seed * -1 : seed;
            seedTxtBox.Text = seed.ToString();
        }

        private void directoryBrowseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            // Optional: Set the initial directory (e.g., MyDocuments)
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            // Optional: Set a description for the dialog
            folderBrowserDialog1.Description = "Select the magicite export directory";

            // Show the dialog and check if the user clicked OK
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the selected path and display it in the textbox
                magiciteDirectoryTxtBx.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void InputDirectoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void randomizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Randomize();
                MessageBox.Show("Randomization Complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("An error occured during randomization, please ensure a proper magicite export directory has been selected before attempting to randomize.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Randomize()
        {
            int seed = int.Parse(seedTxtBox.Text);
            var csvReader = new CsvProcessor(magiciteDirectoryTxtBx.Text, outputPath.Text, seed);
            var jsonReader = new JsonReader(magiciteDirectoryTxtBx.Text, outputPath.Text, seed);
            var log = new LogWriter(seed);
            var textEditor = new TextEditing(magiciteDirectoryTxtBx.Text, outputPath.Text, seed);

            // Set open world state
            // Currently incomplete, certain issues such as how to handle guests being obtained out of order need to be resolved
            // jsonReader.InitializeOpenGameState();

            if (shuffleJobsBox.Checked)
            {
                // Randomize jobs
                var jobs = JobShuffler.GetAllJobs(csvReader);
                var jobGroups = JobShuffler.GetAllJobGroups(csvReader);
                var charAssets = JobShuffler.GetAllCharacterAssets(csvReader);
                var igc = JobShuffler.GetAllIntermediateGrowthCurves(csvReader);
                var shuffledJobs = JobShuffler.ShuffleJobs(jobs, jobGroups, charAssets, igc, seed);
                JobShuffler.WriteToJobMasterFile(csvReader, shuffledJobs.Item1);
                JobShuffler.WriteToJobGroupMasterFile(csvReader, shuffledJobs.Item2);
                JobShuffler.WriteToCharacterAssetMasterFile(csvReader, shuffledJobs.Item3);
                JobShuffler.WriteToGrowthCurveMasterFile(csvReader, shuffledJobs.Item4);
                log.WriteRandomizedJobsToLog(shuffledJobs.Item1);

                // Handle requirements for Mini and Toad status
                textEditor.AddMalletText();
                jsonReader.DisableFrogRequirement("Map_30071", "Map_30071_1", "sc_e_0040", 3);
                jsonReader.DisableFrogRequirement("Map_20161", "Map_20161_7", "sc_e_0047", 5);
                jsonReader.AddMallets("Map_20330", "Map_20330", "sc_rec_20330");
                jsonReader.AddMallets("Map_30101", "Map_30101_1", "sc_rec_30101_1");
            }

            if (shuffleShopsBox.Checked)
            {
                // Randomize shops
                var products = ProductShuffler.GetAllProducts(csvReader);
                var shuffledProducts = ProductShuffler.ShuffleProducts(products, seed);
                ProductShuffler.WriteToProductMasterFile(csvReader, shuffledProducts);
                log.WriteRandomizedProductsToLog(shuffledProducts);
            }

            if (shuffleChestsBox.Checked)
            {
                // Randomize Chests
                var shuffledTreasure = TreasureShuffler.ShuffleTreasure(jsonReader, seed);
                log.WriteRandomizedTreasureToLog(shuffledTreasure);
            }

            if (shuffleBGMBox.Checked)
            {
                //Randomize BGMs
                var bgms = BGMShuffler.GetAllBGMs(csvReader);
                var shuffledBgms = BGMShuffler.ShuffleBGMs(bgms, seed);
                BGMShuffler.WriteToBGMMasterFile(csvReader, shuffledBgms);
            }
        }

        private void outputBrowseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            // Optional: Set the initial directory (e.g., MyDocuments)
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;

            // Optional: Set a description for the dialog
            folderBrowserDialog1.Description = "Select the output path";

            // Show the dialog and check if the user clicked OK
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the selected path and display it in the textbox
                outputPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
