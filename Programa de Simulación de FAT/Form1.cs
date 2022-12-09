namespace Programa_de_Simulación_de_FAT
{
    public partial class Form1 : Form
    {
        //Declaracion de variables
        int start, tamano;
        float peso;
        string Cluster;
        string[] particion = new string[1000];

        //Llamada ak Constructor
        public Form1()
        {
            InitializeComponent();
        }
        //Condicional que altera el label indicador del manejo de tamano en el evento de cambio de tamaño del combobox
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "exFAT")
            {
                label14.Text = "Ingrese tamano del archivo (GB)";
            }
            else
            {
                label14.Text = "Ingrese tamano del archivo (MB)";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Se limpian los elementos de las listas fisicas
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            //Se establece un ciclo que limpia todos los valores del array de la particion
            for (int i = 0; i < 1000; i++)
            {
                particion[i] = null;
                listBox2.Items.Add(i + "-------------------" + particion[i]);
            }
        }

        //Evento en el caso de accionar el boton 1
        private void button1_Click(object sender, EventArgs e)
        {
            //Definicion de formato FAT con el que se va a trabajar
            if (comboBox1.Text == "FAT16")
            {
                //Se llama a todos los elementos existentes en los textbox asignados
                listBox2.Items.Clear();
                start = int.Parse(textBox2.Text);
                tamano = int.Parse(textBox3.Text);
                peso = float.Parse(textBox4.Text);
                //Establece una condicional de peso sobre la cual se va a trabajar respecto a su formato, se imprime un mensaje de error al 
                //hacer click en el boton
                if (peso > 2000)
                {
                    label13.Text = "ERROR: El sistema FAT16 no admite archivos mayores a 2GB, reasigna tamano";
                }
                else
                {
                    //Si no hay error de formato, se procede a imprimir los valores
                    for (int i = start; i < start + tamano; i++)
                    {
                        //Se checa la existencia de valores en el array con el proposito de no sobreescribir valores en el mismo
                        if (particion[i] != null)
                        {
                            //Si existen valores en la particion seleccionada, se imprime un mensaje de error
                            label13.Text = "ERROR: Ya existen datos en la particion seleccionada, se guardarán los datos en el proximo bloque disponible";
                            start++;
                        }
                        else
                        {
                            //Si no, se imprimen los valores en el array
                            particion[i] = textBox1.Text;

                        }
                    }
                    for (int i = 0; i < 1000; i++)
                    {
                        //Generacion de la particion grafica de memoria
                        listBox2.Items.Add(i + "-------------------" + particion[i]);

                    }
                    //Definicion de tamano de clusters respecto al peso de sus archivos
                    if (peso >= 0 && peso < 32) { Cluster = "512 bytes"; }
                    if (peso >= 32 && peso < 64) { Cluster = "1 Kilobyte"; }
                    if (peso >= 64 && peso < 128) { Cluster = "2 Kilobytes"; }
                    if (peso >= 128 && peso < 256) { Cluster = "4 Kilobytes"; }
                    if (peso >= 256 && peso < 512) { Cluster = "8 Kilobytes"; }
                    if (peso >= 512 && peso < 1000) { Cluster = "16 Kilobytes"; }
                    if (peso >= 1000 && peso <= 2000) { Cluster = "32 Kilobytes"; }

                    //Generacion del directorio grafico
                    listBox1.Items.Add(textBox1.Text + "--------------" + start + "--------------" + tamano + "--------------" + Cluster);
                }
            }

            if (comboBox1.Text == "FAT32")
            {
                listBox2.Items.Clear();
                start = int.Parse(textBox2.Text);
                tamano = int.Parse(textBox3.Text);
                peso = float.Parse(textBox4.Text);
                if (peso > 4000)
                {
                    label13.Text = "ERROR: El sistema FAT32 no admite archivos mayores a 4GB, reasigna tamano";
                }
                else
                {
                    for (int i = start; i < start + tamano; i++)
                    {
                        if (particion[i] != null)
                        {
                            label13.Text = "ERROR: Ya existen datos en la particion seleccionada, se guardarán los datos en el proximo bloque disponible";
                            start++;
                        }
                        else
                        {
                            particion[i] = textBox1.Text;

                        }
                    }
                    for (int i = 0; i < 1000; i++)
                    {
                        listBox2.Items.Add(i + "-------------------" + particion[i]);

                    }

                    if (peso >= 0 && peso < 64) { Cluster = "512 bytes"; }
                    if (peso >= 64 && peso < 128) { Cluster = "1 Kilobyte"; }
                    if (peso >= 128 && peso < 256) { Cluster = "2 Kilobytes"; }
                    if (peso >= 256 && peso <= 4000) { Cluster = "4 Kilobytes"; }

                    listBox1.Items.Add(textBox1.Text + "--------------" + start + "--------------" + tamano + "--------------" + Cluster);
                }
            }

            if (comboBox1.Text == "exFAT")
            {
                listBox2.Items.Clear();
                start = int.Parse(textBox2.Text);
                tamano = int.Parse(textBox3.Text);
                peso = float.Parse(textBox4.Text);
                if (peso > 2000)
                {
                    label13.Text = "ERROR: El sistema exFAT no admite archivos mayores a 2TB, reasigna tamano";
                }
                else
                {
                    for (int i = start; i < start + tamano; i++)
                    {
                        if (particion[i] != null)
                        {
                            label13.Text = "ERROR: Ya existen datos en la particion seleccionada, se guardarán los datos en el proximo bloque disponible";
                            start++;
                        }
                        else
                        {
                            particion[i] = textBox1.Text;

                        }
                    }
                    for (int i = 0; i < 1000; i++)
                    {
                        listBox2.Items.Add(i + "-------------------" + particion[i]);

                    }
                    if (peso >= 0.001 && peso < 0.256) { Cluster = "4 kilobytes"; }
                    if (peso >= 0.256 && peso < 32) { Cluster = "32 Kilobyte"; }
                    if (peso >= 32 && peso <= 2000) { Cluster = "128 Kilobytes"; }
                    listBox1.Items.Add(textBox1.Text + "--------------" + start + "--------------" + tamano + "--------------" + Cluster);
                }
            }
        }
    }
}