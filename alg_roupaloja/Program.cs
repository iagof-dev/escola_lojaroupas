

using ConsoleTables;
using System.Net;

string[] user_nome = new string[99999];
double[] user_total = new double[99999];
string[] user_roupascom = new string[99999];
int[] user_roupasqnt = new int[99999];
double[] user_roupasval = new double[99999];


double total = 0;
int vend_det = 1;
string resp = string.Empty;


vend_cab();


void vend_cab()
{
    for (int i = 0; i <= vend_det; i++)
    {
        total = 0;
        vend_det = 1;
        resp = string.Empty;
        Console.WriteLine("Digite o nome da Cliente");
        user_nome[i] = Console.ReadLine();


        for (int c = 0; c < vend_det; c++)
        {
            Console.Title = "Cliente: " + user_nome[i] + " | Quantidade:" + vend_det;
            Console.Clear();
            Console.WriteLine("Nome da Roupa: ");
            string roupa = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Quantidade Desejada:");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            user_roupasqnt[vend_det] = quantidade;

            Console.Clear();
            Console.WriteLine("Valor Unitario:");
            double valor = Convert.ToDouble(Console.ReadLine());
            

            total += quantidade * valor;

            user_total[i] = total;
            user_roupasval[vend_det] = valor;
            user_roupascom[vend_det] = roupa;

            Console.WriteLine("Total deu: R$" + user_total[i]);
            Console.WriteLine("Deseja Vender mais uma roupa? (S/N)");
            resp = Console.ReadLine();

            if (resp == "S" || resp =="s")
            {
                vend_det += 1;
            }
            else
            {
                break;
            }
        }

        if (resp == "N" || resp == "n")
        {
            Console.Clear();
            Console.WriteLine("Cliente: " + user_nome[i]);
            Console.WriteLine("\n=========Resumo do Pedido=========");
            var table = new ConsoleTable("Nome", "Quantidade", "Valor Unitario");
            for (int l = 1; l <= vend_det; l++)
            {
                table.AddRow(user_roupascom[l], user_roupasqnt[l], "R$"+user_roupasval[l]);
            }
            table.Write();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTotal:          R$" + user_total[i]);
            Console.ResetColor();
            Console.WriteLine("===== Formas de Pagamento ======");
            Console.WriteLine("Formas de Pagamento:");
            Console.WriteLine("[1] Dinheiro");
            Console.WriteLine("[2] Cartão De Crédito");
            Console.WriteLine("[3] Cartão De Débito");
            Console.WriteLine("[4] Vale Refeição");
            Console.WriteLine("[5] PIX");
            Console.WriteLine("=========================");
            Console.Write(">");
            int fpaga = Convert.ToInt32(Console.ReadLine());

            switch (fpaga)
            {
                case 1:

                    Console.WriteLine("\nDigite o valor inicial do cliente:");
                    double dado = Convert.ToDouble(Console.ReadLine());

                    if (dado > user_total[i])
                    {
                        Console.WriteLine("Você deve de troco: R$" + (dado - user_total[i]));
                        Console.ReadKey();
                    }


                    if(dado < user_total[i])
                    {
                        double devedor = (user_total[i] - dado);
                        Console.WriteLine("O Cliente ainda deve: R$" + devedor);
                        Console.ReadKey();
                    }
                    {
                        Console.WriteLine("Você não deve troco :)");
                        Console.ReadKey();
                    }
                    break;

                case 5:
                    Console.WriteLine("Gerando Código QR...");
                    
                    WebClient web = new WebClient();
                    string qr = web.DownloadString("https://pastebin.com/raw/e4wtzXER");
                    Console.Clear();
                    Console.WriteLine("Pix - QR CODE:");
                    Console.WriteLine(qr);
                    Console.ReadKey();
                    break;


                default:
                    break;
            }
            Console.Clear();


        }
    }
}





