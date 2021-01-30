using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;

namespace luby_incubadora3
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        // instanciando variáveis globais da Coca-cola
        Bebida coca = new Bebida(5, 5);
        TextBlock texto_q_coca = new TextBlock();

        // instanciando variáveis globais da Sprite
        Bebida sprite = new Bebida(4, 10);
        TextBlock texto_q_sprite = new TextBlock();

        // instanciando variáveis globais da Fanta
        Bebida fanta = new Bebida(3, 15);
        TextBlock texto_q_fanta = new TextBlock();

        // valor total de vendas
        int valor_vendas = 0;

        public MainWindow()
        {
            InitializeComponent();

            // criação do Grid
            Grid grid = new Grid();
            this.Content = grid;

            // criação do cabeçalho
            WrapPanel wrap_cabecalho = new WrapPanel();
            TextBlock cabecalho = new TextBlock();
            cabecalho.Text = "Bem-vindo(a) à Vending Machine da Incubadora Lupy!";
            cabecalho.Foreground = Brushes.Black;
            cabecalho.FontSize = 25;
            wrap_cabecalho.HorizontalAlignment = HorizontalAlignment.Center;
            wrap_cabecalho.Children.Add(cabecalho);
            grid.Children.Add(wrap_cabecalho);

            // criação do texto "Coca-cola"
            WrapPanel wrap_coca = new WrapPanel();
            TextBlock texto_coca = new TextBlock();
            texto_coca.Text = "Coca-Cola";
            texto_coca.Foreground = Brushes.Red;
            texto_coca.FontSize = 25;
            wrap_coca.HorizontalAlignment = HorizontalAlignment.Center;
            wrap_coca.VerticalAlignment = VerticalAlignment.Center;
            wrap_coca.Margin = new Thickness(0, -100, 0, 0);
            wrap_coca.Children.Add(texto_coca);
            grid.Children.Add(wrap_coca);

            // criação do preço da Coca-cola
            WrapPanel wrap_p_coca = new WrapPanel();
            TextBlock texto_p_coca = new TextBlock();
            texto_p_coca.Text = coca.valor_formatado;
            texto_p_coca.Foreground = Brushes.Black;
            texto_p_coca.FontSize = 20;
            wrap_p_coca.Children.Add(texto_p_coca);
            wrap_coca.Children.Add(wrap_p_coca);
            wrap_p_coca.Margin = new Thickness(-90, 40, 0, 0);

            // criação da quantidade atual de Coca-cola
            WrapPanel wrap_q_coca = new WrapPanel();
            texto_q_coca.Text = "Quantidade: " + Convert.ToString(coca.qnt_cur);
            texto_q_coca.Foreground = Brushes.Black;
            texto_q_coca.FontSize = 20;
            wrap_q_coca.Children.Add(texto_q_coca);
            wrap_coca.Children.Add(wrap_q_coca);
            wrap_q_coca.Margin = new Thickness(-120, 70, 0, 0);

            // criação do botão de comprar Coca-cola
            Button botao_coca = new Button();
            botao_coca.FontSize = 20;
            botao_coca.Height = 30;
            botao_coca.Width = 100;
            WrapPanel wrap_b_coca = new WrapPanel();
            TextBlock texto_b_coca = new TextBlock();
            texto_b_coca.Text = "Comprar";
            texto_b_coca.Foreground = Brushes.Black;
            wrap_b_coca.Children.Add(texto_b_coca);
            botao_coca.Content = wrap_b_coca;
            wrap_q_coca.Children.Add(botao_coca);
            botao_coca.Margin = new Thickness(-125, 40, 0, 0);

            // funcionalidade do botão de comprar Coca-cola
            botao_coca.Click += Click_botao_coca;

            // criação do texto "Sprite"
            WrapPanel wrap_sprite = new WrapPanel();
            TextBlock texto_sprite = new TextBlock();
            texto_sprite.Text = "Sprite";
            texto_sprite.Foreground = Brushes.Green;
            texto_sprite.FontSize = 25;
            wrap_sprite.VerticalAlignment = VerticalAlignment.Center;
            wrap_sprite.HorizontalAlignment = HorizontalAlignment.Center;
            wrap_sprite.Margin = new Thickness(-500, -100, 0, 0);
            wrap_sprite.Children.Add(texto_sprite);
            grid.Children.Add(wrap_sprite);

            // criação do preço da Sprite
            WrapPanel wrap_p_sprite = new WrapPanel();
            TextBlock texto_p_sprite = new TextBlock();
            texto_p_sprite.Text = sprite.valor_formatado;
            texto_p_sprite.Foreground = Brushes.Black;
            texto_p_sprite.FontSize = 20;
            wrap_p_sprite.Children.Add(texto_p_sprite);
            wrap_sprite.Children.Add(wrap_p_sprite);
            wrap_p_sprite.Margin = new Thickness(-65, 40, 0, 0);

            // criação da quantidade atual de Sprite
            WrapPanel wrap_q_sprite = new WrapPanel();
            texto_q_sprite.Text = "Quantidade: " + Convert.ToString(sprite.qnt_cur);
            texto_q_sprite.Foreground = Brushes.Black;
            texto_q_sprite.FontSize = 20;
            wrap_q_sprite.Children.Add(texto_q_sprite);
            wrap_sprite.Children.Add(wrap_q_sprite);
            wrap_q_sprite.Margin = new Thickness(-95, 70, 0, 0);

            // criação do botão de comprar Sprite
            Button botao_sprite = new Button();
            botao_sprite.FontSize = 20;
            botao_sprite.Height = 30;
            botao_sprite.Width = 100;
            WrapPanel wrap_b_sprite = new WrapPanel();
            TextBlock texto_b_sprite = new TextBlock();
            texto_b_sprite.Text = "Comprar";
            texto_b_sprite.Foreground = Brushes.Black;
            wrap_b_sprite.Children.Add(texto_b_sprite);
            botao_sprite.Content = wrap_b_sprite;
            wrap_sprite.Children.Add(botao_sprite);
            botao_sprite.Margin = new Thickness(-130, 108, 0, 0);

            // funcionalidade do botão de comprar Sprite
            botao_sprite.Click += Click_botao_sprite;

            // criação do texto "Fanta"
            WrapPanel wrap_fanta = new WrapPanel();
            TextBlock texto_fanta = new TextBlock();
            texto_fanta.Text = "Fanta";
            texto_fanta.Foreground = Brushes.Orange;
            texto_fanta.FontSize = 25;
            wrap_fanta.VerticalAlignment = VerticalAlignment.Center;
            wrap_fanta.HorizontalAlignment = HorizontalAlignment.Center;
            wrap_fanta.Margin = new Thickness(500, -100, 0, 0);
            wrap_fanta.Children.Add(texto_fanta);
            grid.Children.Add(wrap_fanta);

            // criação do preço da Fanta
            WrapPanel wrap_p_fanta = new WrapPanel();
            TextBlock texto_p_fanta = new TextBlock();
            texto_p_fanta.Text = fanta.valor_formatado;
            texto_p_fanta.Foreground = Brushes.Black;
            texto_p_fanta.FontSize = 20;
            wrap_p_fanta.Children.Add(texto_p_fanta);
            wrap_fanta.Children.Add(wrap_p_fanta);
            wrap_p_fanta.Margin = new Thickness(-62, 40, 0, 0);

            // criação da quantidade atual de Fanta
            WrapPanel wrap_q_fanta = new WrapPanel();
            texto_q_fanta.Text = "Quantidade: " + Convert.ToString(fanta.qnt_cur);
            texto_q_fanta.Foreground = Brushes.Black;
            texto_q_fanta.FontSize = 20;
            wrap_q_fanta.Children.Add(texto_q_fanta);
            wrap_fanta.Children.Add(wrap_q_fanta);
            wrap_q_fanta.Margin = new Thickness(-95, 70, 0, 0);

            // criação do botão de comprar Fanta
            Button botao_fanta = new Button();
            botao_fanta.FontSize = 20;
            botao_fanta.Height = 30;
            botao_fanta.Width = 100;
            WrapPanel wrap_b_fanta = new WrapPanel();
            TextBlock texto_b_fanta = new TextBlock();
            texto_b_fanta.Text = "Comprar";
            texto_b_fanta.Foreground = Brushes.Black;
            wrap_b_fanta.Children.Add(texto_b_fanta);
            botao_fanta.Content = wrap_b_fanta;
            wrap_fanta.Children.Add(botao_fanta);
            botao_fanta.Margin = new Thickness(-140, 108, 0, 0);

            // funcionalidade do botão de comprar Fanta
            botao_fanta.Click += Click_botao_fanta;

            // criação do botão Admin
            Button botao_admin = new Button();
            botao_admin.FontSize = 20;
            botao_admin.Height = 30;
            botao_admin.Width = 100;
            WrapPanel wrap_b_admin = new WrapPanel();
            TextBlock texto_b_admin = new TextBlock();
            texto_b_admin.Text = "Admin";
            texto_b_admin.Foreground = Brushes.Black;
            wrap_b_admin.Children.Add(texto_b_admin);
            botao_admin.Content = wrap_b_admin;
            botao_admin.HorizontalAlignment = HorizontalAlignment.Center;
            grid.Children.Add(botao_admin);
            botao_admin.Margin = new Thickness(0, 280, 0, 0);

            // funcionalidade do botão Admin
            botao_admin.Click += Click_botao_admin;
        }

        void Click_botao_coca(object sender, RoutedEventArgs e)
        {
            coca.Comprar();
            texto_q_coca.Text = "Quantidade: " + Convert.ToString(coca.qnt_cur);
            valor_vendas += coca.valor;
        }

        void Click_botao_sprite(object sender, RoutedEventArgs e)
        {
            sprite.Comprar();
            texto_q_sprite.Text = "Quantidade: " + Convert.ToString(sprite.qnt_cur);
            valor_vendas += sprite.valor;
        }

        void Click_botao_fanta(object sender, RoutedEventArgs e)
        {
            fanta.Comprar();
            texto_q_fanta.Text = "Quantidade: " + Convert.ToString(fanta.qnt_cur);
            valor_vendas += fanta.valor;
        }

        void Click_botao_admin(object sender, RoutedEventArgs e)
        {
            string resposta = Microsoft.VisualBasic.Interaction.InputBox("Por favor, insira a senha de administrador(a).", "Admin Login", "");
            if (resposta == "admin")
            {
                string valor_vendas_formatado = (valor_vendas).ToString("C");
                MessageBox.Show("Total em vendas até o momento: " + valor_vendas_formatado);
            }
            else
            {
                MessageBox.Show("Senha incorreta. Por favor, tente novamente ou peça permissão à Administração.");
            }
        }

    }

    class Bebida
    {
        public int valor;
        public string valor_formatado;
        public int valor_vendido = 0;
        public int qnt_ini;
        public int qnt_cur;
        public Bebida (int val, int qty_ini)
        {
            valor = val;
            qnt_ini = qty_ini;
            qnt_cur = qty_ini;
            valor_formatado = (valor).ToString("C");
        }
        public void Comprar()
        {
            if (qnt_cur > 0)
            {
                string resposta = Microsoft.VisualBasic.Interaction.InputBox("Por favor, insira o valor do produto.", "Comprar produto", "");
                int valor_pago = int.Parse(resposta);
                if (valor_pago < valor)
                {
                    while (valor - valor_pago > 0)
                    {
                        int falt = valor - valor_pago;
                        string falt_formatado = (falt).ToString("C");
                        string resposta2 = Microsoft.VisualBasic.Interaction.InputBox("Por favor, insira o valor restante de " + falt_formatado + ".", "Inteirar valor", "");
                        valor_pago += int.Parse(resposta2);
                    }
                    MessageBox.Show("Obrigado por comprar o produto!");
                    qnt_cur -= 1;
                    valor_vendido += valor;
                }
                else if (valor_pago == valor)
                {
                    MessageBox.Show("Obrigado por comprar o produto!");
                    qnt_cur -= 1;
                    valor_vendido += valor;
                }
                else if (valor_pago > valor)
                {
                    int dif = valor_pago - valor;
                    string dif_formatada = (dif).ToString("C");
                    MessageBox.Show("Obrigado por comprar o produto! Aqui estão os " + dif_formatada + " de troco!");
                    qnt_cur -= 1;
                    valor_vendido += valor;
                }
            }
            else if (qnt_cur == 0)
            {
                qnt_cur = 0;
                MessageBox.Show("Infelizmente o produto acabou, tente comprar outro, por favor.");
            }
        }
    }
}
