namespace Dijkstry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var a = new NodeG1(0);
            var b = new NodeG1(1);
            var c = new NodeG1(2);
            var d = new NodeG1(3);
            var e = new NodeG1(4);
            var f = new NodeG1(5);

            var ed01 = new Edge(a, b, 3);
            var ed04 = new Edge(a, e, 3);
            var ed12 = new Edge(b, c, 1);
            var ed23 = new Edge(c, d, 3);
            var ed25 = new Edge(c, f, 1);
            var ed45 = new Edge(e, f, 2);
            var ed53 = new Edge(f, d, 1);
            var ed31 = new Edge(d, b, 3);
            var ed50 = new Edge(f, a, 6);

            var nowyGraf = new Graf1(ed01);

            nowyGraf.Dodaj(ed04);
            nowyGraf.Dodaj(ed12);
            nowyGraf.Dodaj(ed23);
            nowyGraf.Dodaj(ed25);
            nowyGraf.Dodaj(ed45);
            nowyGraf.Dodaj(ed53);
            nowyGraf.Dodaj(ed31);
            nowyGraf.Dodaj(ed50);

            List<Element> lista = nowyGraf.AlgorytmDijkstry(a);

            int abc = 0;


        }
    }
}