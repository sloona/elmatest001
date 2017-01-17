using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calc;
using System.IO;
using System.Reflection;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Калькулятор
        /// </summary>
        private Calc.Calc Calc { get; set; }

        private IEnumerable<string> OperationNames {get; set;}

        private void Form1_Load(object sender, EventArgs e)
        {
            var operations = new List<IOperation>();

            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
                .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));
            //загрузить из
            foreach (var file in files)
            {
                // Console.WriteLine(file);
                var assembly = Assembly.LoadFile(file);

                var types = assembly.GetTypes();


                foreach (var type in types)
                {

                    //Console.WriteLine(type.Name);//нашли типы, но все
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //Console.WriteLine(type.Name);
                        //создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }


                    //foreach (var interf in interfaces) {
                    //Console.WriteLine(interf.Name);
                    //}
                }
            }

            //найти реализацию exe IOperation
            //создать экземпляр класса
            //передаем все эти экземпляры в class

            var Calc = new Calc.Calc(operations);

            OperationNames = Calc.GetOperationsNames();
            FillCombobox();

            //заполнить комбобокс
        }

        private void FillCombobox()
        {
            this.comboBox1.Items.AddRange(OperationNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblResult.Text = comboBox1.Text;
        }
    }
}
