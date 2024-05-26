namespace GameOfLife
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        bool[,] map;
        bool[,] newMap;
        static int mapSize;
        int cells;




        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text!=null&&textBox2.Text!=null&&Math.Pow(int.Parse(textBox1.Text),2)>=(int.Parse(textBox2.Text)))
                {
                    mapSize = int.Parse(textBox1.Text);
                    cells = int.Parse(textBox2.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Számokat adjon meg mindkét textboxba, az élõ cellák száma ne legyen nagyobb mint a pálya területe! (size^2)");
            }
            //Pálya generálás
            map = new bool[mapSize, mapSize];
            

            for (int i = 0; i < cells; i++)
            {
                int x;
                int y;
                do
                {
                    x = rnd.Next(mapSize);
                    y = rnd.Next(mapSize);
                } while (map[x, y]);
                map[x, y] = true;
            }


            timer1.Start();

        }
        static int surrounddings(int x, int y, bool[,] map)
        {
            int surrCells=0;
            for (int i = -1; i < 2; i++)
            {
                for (int j =-1; j < 2; j++)
                {
                    int xi = x + i;
                    int yj = y + j;

                    if (i == 0 && j == 0) continue;
                    if (xi<0||yj<0) continue;
                    if (xi>=mapSize||yj>=mapSize) continue;
                    if (map[xi,yj])
                    {
                        surrCells++;
                    }

                }
            }





            return surrCells; 
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            newMap = new bool[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    ClassCell cell = new ClassCell();
                    if (cell.Width*mapSize>=panel1.Width&&cell.Height*mapSize>=panel1.Height)
                    {
                        cell.Width = panel1.Width / mapSize;
                        cell.Height = panel1.Height / mapSize;
                    }
                    
                    
                    cell.Left = i * cell.Width;
                    cell.Top = j * cell.Height;

                    if (map[i, j])
                    {
                        cell.BackColor = Color.Green;

                    }
                    panel1.Controls.Add(cell);
                }
            }
            //Frissítés
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    int surrCells = surrounddings(i,j,map);
                    if (map[i,j]&&surrCells==2) newMap[i,j] = true;
                    if (surrCells < 2||surrCells>3) newMap[i, j] = false;
                    if (surrCells == 3) newMap[i, j] = true;
                    

                }
            }
            map = newMap;


        }
    }
}