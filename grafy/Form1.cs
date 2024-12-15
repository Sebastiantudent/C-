namespace Pr.domowaGrafy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NodeG liczba2 = new NodeG(2);
        NodeG liczba3 = new NodeG(3);
        NodeG liczba5 = new NodeG(5);
        NodeG liczba6 = new NodeG(6);
        NodeG liczba7 = new NodeG(7);
        NodeG liczba8 = new NodeG(8);
        NodeG liczba9 = new NodeG(9);
        List<NodeG> liczba_ = new List<NodeG>();
        Graf liczba = new Graf();

        NoteG1 liczba2_ = new NoteG1();
        NoteG1 liczba3_ = new NoteG1();
        NoteG1 liczba5_ = new NoteG1();
        NoteG1 liczba6_ = new NoteG1();
        NoteG1 liczba7_ = new NoteG1();
        NoteG1 liczba8_ = new NoteG1();
        NoteG1 liczba9_ = new NoteG1();
        Edge edge = new Edge();
        Edge edge2 = new Edge();
        Edge edge3 = new Edge();
        Edge edge4 = new Edge();
        Edge edge5 = new Edge();
        Edge edge6 = new Edge();
        Edge edge7 = new Edge();
        //Graf1 graf1 = new Graf1(edge);





        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(369, 108);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(485, 108);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(392, 161);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // button3
            // 
            button3.Location = new Point(250, 108);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(713, 338);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liczba.nodes.Add(liczba9);
            liczba.nodes.Add(liczba5);
            liczba.nodes.Add(liczba6);
            liczba.nodes.Add(liczba2);
            liczba.nodes.Add(liczba3);
            liczba.nodes.Add(liczba7);
            liczba.nodes.Add(liczba8);

            liczba2.polacz(liczba3);
            liczba3.polacz(liczba5);
            liczba3.polacz(liczba6);
            liczba5.polacz(liczba8);
            liczba8.polacz(liczba9);
            liczba8.polacz(liczba7);
            liczba7.polacz(liczba6);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            liczba.wGlab(liczba2, liczba_);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            edge.start = liczba2_;
            edge.end = liczba3_;
            edge2.start = liczba3_;
            edge2.end = liczba5_;
            edge3.start = liczba3_;
            edge3.end = liczba6_;
            edge4.start = liczba5_;
            edge4.end = liczba8_;
            edge5.start = liczba6_;
            edge5.end = liczba7_;
            edge6.start = liczba7_;
            edge6.end = liczba8_;
            edge7.start = liczba8_;
            edge7.end = liczba9_;
            
            
        }
    }
}
