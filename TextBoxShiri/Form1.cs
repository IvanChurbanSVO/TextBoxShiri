using System.ComponentModel.DataAnnotations;

namespace TextBoxShiri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Commands> commands = new List<Commands>();
            string text = textBox1.Text+"\n";

            for (; text != "";)
            {
                string chai;
                string line = text[0..text.IndexOf("\n")];

                try
                {
                    commands.Add(
                        new(
                            line[0..line.IndexOf("(")],
                            line[(line.IndexOf("(") + 1)..line.IndexOf(")")]
                            )
                                );
                } catch( Exception ex ) { }
                text = text[(text.IndexOf("\n") + 1)..^0];

                if (commands[commands.Count - 1].key == "for")
                {
                    commands[commands.Count-1].value = commands[commands.Count-2].value;
                    string forline = "";
                    for (int i = 0; i < int.Parse(commands[commands.Count - 1].value) - 1; i++)
                    {
                        forline += text[0..text.IndexOf("}")];
                    }
                    text = text.Insert(text.IndexOf("}"), forline);
                }

            }
            Form2 form2 = new Form2(commands);
            form2.Show(); 
        }
    }

    public class Commands(string key, string value)
    {
        public string key = key;
        public string value = value;
    }
}
