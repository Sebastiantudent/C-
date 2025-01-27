namespace podciąg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            int n = textBox1.TextLength;
            int m = textBox2.TextLength;
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            int[,] tab = new int[n+1, m+1];
            for(int i=0; i < n; i++)
            {
                for(int j=0; j < m; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        tab[i + 1, j + 1] = tab[i, j] + 1;
                    }
                    else
                    {
                        if (tab[i + 1, j] >= tab[i, j + 1])
                        {
                            tab[i + 1, j + 1] = tab[i+1,j];

                        }
                        else
                        {
                            tab[i + 1, j + 1] = tab[i, j +  1];
                        }
                    }
                }
            }
            string najdlwspodg = "";
            int k = n - 1;
            int g = m - 1;
            while(k>=0 && g >= 0)
            {
                if (s1[k] == s2[g])
                {

                }
            }

        }
    }
}