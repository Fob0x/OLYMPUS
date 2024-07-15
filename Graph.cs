using MetroFramework.Forms;
using System.IO;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace OLYMPUS
{
    public partial class Graph : MetroForm
    {
        public int modification; // Добавление поля modification
        public Graph()
        {
            InitializeComponent();
            this.Shown += new EventHandler(Graph_Shown);
            
        }

        private void Graph_Shown(object sender, EventArgs e)
        {
            using (StreamReader fgraph = new StreamReader(DECLARE.wayOut))
            {
                for (int i = 0; i < 19; i++)
                    fgraph.ReadLine();
                string liner = fgraph.ReadLine();
                Console.WriteLine("Считанная строка: " + liner); // Выводим считанную строку для отладки

                string[] parts = liner.Split('-');

                // Отладочный вывод содержимого для проверки
                Console.WriteLine("Содержимое parts[0].Trim(): " + parts[0].Trim());

                // Преобразуем строку с числом в целое число
                int Nr;
                if (int.TryParse(parts[0].Trim(), out Nr)) // Преобразование и проверка успешности
                {
                    Console.WriteLine("Nr наш: " + Nr); // Выводим значение Nr для отладки
                    DECLARE.Nr = Nr; // Присваиваем значение переменной DECLARE.Nr
                }
                for (int i = 0; i < 14; i++)
                    fgraph.ReadLine();

                switch (modification)
                {
                    case 1:
                    {
                        var series = new System.Windows.Forms.DataVisualization.Charting.Series();
                        series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                        series.Points.AddXY(0, 1);
                        chart1.ChartAreas[0].AxisX.Title = "Время";
                        chart1.Titles[0].Text = "Профиль безразмерной температуры в центре";
                        chart1.Legends.Clear();
                        while (!fgraph.EndOfStream)
                        {
                            //var lineе = fgraph.ReadLine().Split(' ');
							var line = fgraph.ReadLine().Split(' ');
							Console.WriteLine($"Line: {string.Join(", ", line)}");
							try
                            {
                                //string elemt;
								//string elem = line[2].Replace(',', '.');
								double elem = double.Parse(line[4].Replace(',', '.'), CultureInfo.InvariantCulture);
								Console.WriteLine($"Parsed value of elem: {elem}");
								int t = int.Parse(line[1]);
                                series.Points.AddXY(t, elem);
								chart1.ChartAreas[0].AxisX.Minimum = 0;

							}
							catch (FormatException ex)
                            {
                                // Обработка исключения: вывод сообщения об ошибке в MessageBox
                                MessageBox.Show($"Ошибка при преобразовании строки в число: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        this.chart1.Series.Add(series);
                        break;
                    }
					
					case 2:
					{
						while (!fgraph.EndOfStream)
						{
							var series = new System.Windows.Forms.DataVisualization.Charting.Series();
							
							var line = fgraph.ReadLine().Split(' ');
							double elem = double.Parse(line[0]);
							int t = int.Parse(line[1]);
							series.LegendText = t.ToString();
							series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
							chart1.ChartAreas[0].AxisX.Title = "Безразмерное расстояние";
							chart1.Titles[0].Text = "Профили безразмерной температуры";
							for (int r = 4; r <= DECLARE.Nr+4; r++)
							{


								elem = double.Parse(line[r]);
								series.Points.AddXY(((double)r-4) / DECLARE.Nr, elem);
							}
							chart1.Series.Add(series);
							chart1.ChartAreas[0].AxisX.Minimum = 0;
						}
						break;
					}
				}
			}
        }
    }
}
