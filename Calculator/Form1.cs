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

        private IEnumerable<string> OperationNames { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            var operations = new List<IOperation>();

            #region Получение всех возможных операций
            // найти файлы dll и exe в текущей директории
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
                .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));
            //загрузить их
            foreach (var file in files)
            {
                // Console.WriteLine(file);
                var assembly = Assembly.LoadFile(file);

                var types = assembly.GetTypes();


                foreach (var type in types)
                {
                    //Console.WriteLine(type.Name);//нашли типы, но все
                    var interfaces = type.GetInterfaces();
                    // найти реализацюию интерфейса IOperation
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
                }
            }
            #endregion

            Calc = new Calc.Calc(operations);

            OperationNames = Calc.GetOperationsNames();
            //заполнить комбобокс
            FillCombobox();

            
        }

        private void FillCombobox()
        {
            this.comboBox1.Items.AddRange(OperationNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<object> parameters = new List<object>();

            if (!string.IsNullOrEmpty(textBox1.Text)) parameters.Add(textBox1.Text);
            if (!string.IsNullOrEmpty(textBox2.Text)) parameters.Add(textBox2.Text);
            if (!string.IsNullOrEmpty(textBox3.Text)) parameters.Add(textBox3.Text);
            if (!string.IsNullOrEmpty(textBox4.Text)) parameters.Add(textBox4.Text);

            var args = parameters.ToArray();

            var activeoper = comboBox1.Text.ToString();

            //var result = Calc.Execute(activeoper, args.Count(), args);
            var result = Calc.Execute(activeoper, args);
            lblResult.Text = result.ToString(); //comboBox1.Text;
        }
    }
}
