using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EgyptianHieroglyphsProcessing
{
    public partial class MainForm : Form
    {
        public static string EFont = "NewGardiner";
        //public static string EFont = "AncientEgyptianHieroglyphs";

        public MainForm()
        {
            InitializeComponent();
        }

        public void Init()
        {
            if (System.Drawing.FontFamily.Families.Count(x => x.Name == EFont) == 0)
            {
                DialogResult dialogResult = MessageBox.Show("The font '" + EFont + " ' is not detected! Do you wish to continue?", "A font is missing", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }

            textBox1.Font = new Font(EFont, 36, FontStyle.Regular);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
            string two_characters = "\U00013000\U00013020";
        }

        public int ConvertGlyphToUnicodeNumber(string singleGlyph)
        {
            Encoding enc = new UTF32Encoding(false, true, true); byte[] b = enc.GetBytes(singleGlyph);

            Int32 index = BitConverter.ToInt32(b, 0);

            return index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string single_character = "\U00013000"; //hex code

            int index = ConvertGlyphToUnicodeNumber(single_character);

            for (int i = 0; i < 40; i++)
            {
                string glyph = Char.ConvertFromUtf32(index);

                textBox1.Text += glyph;

                index++;
            }
        }
    }
}
