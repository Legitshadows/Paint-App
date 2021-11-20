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
        int sizepincel, Lados, Rx, Ry, Xc, Yc, tx, ty;
        string opcionMenu, id;
        List<Point> ListaPixeles, Aux, Aux2, PuntosTG, PuntosT;
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
            Estilo = "default";
            Lienzomax = true;
            Rx = 80;
            Ry = 120;

        }

        //Control de los elementos de menu
        private void Pixel_Click(object sender, EventArgs e)
        {
            opcionMenu = "Pixel";
        }

        private void Recta_Click(object sender, EventArgs e)
        {
            opcionMenu = "Recta";

            id = "Recta";
        }

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

        private void btn_PolignoRegular_Click(object sender, EventArgs e)
        {
            opcionMenu = "Poligono Regular";
            id = "Poligono Regular";
        }

        private void btn_Circunferencia_Click(object sender, EventArgs e)
        {
            opcionMenu = "Circunferencia";
            id = "Circunferencia";
        }

        private void btn_Triangulo_Click(object sender, EventArgs e)
        {
            Lados = 3;
        }

        private void btn_Cuadrado_Click(object sender, EventArgs e)
        {
            Lados = 4;
        }

        private void btn_Pentagono_Click(object sender, EventArgs e)
        {
            Lados = 5;
        }

        private void btn_Hexagono_Click(object sender, EventArgs e)
        {
            Lados = 6;
        }

        private void btn_Elipse_Click(object sender, EventArgs e)
        {
            opcionMenu = "Elipse";
            id = "Elipse";
        }

        private void btn_Traslacion_Click(object sender, EventArgs e)
        {
            opcionMenu = "Traslacion";
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
                    ListaPixeles.Add(new Point(e.X, e.Y));
                    PoligonoRegular(ListaPixeles, color);
                    Xc = e.X;
                    Yc = e.Y;
                    PuntosTG = new List<Point>(ListaPixeles);
                    ListaPixeles.Clear();
                    break;

                case "Circunferencia":
                    ListaPixeles.Add(new Point(e.X, e.Y));
                    Circunferencia(ListaPixeles, Rx, color);
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
            }
            ptb_Lienzo.Image = Lienzo;
        }

        //Boton de limpieza
        private void Limpia_Click(object sender, EventArgs e)
        {
            ptb_Lienzo.Image = Lienzo;
            Lienzo = new Bitmap(ptb_Lienzo.Width, ptb_Lienzo.Height);
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
            double angulo, X, Y, i;
            angulo = 360 / Lados;
            for (i = 0; i < 360; i = i + angulo)
            {
                X = Pixeles[0].X + Rx * Math.Cos(i * Math.PI / 180);
                Y = Pixeles[0].Y + Rx * Math.Sin(i * Math.PI / 180);
                Aux2.Add(new Point(Convert.ToInt32(X), Convert.ToInt32(Y)));
            }
            PoligonoIrregular(Aux2, color);
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
                PuntosT.Add(new Point(PuntosTG[i].X + tx, PuntosTG[i].Y + ty));
            }

            switch (id)
            {
                case "Pixel":

                    Pixeles(PuntosT[0].X, PuntosT[0].Y, color);
                    Pixeles(PuntosTG[0].X, PuntosTG[0].Y, CFondo);
                    break;

                case "Recta":
                    
                        Recta(PuntosT, color);
                        Recta(PuntosTG, CFondo);
                        break;

                case "Poligono Irregular":

                    PoligonoIrregular(PuntosT, color);
                    PoligonoIrregular(PuntosTG, CFondo);
                    break;

                case "Poligono Regular":

                    PoligonoRegular(PuntosT, color);
                    PoligonoRegular(PuntosTG, CFondo);
                    break;

                case "Circunferencia":

                    Circunferencia(PuntosT, Rx, ColorPixel);
                    Circunferencia(PuntosTG, Rx, CFondo);
                    break;

                case "Elipse":

                    Elipse(PuntosT, Rx, Ry, ColorPixel);
                    Elipse(PuntosTG,Rx, Ry, CFondo);
                    break;
            }
            for (int j = 0; j < PuntosTG.Count; j++)
            {
                PuntosTG[j] = PuntosT[j];
            }
            PuntosT.Clear();

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

