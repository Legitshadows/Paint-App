using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graficacion_Luis_Beltran
{
    public partial class Form1 : Form
    {
        Bitmap Lienzo;
        Color color, CFondo;
        int sizepincel, Lados, Radio, Rx, Ry, Xc, Yc, tx, ty, x, y, angulo, auxiliar;
        float Sx, Sy;
        string opcionMenu, id;
        List<Point> ListaPixeles, Aux, Aux2, ListaAuxExamen1, PuntosTG, PuntosT, Aux3;
        string Estilo;
        bool Lienzomax;




        public Form1()
        {
            InitializeComponent();
            color = Color.Black;
            CFondo = Color.FromArgb(0, 0, 0, 0);
            Lienzo = new Bitmap(ptb_Lienzo.Width, ptb_Lienzo.Height);
            sizepincel = 0;
            ListaPixeles = new List<Point>();
            PuntosT = new List<Point>();
            PuntosTG = new List<Point>();
            Aux = new List<Point>();
            Aux2 = new List<Point>();
            ListaAuxExamen1 = new List<Point>();
            Estilo = "default";
            Lienzomax = true;
            Radio = 80;
            Rx = 100;
            Ry = 150;
            angulo = 45;

        }

        //Control de los elementos de menu
        // Boton de Pixel
        private void Pixel_Click(object sender, EventArgs e)
        {
            opcionMenu = "Pixel";
        }

        // Boton de Recta
        private void Recta_Click(object sender, EventArgs e)
        {
            opcionMenu = "Recta";

            id = "Recta";
        }

        // Boton de Poligono Irregular
        private void PolignoIrregular_Click(object sender, EventArgs e)
        {
            opcionMenu = "Poligono Irregular";
            id = "Poligono Irregular";
        }

        private void Txt_Lados_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Lados.Text))
            {
            }
            else
            {


                Lados = int.Parse(Txt_Lados.Text);
            }
        }

        // Boton de Poligono Regular
        private void btn_PolignoRegular_Click(object sender, EventArgs e)
        {
            opcionMenu = "Poligono Regular";
            id = "Poligono Regular";
        }

        private void btn_Triangulo_Click(object sender, EventArgs e)
        {
            Lados = 3;
        }

        private void btn_Cuadrado_Click(object sender, EventArgs e)
        {
            Lados = 4;
        }

        private void btn_Rectangulo_Click(object sender, EventArgs e)
        {
            Lados = 4;
            Sx = 2F;
            Sy = 1F;
        }


        private void btn_Pentagono_Click(object sender, EventArgs e)
        {
            Lados = 5;
        }

        private void btn_Hexagono_Click(object sender, EventArgs e)
        {
            Lados = 6;
        }

        // Boton de Circunferencia
        private void btn_Circunferencia_Click(object sender, EventArgs e)
        {
            opcionMenu = "Circunferencia";
            id = "Circunferencia";
        }

        // Boton de Elipse
        private void btn_Elipse_Click(object sender, EventArgs e)
        {
            opcionMenu = "Elipse";
            id = "Elipse";
        }

        // Boton de Traslacion
        private void btn_Traslacion_Click(object sender, EventArgs e)
        {
            opcionMenu = "Traslacion";
        }

        // Boton de Rotacion
        private void btn_rotacion_Click(object sender, EventArgs e)
        {
            opcionMenu = "Rotacion";
        }

        // Boton de Escalamiento
        private void btn_Escalamiento_Click(object sender, EventArgs e)
        {
            opcionMenu = "Escalamiento";
        }

        private void btn_Aumentar_Click(object sender, EventArgs e)
        {
            Sx = 1.1F;
            Sy = 1.1F;
        }

        private void btn_Disminuir_Click(object sender, EventArgs e)
        {
            Sx = 0.9F;
            Sy = 0.9F;
        }

        // Boton de Ayuda
        private void imagenDeAyudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ptb_Lienzo.ImageLocation = "https://i.imgur.com/ripdaVg.png";
            ptb_Lienzo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Boton de relleno
        private void btn_Relleno_Click(object sender, EventArgs e)
        {
            opcionMenu = "Relleno";
        }

        //Botones de control de colores
        private void Red_Click(object sender, EventArgs e)
        {
            color = Color.Red;
            ptb_Lienzo.Image = Lienzo;
            Actual.BackColor = color;
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            color = Color.Blue;
            ptb_Lienzo.Image = Lienzo;
            Actual.BackColor = color;
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            color = Color.Purple;
            ptb_Lienzo.Image = Lienzo;
            Actual.BackColor = color;
        }

        private void Pink_Click(object sender, EventArgs e)
        {
            color = Color.Pink;
            ptb_Lienzo.Image = Lienzo;
            Actual.BackColor = color;
        }

        private void Orange_Click(object sender, EventArgs e)
        {
            color = Color.Orange;
            ptb_Lienzo.Image = Lienzo;
            Actual.BackColor = color;
        }

        private void Brown_Click(object sender, EventArgs e)
        {
            color = Color.Brown;
            ptb_Lienzo.Image = Lienzo;
            Actual.BackColor = color;
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            color = Color.Yellow;
            ptb_Lienzo.Image = Lienzo;
            Actual.BackColor = color;
        }

        private void Green_Click(object sender, EventArgs e)
        {
            color = Color.Green;
            ptb_Lienzo.Image = Lienzo;
            Actual.BackColor = color;
        }

        private void Colores_Click(object sender, EventArgs e)
        {
            if (DialogoDeColores.ShowDialog() == DialogResult.OK)
            {
                color = DialogoDeColores.Color;

            }
            Actual.BackColor = color;
        }

        //Control del menu de tamaño
        private void Grosor1_Click(object sender, EventArgs e)
        {
            sizepincel = 0;
            BotonSeleccionado(btn_grosor1, gp_grosor);

        }

        private void Grosor2_Click(object sender, EventArgs e)
        {
            sizepincel = 1;
            BotonSeleccionado(btn_grosor2, gp_grosor);
        }
        private void Grosor3_Click(object sender, EventArgs e)
        {
            sizepincel = 2;
            BotonSeleccionado(btn_grosor3, gp_grosor);
        }

        //Control de menu de estilos
        private void Estilo_Default_Click(object sender, EventArgs e)
        {
            Estilo = "default";
            BotonSeleccionado(btn_default, gp_estilos);

        }

        private void Punteado_Click(object sender, EventArgs e)
        {
            Estilo = "punteado";
            BotonSeleccionado(btn_punteada, gp_estilos);
        }

        private void Segmentado_Click(object sender, EventArgs e)
        {
            Estilo = "segmentado";
            BotonSeleccionado(btn_segmentada, gp_estilos);
        }

        //Botones de Examanes
        private void btn_Examen1_Click(object sender, EventArgs e)
        {
            List<Point> ListaE = new List<Point>();

            //Recta del punto 1 al 2
            Point Punto0 = ListaAuxExamen1[0];
            ListaE.Add(Punto0);
            Point Punto1 = ListaAuxExamen1[1];
            ListaE.Add(Punto1);
            sizepincel = 1;
            Estilo = "default";
            Recta(ListaE, Color.Red);
            ListaE.Clear();

            //Recta del punto 2 al 3
            ListaE.Add(Punto1);
            Point Punto2 = ListaAuxExamen1[2];
            ListaE.Add(Punto2);
            sizepincel = 2;
            Estilo = "punteado";
            Recta(ListaE, Color.Blue);
            ListaE.Clear();

            //Recta del punto 3 al 4
            ListaE.Add(Punto2);
            Point Punto3 = ListaAuxExamen1[3];
            ListaE.Add(Punto3);
            sizepincel = 0;
            Estilo = "segmentado";
            Recta(ListaE, Color.Blue);
            ListaE.Clear();

            //Recta del punto 4 al 5
            ListaE.Add(Punto3);
            Point Punto4 = ListaAuxExamen1[4];
            ListaE.Add(Punto4);
            sizepincel = 2;
            Estilo = "punteado";
            Recta(ListaE, Color.Blue);
            ListaE.Clear();

            ListaAuxExamen1.Clear();
            ptb_Lienzo.Image = Lienzo;
            btn_Examen1.Enabled = false;

        }

        private void btn_Examen2_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Maximized" && Lienzomax)
            {
                Lienzo = new Bitmap(Size.Width, Size.Height);
                Lienzomax = false;
            }

            List<Point> Examen2 = new List<Point>();

            //La cabeza del pollito
            Rx = 50;
            Examen2.Add(new Point(928, 299));
            Circunferencia(Examen2, Rx, color);
            Examen2.Clear();

            //Ojito del pollito
            Rx = 13;
            Examen2.Add(new Point(950, 280));
            Circunferencia(Examen2, Rx, color);
            Examen2.Clear();

            //Pico del pollito
            Examen2.Add(new Point(991, 291));
            Examen2.Add(new Point(979, 306));
            Examen2.Add(new Point(1003, 304));
            PoligonoIrregular(Examen2, color);
            Examen2.Clear();

            //El cuerpazo del pollito
            Rx = 120; Ry = 80; Lados = 3;
            Examen2.Add(new Point(821, 400));
            Elipse(Examen2, Rx, Ry, color);
            Examen2.Clear();

            //Primer Pata del pollito
            Examen2.Add(new Point(752, 465));
            Examen2.Add(new Point(741, 478));
            Recta(Examen2, color);
            Examen2.Clear();
            Examen2.Add(new Point(741, 478));
            Examen2.Add(new Point(732, 496));
            Examen2.Add(new Point(755, 497));
            PoligonoIrregular(Examen2, color);
            Examen2.Clear();

            //Seguna Pata del pollito
            Examen2.Add(new Point(836, 479));
            Examen2.Add(new Point(836, 486));
            Recta(Examen2, color);
            Examen2.Clear();
            Examen2.Add(new Point(836, 486));
            Examen2.Add(new Point(826, 497));
            Examen2.Add(new Point(849, 498));
            PoligonoIrregular(Examen2, color);
            Examen2.Clear();

            //Cola del pollito
            Examen2.Add(new Point(663, 367));
            Examen2.Add(new Point(694, 398));
            Examen2.Add(new Point(708, 360));
            PoligonoIrregular(Examen2, color);
            Examen2.Clear();

            //Como en el evento MouseClick, activa la imagen justo cuando lo presionan
            ptb_Lienzo.Image = Lienzo;
        }

        private void btn_Examen3_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Maximized" && Lienzomax)
            {
                Lienzo = new Bitmap(Size.Width, Size.Height);
                Lienzomax = false;
            }

            List<Point> Examen3 = new List<Point>();

            //Color de fondo para el lienzo jeje
            ptb_Lienzo.BackColor = Color.Black;

            //Primer Elipse
            Rx = 180; Ry = 120;
            Examen3.Add(new Point(890, 414));
            sizepincel = 2;
            Elipse(Examen3, Rx, Ry, Color.White);
            Examen3.Clear();

            //Segundo Elipse
            Rx = 240; Ry = 180;
            Examen3.Add(new Point(890, 414));
            sizepincel = 2;
            Elipse(Examen3, Rx, Ry, Color.White);
            Examen3.Clear();

            //Tercer Elipse
            Rx = 340; Ry = 220;
            Examen3.Add(new Point(890, 414));
            sizepincel = 2;
            Elipse(Examen3, Rx, Ry, Color.White);
            Examen3.Clear();

            //Cuarto Elipse
            Rx = 520; Ry = 280;
            Examen3.Add(new Point(890, 400));
            sizepincel = 2;
            Elipse( Examen3, Rx, Ry, Color.White);
            Examen3.Clear();

            
            //Quinto Elipse
            Rx = 720; Ry = 340;
            Examen3.Add(new Point(890, 414));
            sizepincel = 2;
            Elipse(Examen3, Rx, Ry, Color.White);
            Examen3.Clear();

            //Sexto Elipse
            Rx = 860; Ry = 400;
            Examen3.Add(new Point(890, 414));
            sizepincel = 2;
            Elipse(Examen3, Rx, Ry, Color.White);
            Examen3.Clear();

            //El Sol
            Rx = 70;
            Examen3.Add(new Point(815, 415));
            Circunferencia(Examen3, Rx, Color.OrangeRed);
            Relleno(784, 415, Color.OrangeRed);
            Examen3.Clear();

            //El Mercurio
            Rx = 20;
            Examen3.Add(new Point(964, 305));
            Circunferencia(Examen3, Rx, Color.SandyBrown);
            Relleno(959, 314, Color.SandyBrown);
            Relleno(968, 297, Color.SandyBrown);
            Relleno(964, 305, Color.SandyBrown);
            Examen3.Clear();

            //El Venus
            Rx = 40;
            Examen3.Add(new Point(1068, 292));
            Circunferencia(Examen3, Rx, Color.Brown);
            Relleno(1068, 307, Color.Brown);
            Relleno(1068, 281, Color.Brown);
            Relleno(1068, 292, Color.Brown);
            Examen3.Clear();

            //El Tierra
            //1153, 552
            //1139, 533
            //1159, 576
            Rx = 50;
            Examen3.Add(new Point(1153, 552));
            Circunferencia(Examen3, Rx, Color.Navy);
            Relleno(1139, 533, Color.Navy);
            Relleno(1159, 576, Color.Navy);
            Relleno(1153, 552, Color.Navy);
            Examen3.Clear();

            //El Luna
            //1235, 519
            //
            //
            Rx = 10;
            Examen3.Add(new Point(1235, 519));
            Circunferencia(Examen3, Rx, Color.LightGray);
            Relleno(1235, 519, Color.LightGray);
            Examen3.Clear();

            //El Luna
            //1090, 658
            //1088, 648
            //1094, 666
            Rx = 20;
            Examen3.Add(new Point(1090, 658));
            Circunferencia(Examen3, Rx, Color.DarkOrange);
            Relleno(1088, 648, Color.DarkOrange);
            Relleno(1090, 658, Color.DarkOrange); 
            Relleno(1094, 666, Color.DarkOrange);
            Examen3.Clear();

            //El Jupiter
            //1202, 720
            //1196, 711
            //1201, 933
            Rx = 50;
            Examen3.Add(new Point(1202, 720));
            Circunferencia(Examen3, Rx, Color.FromArgb(255, 229, 204));
            Relleno(1196, 711, Color.FromArgb(255, 229, 204));
            Relleno(1207, 730, Color.FromArgb(255, 229, 204));
            Relleno(1202, 720, Color.FromArgb(255, 229, 204));
            Examen3.Clear();

           
            //El Saturno
            //1428, 725
            //1418, 796
            //1436, 750
            Rx = 40;
            Examen3.Add(new Point(1427, 725));
            Circunferencia(Examen3, Rx, Color.FromArgb(225, 178, 102));
            Relleno(1418, 707, Color.FromArgb(225, 178, 102));
            Relleno(1436, 736, Color.FromArgb(225, 178, 102));
            Relleno(1427, 725, Color.FromArgb(225, 178, 102));
            Examen3.Clear();
           
            //Como en el evento MouseClick, activa la imagen justo cuando lo presionan
            ptb_Lienzo.Image = Lienzo;

        }

        //MouseClick evento
        private void Ptb_Lienzo_MouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState.ToString() == "Maximized" && Lienzomax)
            {
                Lienzo = new Bitmap(Size.Width, Size.Height);
                Lienzomax = false;
            }


            switch (opcionMenu)
            {
                case "Pixel":
                    {
                        Pixeles(e.X, e.Y, color);
                        if (color == Color.Yellow && sizepincel == 2)
                        {
                            ListaAuxExamen1.Add(new Point(e.X, e.Y));
                            if (ListaAuxExamen1.Count >= 5)
                            {
                                btn_Examen1.Enabled = true;
                            }
                        }
                        Xc = e.X;
                        Yc = e.Y;
                        PuntosTG = new List<Point>(ListaPixeles);
                        ListaPixeles.Clear();
                    }
                    break;
                case "Recta":
                    {
                        Pixeles(e.X, e.Y, color);
                        ListaPixeles.Add(new Point(e.X, e.Y));
                        if (ListaPixeles.Count == 2)
                        {
                            Recta(ListaPixeles, color);
                            Xc = (ListaPixeles[0].X + ListaPixeles[1].X) / 2;
                            Yc = (ListaPixeles[0].Y + ListaPixeles[1].Y) / 2;
                            PuntosTG = new List<Point>(ListaPixeles);
                            ListaPixeles.Clear();
                        }

                    }
                    break;
                case "Poligono Irregular":
                    Pixeles(e.X, e.Y, color);
                    ListaPixeles.Add(new Point(e.X, e.Y));
                    if (ListaPixeles.Count == Lados)
                    {
                        PoligonoIrregular(ListaPixeles, color);
                        Xc = (ListaPixeles.Min(ListaPixeles => ListaPixeles.X) + ListaPixeles.Max(ListaPixeles => ListaPixeles.X)) / 2;
                        Yc = (ListaPixeles.Min(ListaPixeles => ListaPixeles.Y) + ListaPixeles.Max(ListaPixeles => ListaPixeles.Y)) / 2;
                        PuntosTG = new List<Point>(ListaPixeles);
                        ListaPixeles.Clear();
                    }
                    break;
                case "Poligono Regular":
                    if (Lados == 4 && Sx != Sy)
                    {
                        ListaPixeles.Add(new Point(e.X, e.Y));
                        PoligonoRegular(ListaPixeles, color);
                        Xc = e.X;
                        Yc = e.Y;
                        ListaPixeles.Clear();
                        Escalamiento(PuntosTG, Sx, Sy, color);
                    }
                    else
                    {
                        ListaPixeles.Add(new Point(e.X, e.Y));
                        PoligonoRegular(ListaPixeles, color);
                        Xc = e.X;
                        Yc = e.Y;
                        ListaPixeles.Clear();
                    }
                    break;

                case "Circunferencia":
                    ListaPixeles.Add(new Point(e.X, e.Y));
                    Circunferencia(ListaPixeles, Radio, color);
                    Xc = e.X;
                    Yc = e.Y;
                    PuntosTG = new List<Point>(ListaPixeles);
                    ListaPixeles.Clear();
                    break;

                case "Elipse":
                    ListaPixeles.Add(new Point(e.X, e.Y));
                    Elipse(ListaPixeles, Rx, Ry, color);
                    Xc = e.X;
                    Yc = e.Y;
                    PuntosTG = new List<Point>(ListaPixeles);
                    ListaPixeles.Clear();
                    break;
                
                case "Traslacion":
                    tx = e.X - Xc;
                    ty = e.Y - Yc;
                    Traslacion(PuntosTG, tx, ty, color);
                    Xc = e.X;
                    Yc = e.Y;
                    break;

                case "Rotacion":
                    Rotacion(PuntosTG, angulo, color);
                    break;

                case "Escalamiento":
                    Escalamiento(PuntosTG, Sx, Sy, color);
                    break;

                case "Relleno":
                    Relleno(e.X, e.Y, color);
                    break;
            }
            ptb_Lienzo.Image = Lienzo;
        }

        //Boton de limpieza
        private void Limpia_Click(object sender, EventArgs e)
        {
            Lienzo = new Bitmap(ptb_Lienzo.Width, ptb_Lienzo.Height);
            ptb_Lienzo.Image = Lienzo;
            ptb_Lienzo.BackColor = Color.FromArgb(241, 239, 226);



        }

        //metodos programados

        public void Pixeles(int X, int Y, Color pColor)
        {
            for (int i = -sizepincel; i <= sizepincel; i++)
            {
                for (int j = -sizepincel; j <= sizepincel; j++)
                {
                    if (X + i > 0 && X + i < Lienzo.Width && Y + j > 0 && Y + j < Lienzo.Height)
                    {
                        Lienzo.SetPixel(X + i, Y + j, pColor);
                    }
                }
            }
        }

        public void Recta(List<Point> pLista, Color pColor)
        {
            int DX, DY, X, Y, IncX, IncY, E, Contador;
            DX = pLista[1].X - pLista[0].X;
            DY = pLista[1].Y - pLista[0].Y;
            if (DX < 0)
            {
                IncX = -1;
                DX = -DX;
            }
            else
            {
                IncX = 1;
            }
            if (DY < 0)
            {
                IncY = -1;
                DY = -DY;
            }
            else
            {
                IncY = 1;
            }
            X = pLista[0].X;
            Y = pLista[0].Y;
            Pixeles(X, Y, pColor);
            if (DX > DY)
            {
                E = 2 * DY - DX;
                Contador = 0;
                while (X != pLista[1].X)
                {
                    X = X + IncX;
                    if (E < 0)
                    {
                        E = 2 * DY + E;
                    }
                    else
                    {
                        Y = Y + IncY;
                        E = 2 * (DY - DX) + E;
                    }
                    switch (Estilo)
                    {
                        case "default":
                            {
                                Pixeles(X, Y, pColor);
                                break;
                            }
                        case "punteado":
                            {
                                if (Contador % (2 + 4 * sizepincel) == 0)
                                {
                                    Pixeles(X, Y, pColor);
                                }
                                break;
                            }
                        case "segmentado":
                            {
                                if (sizepincel == 0 && Contador % 5 != 0)
                                {
                                    Pixeles(X, Y, pColor);
                                }
                                if (sizepincel != 0 && Contador % 20 == Contador % 10)
                                {
                                    Pixeles(X, Y, pColor);
                                }
                                break;
                            }

                    }
                    Contador++;

                }
            }
            else
            {
                E = 2 * DX - DY;
                Contador = 0;
                while (Y != pLista[1].Y)
                {
                    Y = Y + IncY;
                    if (E < 0)
                    {
                        E = (2 * DX) + E;
                    }
                    else
                    {
                        X = X + IncX;
                        E = 2 * (DX - DY) + E;
                    }
                    switch (Estilo)
                    {
                        case "default":
                            {
                                Pixeles(X, Y, pColor);
                                break;
                            }
                        case "punteado":
                            {
                                if (Contador % (2 + 4 * sizepincel) == 0)
                                {
                                    Pixeles(X, Y, pColor);
                                }
                                break;
                            }
                        case "segmentado":
                            {
                                if (sizepincel == 0 && Contador % 5 != 0)
                                {
                                    Pixeles(X, Y, pColor);
                                }
                                if (sizepincel != 0 && Contador % 20 == Contador % 10)
                                {
                                    Pixeles(X, Y, pColor);
                                }
                                break;
                            }

                    }
                    Contador++;
                }
            }
        }

        public void PoligonoIrregular(List<Point> Pixeles, Color color)
        {
            for (int i = 0; i < Pixeles.Count - 1; i++)
            {
                Aux.Add(new Point(Pixeles[i].X, Pixeles[i].Y));
                Aux.Add(new Point(Pixeles[i + 1].X, Pixeles[i + 1].Y));
                Recta(Aux, color);
                Aux.Clear();
            }
            Aux.Add(new Point(Pixeles[0].X, Pixeles[0].Y));
            Aux.Add(new Point(Pixeles[Pixeles.Count - 1].X, Pixeles[Pixeles.Count - 1].Y));
            Recta(Aux, color);
            Aux.Clear();

        }

       

        public void PoligonoRegular(List<Point> Pixeles, Color color)
        {
            Double angulo, X, Y, i;
            angulo = 360 / Lados;
            for (i = 0; i < 360; i = i + angulo)
            {
                X = Pixeles[0].X + Rx * Math.Cos((i + 90 * (Lados - 2) / Lados) * Math.PI / 180);
                Y = Pixeles[0].Y + Rx * Math.Sin((i + 90 * (Lados - 2) / Lados) * Math.PI / 180);
                Aux2.Add(new Point(Convert.ToInt32(X), Convert.ToInt32(Y)));
            
            }
            
            PoligonoIrregular(Aux2, color);
            PuntosTG = new List<Point>(Aux2);
            Aux2.Clear();
        }

        //Algortimo de Bresenham para Circunferencia
        public void Circunferencia(List<Point> ListaPixeles, int r, Color ColorPixel)
        {
            int x, y, e, Contador;
            x = Rx; y = 0; e = 0; Contador = 0;
            while (y <= x)
            {
                switch (Estilo)
                {
                    case "default":
                        {
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y + x, ColorPixel);
                            Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y + x, ColorPixel);
                            Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y - x, ColorPixel);
                            Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y - x, ColorPixel);
                            break;
                        }
                    case "punteado":
                        {
                            if (Contador % (2 + 4 * sizepincel) == 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y - x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y - x, ColorPixel);
                            }
                            break;
                        }
                    case "segmentado":
                        {
                            if (sizepincel == 0 && Contador % 5 != 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y - x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y - x, ColorPixel);
                            }
                            if (sizepincel != 0 && Contador % 20 == Contador % 10)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y - x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y - x, ColorPixel);
                            }
                            break;
                        }

                }
                Contador++;

                switch (Estilo)
                {
                    case "default":
                        {
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y + x, ColorPixel);
                            Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y + x, ColorPixel);
                            Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y - x, ColorPixel);
                            Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y - x, ColorPixel);
                            break;
                        }
                    case "punteado":
                        {
                            if (Contador % (2 + 4 * sizepincel) == 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y - x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y - x, ColorPixel);
                            }
                            break;
                        }
                    case "segmentado":
                        {
                            if (sizepincel == 0 && Contador % 5 != 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y - x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y - x, ColorPixel);
                            }
                            if (sizepincel != 0 && Contador % 20 == Contador % 10)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y + x, ColorPixel);
                                Pixeles(ListaPixeles[0].X + y, ListaPixeles[0].Y - x, ColorPixel);
                                Pixeles(ListaPixeles[0].X - y, ListaPixeles[0].Y - x, ColorPixel);
                            }
                            break;
                        }

                }
                Contador++;
                e = e + 2 * y + 1;
                y = y + 1;
                if (2 * e > 2 * x - 1)
{
                    x = x - 1;
                    e = e - 2 * x + 1;
                }
            }
        }

        //Algortimo de Bresenham para la Elipse

        public void Elipse(List<Point> ListaPixeles, int Rx, int Ry, Color ColorPixel)
        {
            int x, y, e, Contador;
            x = 0;
            y = Ry;
            e = 2 * Ry * Ry + (1 - 2 * Ry) * (Rx * Rx);
            Contador = 0;
            while (Ry * Ry * x <= Rx * Rx * y)
            {
                switch (Estilo)
                {
                    case "default":
                        {
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            break;
                        }
                    case "punteado":
                        {
                            if (Contador % (2 + 4 * sizepincel) == 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            break;
                        }
                    case "segmentado":
                        {
                            if (sizepincel == 0 && Contador % 5 != 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            if (sizepincel != 0 && Contador % 20 == Contador % 10)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            break;
                        }

                }
                Contador++;


                switch (Estilo)
                {
                    case "default":
                        {
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            break;
                        }
                    case "punteado":
                        {
                            if (Contador % (2 + 4 * sizepincel) == 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            break;
                        }
                    case "segmentado":
                        {
                            if (sizepincel == 0 && Contador % 5 != 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            if (sizepincel != 0 && Contador % 20 == Contador % 10)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            break;
                        }

                }
                Contador++;
                x = x + 1;
                if (e >= 0)
                {
                    e = e + 4 * Rx * Rx * (1 - y);
                    y = y - 1;
                }
                e = e + Ry * Ry * (4 * x + 6);
            }

            x = Rx;
            y = 0;
            e = 2 * Rx * Rx + (1 - 2 * Rx) * (Ry * Ry);
            Contador = 0;
            while (Rx * Rx * y <= Ry * Ry * x)
            {
                switch (Estilo)
                {
                    case "default":
                        {
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            break;
                        }
                    case "punteado":
                        {
                            if (Contador % (2 + 4 * sizepincel) == 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            break;
                        }
                    case "segmentado":
                        {
                            if (sizepincel == 0 && Contador % 5 != 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            if (sizepincel != 0 && Contador % 20 == Contador % 10)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            break;
                        }

                }
                Contador++;


                switch (Estilo)
                {
                    case "default":
                        {
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                            Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            break;
                        }
                    case "punteado":
                        {
                            if (Contador % (2 + 4 * sizepincel) == 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            break;
                        }
                    case "segmentado":
                        {
                            if (sizepincel == 0 && Contador % 5 != 0)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            if (sizepincel != 0 && Contador % 20 == Contador % 10)
                            {
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X + x, ListaPixeles[0].Y - y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y + y, ColorPixel);
                                Pixeles(ListaPixeles[0].X - x, ListaPixeles[0].Y - y, ColorPixel);
                            }
                            break;
                        }

                }
                Contador++;
                y = y + 1;
                if (e >= 0)
                {
                    e = e + 4 * Ry * Ry * (1 - x);
                    x = x - 1;
                }
                e = e + Rx * Rx * (4 * y + 6);
            }
        }
    
        private void Traslacion (List<Point> PuntosTG, int tx, int ty, Color ColorPixel)
        {
            for (int i = 0; i < PuntosTG.Count; i++)
            {
                x = PuntosTG[i].X + tx;
                y = PuntosTG[i].Y + ty;
                PuntosT.Add(new Point(x, y));
            }

            switch (id)
            {
                case "Pixel":

                    Pixeles(PuntosTG[0].X, PuntosTG[0].Y, CFondo);
                    Pixeles(PuntosT[0].X, PuntosT[0].Y, ColorPixel);
                    break;

                case "Recta":

                    Recta(PuntosTG, CFondo);
                    Recta(PuntosT, ColorPixel);
                    break;

                case "Poligono Irregular":

                    PoligonoIrregular(PuntosTG, CFondo);
                    PoligonoIrregular(PuntosT, ColorPixel);
                    break;

                case "Poligono Regular":

                    PoligonoIrregular(PuntosTG, CFondo);
                    PoligonoIrregular(PuntosT, ColorPixel);
                    break;

                case "Circunferencia":

                    Circunferencia(PuntosTG, Rx, CFondo);
                    Circunferencia(PuntosT, Rx, ColorPixel);
                    break;

                case "Elipse":

                    Elipse(PuntosTG, Rx, Ry, CFondo);
                    Elipse(PuntosT, Rx, Ry, ColorPixel);
                    break;
            }
            for (int j = 0; j < PuntosTG.Count; j++)
            {
                PuntosTG[j] = PuntosT[j];
            }
            PuntosT.Clear();

        }

        private void Rotacion(List<Point> PuntosTG, int angulo, Color ColorPixel)
        {
            
            for (int i = 0; i < PuntosTG.Count; i++)
            {
                x = Convert.ToInt32(Xc + (PuntosTG[i].X - Xc) * Math.Cos(angulo * Math.PI / 180) - (PuntosTG[i].Y - Yc) * Math.Sin(angulo * Math.PI / 180));
                y = Convert.ToInt32(Yc + (PuntosTG[i].X - Xc) * Math.Sin(angulo * Math.PI / 180) + (PuntosTG[i].Y - Yc) * Math.Cos(angulo * Math.PI / 180));
                PuntosT.Add(new Point(x, y));
            }

            switch (id)
            {
                case "Pixel":

                    Pixeles(PuntosTG[0].X, PuntosTG[0].Y, color);
                    Pixeles(PuntosT[0].X, PuntosT[0].Y, CFondo);
                    break;

                case "Recta":

                    Recta(PuntosTG, CFondo);
                    Recta(PuntosT, color);
                    break;

                case "Poligono Irregular":

                    PoligonoIrregular(PuntosTG, CFondo);
                    PoligonoIrregular(PuntosT, color);
                    break;

                case "Poligono Regular":

                    PoligonoIrregular(PuntosTG, CFondo);
                    PoligonoIrregular(PuntosT, color);
                    break;

                case "Circunferencia":

                    Circunferencia(PuntosTG, Rx, CFondo);
                    Circunferencia(PuntosT, Rx, ColorPixel);
                    break;

                case "Elipse":

                    Elipse(PuntosTG, Rx, Ry, CFondo);
                    Elipse(PuntosT, Ry, Rx, ColorPixel);
                    auxiliar = Rx;
                    Rx = Ry;
                    Ry = auxiliar;
                    break;
            }
            for (int j = 0; j < PuntosTG.Count; j++)
            {
                PuntosTG[j] = PuntosT[j];
            }
            Aux3 = new List<Point>(PuntosT);
            PuntosT.Clear();

        }

        public void Escalamiento(List<Point> PuntosTG, float Sx, float Sy, Color ColorPixel)  
        {
            for (int i = 0; i < PuntosTG.Count; i++)
            {
                x = Convert.ToInt32(Xc + Sx * (PuntosTG[i].X - Xc));
                y = Convert.ToInt32(Yc + Sy * (PuntosTG[i].Y - Yc));
                PuntosT.Add(new Point(x, y));
            }
            switch (id)
            {
                case "Píxel":
                    Pixeles(PuntosTG[0].X, PuntosTG[0].Y, CFondo);
                    Pixeles(PuntosT[0].X, PuntosT[0].Y, ColorPixel);
                    break;

                case "Recta":
                    Recta(PuntosTG, CFondo);
                    Recta(PuntosT, ColorPixel);
                    break;

                case "Poligono Irregular":
                    PoligonoIrregular(PuntosTG, CFondo);
                    PoligonoIrregular(PuntosT, ColorPixel);
                    break;

                case "Poligono Regular":
                    PoligonoIrregular(PuntosTG, CFondo);
                    PoligonoIrregular(PuntosT, ColorPixel);
                    break;

                case "Circunferencia":
                    Circunferencia(PuntosTG, Radio, CFondo);
                    Radio = Convert.ToInt32(Sx * Radio);
                    Circunferencia(PuntosT, Radio, ColorPixel);
                    break;

                case "Elipse":
                    Elipse(PuntosTG, Rx, Ry, CFondo);
                    Rx = Convert.ToInt32(Sx * Rx);
                    Ry = Convert.ToInt32(Sy * Ry);
                    Elipse(PuntosT, Rx, Ry, ColorPixel);
                    break;
            }
            for (int j = 0; j < PuntosTG.Count; j++)
            {
                PuntosTG[j] = PuntosT[j];
            }
            PuntosT.Clear();
        }

        private void Relleno(int X, int Y, Color CRelleno)
        {
            CRelleno = Color.FromArgb(CRelleno.ToArgb());
            Color ColorF = Lienzo.GetPixel(X, Y);
            Stack<Point> Vecinos = new Stack<Point>();
            Vecinos.Push(new Point(X, Y));
            while (Vecinos.Count != 0)
            {
                Point p = Vecinos.Pop();
                if (p.X > 0 && p.X < Lienzo.Width && p.Y > 0 && p.Y < Lienzo.Height)
                {
                    if (ColorF != CRelleno && ColorF == Lienzo.GetPixel(p.X, p.Y))
                    {
                        Lienzo.SetPixel(p.X, p.Y, CRelleno);
                        Vecinos.Push(new Point(p.X + 1, p.Y));
                        Vecinos.Push(new Point(p.X - 1, p.Y));
                        Vecinos.Push(new Point(p.X, p.Y + 1));
                        Vecinos.Push(new Point(p.X, p.Y - 1));
                    }
                }
            }
        }

        public void BotonSeleccionado(Button boton, GroupBox grupo)
        {
            var Botones = grupo.Controls.OfType<Button>();
            foreach (Button btn in Botones)
            {
                if (btn == boton)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.LightSteelBlue;
                }
                else
                {
                    btn.FlatStyle = FlatStyle.Standard;
                    btn.BackColor = Color.Transparent;
                }
            }
        }

        private void ptb_Lienzo_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_coordenadas.Text = "Coordenadas: " + e.X + ", " + e.Y;
        }

        
    }
}   

