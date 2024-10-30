using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace VCF_Name_Fix
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // Filter only on VCF file

            openFileDialog1.Filter = "VCF files|*.vcf";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                // Clear messages
                lblMessages.Text = "";
                lblMessages.Visible = false;

                var fileContent = string.Empty;
                var filePath = string.Empty;

                //Get the path of specified file
                filePath = openFileDialog1.FileName;

                lblMessages.Text = filePath + " loaded... \r\n\r\n Please click Process to create new VCF file with fixes...";
                lblMessages.Visible = true;

                btnProcess.Enabled = true;
            }
            else
            {
                // Show error message?
                lblMessages.Text = "Please select VCF file only.";
                lblMessages.Visible = true;

                btnProcess.Enabled = false;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            //Read the contents of the file into a stream
            var fileStream = openFileDialog1.OpenFile();

            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileContent = reader.ReadToEnd();

                string[] stringSeparators = new string[] { "\r\n" };
                string[] vcfData = fileContent.Split(stringSeparators, StringSplitOptions.None);

                var currentFormattedName = "";
                var fullName = "";
                var fixedFormattedName = "";
                var fixedSpaceName = "";

                bool containedSpaces = false;

                // Now we need to loop through the results
                for (int i = 0; i < vcfData.Length; i++)
                {
                    var vcfRow = vcfData[i];

                    // Let's check what data we are on
                    if (vcfRow.StartsWith("FN:"))
                    {
                        // We are on the first name
                        currentFormattedName = vcfRow.TextAfter("FN:");
                    }
                    else if (vcfRow.StartsWith("N:"))
                    {
                        // We are on the full name
                        fullName = vcfRow.TextAfter("N:");

                        // With this full name let's split out what it 'should be'
                        if (fullName.Contains(";"))
                        {
                            string[] fullNameParts = fullName.Split(';');

                            // Check we have the right data
                            // 0 Family Name
                            // 1 Given Name
                            // 2 Middle Name
                            // 3 Prefixes
                            // 4 Suffixes
                            if (fullNameParts.Length == 5)
                            {
                                // Let's also fix any erroneous spaces if it exists
                                for (int x = 0; x < fullNameParts.Length; x++)
                                {
                                    var part = fullNameParts[x];
                                    if (part.EndsWith(" ") || part.StartsWith(" "))
                                    {
                                        fullNameParts[x] = part.Trim();
                                        containedSpaces = true;
                                    }
                                }

                                if (containedSpaces == true)
                                {
                                    vcfData[i] = "N:" + String.Join(";", fullNameParts);
                                }

                                // Let's build out the 'correct' name
                                fullNameParts.Switch(3, 0);
                                fixedFormattedName = String.Join(" ", fullNameParts.Where(s => !string.IsNullOrEmpty(s)));

                                // Now that we have the 'correct' name let's compare
                                if (!fixedFormattedName.Equals(currentFormattedName))
                                {
                                    // This means the name is WRONG let's update
                                    // FN appears to always be before N
                                    vcfData[i - 1] = "FN:" + fixedFormattedName;
                                }
                            }
                        }
                        // Here let's reset our data

                        currentFormattedName = "";
                        fullName = "";
                        fixedFormattedName = "";
                    }
                }

                // Now that we are here we have processed everything
                // Let's save to desktop
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FixedVCF.vcf");
                File.WriteAllLines(filePath, vcfData);

                lblMessages.Text = "Fixed file saved to: " + filePath;
            }
        }
    }
    public static class Extension
    {
        public static string TextAfter(this string value, string search)
        {
            return value.Substring(value.IndexOf(search) + search.Length);
        }
        public static void Switch<T>(this IList<T> array, int index1, int index2)
        {
            var aux = array[index1];
            array[index1] = array[index2];
            array[index2] = aux;
        }
    }
}
