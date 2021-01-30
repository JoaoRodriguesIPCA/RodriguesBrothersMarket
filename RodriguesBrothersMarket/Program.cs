﻿using System;

namespace RodriguesBrothersMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            string nPosition, nUser, nPassword;
            string nName, nCategory;
            int nProductQnt;
            int nPrice;
            string saleProductName;
            int saleProductQnt;

            MarketTeam uList = new MarketTeam();
            Stock pList = new Stock();
            Invoice iList = new Invoice();
            //Console.WriteLine(n.invoiceList[0].productName);

            /*
            n.invoiceList.Add(new InvoiceLine("batatas", 3, 6));
            n.invoiceList.Add(new InvoiceLine("arroz", 7, 1));
            n.invoiceList.Add(new InvoiceLine("atum", 10, 5));
            
            n.SaveInvoice();
            */
            uList.ReadUsersFile();

            pList.ReadFromFileStock();


            while (selection != 3)
            {
                Console.WriteLine("     **RodriguesBrothersMarket**");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Criar Funcionário");
                Console.WriteLine("3 - Sair");

                selection = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("     **Efetue o seu login**");

                        Console.WriteLine("Insira a função do utilizador: ( GERENTE | REPPOSITOR | CAIXA )");
                        nPosition = Console.ReadLine();
                        Console.WriteLine("Insira o nome de utilizador: ");
                        nUser = Console.ReadLine();
                        Console.WriteLine("Insira a password: ");
                        nPassword = Console.ReadLine();

                        User userMatch = uList.Login(nPosition, nUser, nPassword);
                        if (userMatch != null)
                        {
                            if (userMatch.position == "gerente")
                            {
                                Console.WriteLine("OPERAÇÂO LOGIN: Efetuada com sucesso!");
                                MenuManager(uList);
                            }
                            if (userMatch.position == "repositor")
                            {
                                Console.WriteLine("OPERAÇÂO LOGIN: Efetuada com sucesso!");
                                MenuReplanisher();
                            }
                            if (userMatch.position == "caixa")
                            {
                                Console.WriteLine("OPERAÇÂO LOGIN: Efetuada com sucesso!");
                                MenuCashier();
                            }

                        }
                        break;

                    case 2:
                        Console.WriteLine("     **Criar Funcionário**");

                        Console.WriteLine("Insira a função do novo utilizador:");
                        nPosition = Console.ReadLine();

                        Console.WriteLine("Insira o nome do novo utilizador:");
                        nUser = Console.ReadLine();

                        Console.WriteLine("Insira a password:");
                        nPassword = Console.ReadLine();

                        uList.CreateUser(nPosition, nUser, nPassword);

                        uList.SaveToFileUsers();
                        //Console.WriteLine(uList.ToString());
                        break;

                    case 3:
                        Console.WriteLine("Vai Sair");
                        break;

                    default:
                        Console.WriteLine("Opção Inválida. Tente novamente");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("Obrigado Pela Preferência | R&R Market!!!");


            static void MenuManager(MarketTeam uList)
            {
                int managerSelection = 0;
                while (managerSelection != 3)
                {
                    Console.WriteLine("     **MENU DO GERENTE**");

                    Console.WriteLine("1 - Apagar Funcionários");
                    Console.WriteLine("2 - Vender Produtos");
                    Console.WriteLine("3 - Voltar");

                    managerSelection = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (managerSelection)
                    {
                        case 1:
                            Console.WriteLine("Introduza o nome do funcionário que pretende eliminar");
                            string managerInput = Console.ReadLine();
                            bool result = uList.RemoveFromUsersList(managerInput);
                            if (result)
                            {
                                Console.WriteLine("Utilizador eliminado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Operação sem sucesso!");
                            }

                            uList.SaveToFileUsers();
                            break;

                        case 2:
                            Console.WriteLine("Funcionalidade de Vender Produtos");  
                            break;

                        case 3: return;

                        default:
                            Console.WriteLine("Opção Inválida. Tente novamente");
                            break;
                    }
                }
            }

            void MenuReplanisher()
            {
                int replanisherSelection = 0;
                while (replanisherSelection != 4)
                {
                    Console.WriteLine("     **MENU DO REPOSITOR**");

                    Console.WriteLine("1 - Adicionar um novo produto ao stock");
                    Console.WriteLine("2 - Remover produtos ao stock");
                    Console.WriteLine("3 - Limpar stock");
                    Console.WriteLine("4 - Voltar");

                    replanisherSelection = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (replanisherSelection)
                    {
                        case 1:
                            Console.WriteLine("Intoduza a categoria(CONGELADOS|PRATELEIRA|E): ");
                            nCategory = Console.ReadLine();
                            Console.WriteLine("Intoduza o nome do produto: ");
                            nName = Console.ReadLine();
                            Console.WriteLine("Introduza a quantidade deste produto: ");
                            nProductQnt = int.Parse(Console.ReadLine());
                            Console.WriteLine("Introduza o preço do produto: ");
                            nPrice = int.Parse(Console.ReadLine());
                            pList.CreateProduct(Product.ConvertCategory(nCategory), nName, nProductQnt, nPrice);
                            pList.SaveToFileStock();
                            break;

                        case 2:
                            Console.WriteLine("Qual é o produto que pretende elimiar do stock: ");
                            string replanisherInput = Console.ReadLine();
                            bool result = pList.DeleteProductFromList(replanisherInput);
                            if (result)
                            {
                                Console.WriteLine("O Produto foi eliminado do stock com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Operação sem sucesso!");
                            }
                            break;

                        case 3:
                            if (pList.ClearStock())
                            {
                                Console.WriteLine("O stock foi eliminado com sucesso!");
                            }
                            break;

                        case 4: return;

                        default:
                            Console.WriteLine("Opção Inválida. Tente novamente");
                            break;
                    }
                    pList.SaveToFileStock();
                }
            }

            void MenuCashier()
            {
                int cashierSelection = 0;
                while (cashierSelection != 4)
                {
                    Console.WriteLine("     **MENU DO CAIXA**");

                    Console.WriteLine("1 - Vender Produtos");
                    Console.WriteLine("2 - Voltar");

                    cashierSelection = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (cashierSelection)
                    {
                        case 1:
                            MenuForSales();
                            Console.WriteLine("Funcionalidade que permite venda de produtos");
                            break;

                        case 2: return;

                        default:
                            Console.WriteLine("Opção Inválida. Tente novamente");
                            break;
                    }
                }
            }

            void MenuForSales()
            {
                int selection = 0;
                while (selection != 4)
                {
                    Console.WriteLine("     **VENDA DE PRODUTOS**");
                    
                    Console.WriteLine(pList.ToString());
                    Console.WriteLine("0 - Finalizar Compras do carrinho");
                    Console.WriteLine("1 - Adicionar Produtos ao carrinho");
                    Console.WriteLine("4 - Voltar");

                    selection = int.Parse(Console.ReadLine());
                    //Console.Clear();

                    switch (selection)
                    {
                        case 0:
                            iList.SaveInvoice();
                            pList.SaveToFileStock();
                            break;

                        case 1:
                            Console.WriteLine("Escreva o nome do produto que quer adicionar ao carrinho: ");
                            saleProductName = Console.ReadLine();
                            Console.WriteLine("Indique a quantidade do produto selecionado que pretende adicionar ao carrinho: ");
                            saleProductQnt = int.Parse(Console.ReadLine());
                            Product productMatch = pList.SelectProduct(saleProductName, saleProductQnt);
                            if (productMatch != null)
                            {
                                if (productMatch.productName == saleProductName && productMatch.productQnt >= saleProductQnt)
                                {
                                    productMatch.productQnt -= saleProductQnt;
                                    iList.CreateInvoiceLine(productMatch.productName, saleProductQnt, productMatch.price);
                                }
                                else
                                {
                                    Console.WriteLine("lamento mas só dispomos de " + productMatch.productQnt + ".");
                                }
                            }

                            break;

                        case 0:
                            pList.SaveToFileStock();
                         
                            return;

                        default:
                            Console.WriteLine("Opção Inválida. Tente novamente");
                            break;
                    }


                }
            }


        }
    }
}
