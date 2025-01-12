namespace KodHuffamana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string napis = "huffman jest prosty ale c juz nie";
        public static NodeG DrzewoHuffmana(Dictionary<char, int> frekwencja)
        {
            var kolejka = new SortedSet<NodeG>(Comparer<NodeG>.Create((a, b) =>
            {
                int cmp = a.data.CompareTo(b.data);
                return cmp == 0 ? -1 : cmp; // Rozwi�zanie przy r�nych warto�ciach
            }));

            foreach (var k in frekwencja)
            {
                kolejka.Add(new NodeGS
                {
                    symbol = k.Key,
                    data = k.Value,
                    lewe = null,
                    prawe = null,
                    rodzic = null

                });
            }
            //Budowanie drzewa
            while (kolejka.Count > 1)
            {
                var left = kolejka.Min;
                kolejka.Remove(left);

                var right = kolejka.Min;
                kolejka.Remove(right);

                var parent = new NodeG
                {
                    data = left.data + right.data,
                    lewe = left,
                    prawe = right,
                    rodzic = null
                };
                left.rodzic = parent;
                right.rodzic = parent;

                kolejka.Add(parent);
            }
            return kolejka.Min;
        }
        //Funkcja buduj�ca tablic� kodowania
        public static void TablicaKoduj�ca(NodeG root, string code, Dictionary<char, string> tab)
        {
            if (root == null)
                return;

            if (root is NodeGS nodeGS && nodeGS.lewe == null && nodeGS.prawe == null)//Li��
            {
                tab[nodeGS.symbol] = code;
            }

            TablicaKoduj�ca(root.lewe, code + "0", tab);
            TablicaKoduj�ca(root.prawe, code + "1", tab);
        }
        public static string koduj(string input, Dictionary<char, string> tablica)
        {
            string kod = "";

            foreach (var c in input)
            {
                kod += tablica[c];
            }
            return kod;
        }
        //Funkcja dekoduj�ca tekst
        public static string dekoduj(NodeG root, string kodowanie)
        {
            string kod = "";
            var current = root;
            foreach (var bit in kodowanie)
            {
                current = bit == '0' ? current.lewe :
                current.prawe;

                if (current is NodeGS nodeGS && nodeGS.lewe != null && nodeGS.prawe == null)//Li��
                {
                    kod += nodeGS.symbol;
                    current = root;
                }
            }
            return kod;
        }
        //
        // dict(znak:cz�stotliwo��)
        //
        //NodeGS .....OrderBy(n => n.data).ThenBy( n => n.GetType()==typeof(NodeGS)?0:1).ToList();
        //var lista = new List<NodeG>()
        // do listy mo�na w�o�y� NodeG i NodeGS bo NodeGS dziedziczy po NodeG
        //void wG��b(NodeG n,string kod)
        //{
        //if(n!=null)
        //{
        //wG��b(n.lewe,kod+"0");
        //wG��b(n.prawe,kod+"1");
        //}
        //}


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Tablica Koduj�ca \n";
            var frekwencja = new Dictionary<char, int>();
            //zliczanie wyst�pie� znak�w
            foreach (char ch in napis)
            {
                if (!frekwencja.ContainsKey(ch))
                    frekwencja[ch] = 0;
                frekwencja[ch]++;

            }
            //Budowanie drzewa Huffmana
            var root = DrzewoHuffmana(frekwencja);

            //Budowanie tablicy kodowania
            var tablicaKodowa = new Dictionary<char, String>();
            TablicaKoduj�ca(root, "", tablicaKodowa);

            //Wy�wietlenie tablicy kodowania
            foreach (var pair in tablicaKodowa)
            {
                label1.Text += $"{pair.Key}:{pair.Value} \n";

            }

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}