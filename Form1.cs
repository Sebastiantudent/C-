using System.Runtime.Intrinsics.Arm;

namespace KolosTestowy
{
    public partial class Form1 : Form
    {
        int[] BubbleSort(int[] array)
        {
            var n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var Value = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = Value;

                    }
                }
            }
            return array;
        }
        int[] InsertionSort(int[] array)
        {
            int length = array.Length;
            for (int i = 1; i < length; i++)
            {
                int key = array[i];
                int flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1; j--)
                {
                    if (key < array[j])
                    {
                        array[j + 1] = array[j];

                        array[j] = key;
                    }
                    else
                    {
                        flag = 1;
                    }
                }

            }
            return array;
        }

        static void selectionSort(int[] array) // array = 1,5,7,3,8,9,3
        {
            int Size = array.Length; // Size = 7
            for (int i = 0; i < Size - 1; i++)
            {
                int min = i; // 0,1,2,3,4,5,6
                for (int j = i + 1; j < Size; j++)
                {
                    if (array[j] < array[min]) // array[1] < array[0],... || array[2]< array[1], 
                    {                          //  5 < 1, ... || 7 < 5, 3 < 5, 8 < 3,...
                                               // 1 || 3 || 3 || ...

                        min = j; // 0 || 3 || 6 || ...
                    }
                }
                int temp = array[i]; // array[0] || array[3]
                array[i] = array[min]; // array[0] = array[0] || array[1] = array[3]
                array[min] = temp; //array[0] = array[0] || array[3] = array[1]
            }
        }
        int maxValue(int[] array)
        {
            var length = array.Length;
            var max = array[0];
            for (int i = 1; i < length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
        int[] CountingSort(int[] array)
        {
            var Size = array.Length;
            var max = maxValue(array);
            var MaxArray = new int[max + 1];
            for (int i = 0; i < max; i++)
            {
                MaxArray[i] = 0;
            }
            for (int i = 0; i < Size; i++)
            {
                MaxArray[array[i]]++;
            }
            for (int i = 0, j = 0; i <= max; i++)
            {
                while (MaxArray[i] > 0)
                {
                    array[j] = i;
                    j++;
                    MaxArray[i]--;

                }
            }
            return array;

        }
        int[] quicksort(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            
            if (i < rightIndex)
            {
                quicksort(array, i, rightIndex);
            }
            if (leftIndex < j)
            {
                quicksort(array, leftIndex, j);
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            label1.Text = "";

            BubbleSort(ia);
            for (int j = 0; j < ia.Length; j++)
            {
                if (j < ia.Length - 1)
                {
                    label1.Text += ia[j];
                    label1.Text += ",";
                }
                else if (j == ia.Length - 1)
                    label1.Text += ia[j];

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {

            label1.Text = textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            label1.Text = "";

            InsertionSort(ia);
            for (int j = 0; j < ia.Length; j++)
            {
                if (j < ia.Length - 1)
                {
                    label1.Text += ia[j];
                    label1.Text += ",";
                }
                else if (j == ia.Length - 1)
                    label1.Text += ia[j];

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            label1.Text = "";

            CountingSort(ia);
            for (int j = 0; j < ia.Length; j++)
            {
                if (j < ia.Length - 1)
                {
                    label1.Text += ia[j];
                    label1.Text += ",";
                }
                else if (j == ia.Length - 1)
                    label1.Text += ia[j];

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            label1.Text = "";

            quicksort(ia,0,ia.Length-1);
            for (int j = 0; j < ia.Length; j++)
            {
                if (j < ia.Length - 1)
                {
                    label1.Text += ia[j];
                    label1.Text += ",";
                }
                else if (j == ia.Length - 1)
                    label1.Text += ia[j];

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s1 = label1.Text;
            int[] ia = s1.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            label1.Text = "";

            selectionSort(ia);
            for (int j = 0; j < ia.Length; j++)
            {
                if (j < ia.Length - 1)
                {
                    label1.Text += ia[j];
                    label1.Text += ",";
                }
                else if (j == ia.Length - 1)
                    label1.Text += ia[j];

            }
        }
    

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
