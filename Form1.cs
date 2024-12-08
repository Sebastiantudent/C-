using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;

namespace PracaDomowa
{
    public partial class Form1 : Form
    {
        public int[] BubbleSort(int[] NumArray)
        {
            
            var n = NumArray.Length;

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (NumArray[j] > NumArray[j + 1])
                    {
                        var tempVar = NumArray[j];
                        NumArray[j] = NumArray[j + 1];
                        NumArray[j + 1] = tempVar;
                    }
            
            return NumArray;
            
        }
        public int[] SortInsertion(int[] array, int length)
        {
            //6,5,3,7 
            for (int i = 1; i < length; i++) //i=1,2,3
            {
                var key = array[i]; // key = 6, key = 3, key = 7
                var flag = 0;

                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key < array[j]) // array[1] < array[0] || key < array[1],key < array[0] ||
                    {
                        array[j + 1] = array[j];//array[1] = array[0] || array[2] = array[1],array[1] = array[0] ||
                        j--;                  // 5 <=> 6                  3 <=> 6             3 <=> 5
                        array[j + 1] = key;//array[0] = key(5) || array[1] = key(3), array[0] = key(3) ||
                                             // 6 <=> 5        6 <=> 3         5 <=> 3
                        //5,6,3,7 || 5,3,6,7 , 3,5,6,7
                    }
                    else flag = 1;
                }
            }

            return array;
        }
        public int[] SortArray(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                SortArray(array, left, middle);
                SortArray(array, middle + 1, right);

                MergeArray(array, left, middle, right);
            }

            return array;
        }
        public void MergeArray(int[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;

            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];

            i = 0;
            j = 0;
            int k = left;

            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }

            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }

            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }
        public static int GetMaxVal(int[] array, int size)
        {
            var maxVal = array[0];
            for (int i = 1; i < size; i++)
                if (array[i] > maxVal)
                    maxVal = array[i];
            return maxVal;
        }
        // max = 6 ,maxtab[6+1], maxtab[x]=0
        // indeks przechowuje liczbê wystopieñ liczby pod inteksem (maxtab[0] = 2 => array[] ma 2 zera)
        // sumujemy kolejne elementy na ostatnich indeksach czyli:
        // 0 1 2 3 4 5 6 7 => 0 1 2 3 4  5  6  7
        // 2 0 2 4 3 0 1 1 => 2 2 4 8 11 11 12 13
        //i id¹c od koñca porównujemy array wartosci pod indeksem do indeksow maxtab i wartosc pod max tab
        //i na koniec wpisujemy indeksy maxtab(wartosci array) pod (wartosc max tab - 1) do array
        // wartosc max tab - 1 na sta³e w tablicy zmniejszamy o 1
        public int[] CountingSort(int[] array)
        {
            
            var size = array.Length;
            var maxElement = GetMaxVal(array, size);
            var occurrences = new int[maxElement + 1];

            for (int i = 0; i < maxElement + 1; i++)
            {
                occurrences[i] = 0;
            }

            for (int i = 0; i < size; i++)
            {
                occurrences[array[i]]++;
            }

            for (int i = 0, j = 0; i <= maxElement; i++)
            {
                while (occurrences[i] > 0)
                {
                    array[j] = i;
                    j++;
                    occurrences[i]--;
                }
            }

            return array;
        }
        public int[] QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex; // leftIndex = 0;
            var j = rightIndex;// rigntIndex = array.Size - 1;
            var pivot = array[leftIndex]; //pivot = array[0];

            while (i <= j) // 0 <= array.Size - 1;
            {
                while (array[i] < pivot) // array[0] < array[0]
                {
                    i++;
                }

                while (array[j] > pivot) //array[array.Size - 1] > array[0]
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j);

            if (i < rightIndex)
                QuickSort(array, i, rightIndex);

            return array;
        }

        public Form1()
        {
            InitializeComponent();
        }
        System.Timers.Timer timer;
        int t;


        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            label2.Text = numericUpDown1.Value.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            BubbleSort(ia);
            label1.Text = "";
            for (int j = 0; j < ia.Length; j++)
            {

                label1.Text += ia[j].ToString();
                if (j < ia.Length - 1)
                {
                    label1.Text += ',';
                }


            }
            timer1.Stop();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            SortInsertion(ia, ia.Length);
            label1.Text = "";
            for (int j = 0; j < ia.Length; j++)
            {

                label1.Text += ia[j].ToString();
                if (j < ia.Length - 1)
                {
                    label1.Text += ',';
                }


            }
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            SortArray(ia, 0, ia.Length - 1);
            label1.Text = "";
            for (int j = 0; j < ia.Length; j++)
            {

                label1.Text += ia[j].ToString();
                if (j < ia.Length - 1)
                {
                    label1.Text += ',';
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            CountingSort(ia);
            label1.Text = "";
            for (int j = 0; j < ia.Length; j++)
            {

                label1.Text += ia[j].ToString();
                if (j < ia.Length - 1)
                {
                    label1.Text += ',';
                }


            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            QuickSort(ia, 0, ia.Length - 1);
            
            label1.Text = "";
            for (int j = 0; j < ia.Length; j++)
            {

                label1.Text += ia[j].ToString();
                if (j < ia.Length - 1)
                {
                    label1.Text += ',';
                }


            }
            timer1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (int.Parse(label2.Text) == 0)
            {
                label1.Text = "0";
            }
            else
            {
                Random rnd = new Random();
                int n = int.Parse(label2.Text);
                int[] tab = new int[n];
                label1.Text = rnd.Next(100).ToString();
                tab[0] = int.Parse(label1.Text);
                for (int j = 0; j < n - 1; j++)
                {
                    label1.Text += ",";
                    label1.Text += rnd.Next(100).ToString();


                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string mystr = t.ToString();
            label3.Text = "timer: " + mystr;
            t += 1;
        }
    }
}
