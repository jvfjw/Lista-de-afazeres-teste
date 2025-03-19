using System;
using System.IO;

class Program
{
    static void Main()
    {
        bool sair = false;
        string[] lista = new string[10];


        //LOOP PRINCIPAL
        while (!sair)
        {
            Console.WriteLine("\nLista de afazeres:");
            Console.WriteLine("1 - Adicionar um registro");
            Console.WriteLine("2 - Listar os registros");
            Console.WriteLine("3 - Exportar os registros");
            Console.WriteLine("4 - Remover um registro");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.WriteLine("Digite o que deseja adicionar à lista:");

                string entrada = Console.ReadLine()?.Trim(); // Remove espaços extras e evita valores nulos

                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Não é possível adicionar um registro vazio!");
                }
                else
                {
                    bool adicionado = false;
                    for (int i = 0; i < lista.Length; i++)
                    {
                        if (lista[i] == null)
                        {
                            lista[i] = entrada;
                            Console.WriteLine("Registro adicionado com sucesso!");
                            adicionado = true;
                            break;
                        }
                    }

                    if (!adicionado)
                    {
                        Console.WriteLine("A lista está cheia! Não é possível adicionar mais registros.");
                    }
                }
            }
            else if (opcao == "2")
            {
                Console.WriteLine("\nRegistros na lista:");

                bool vazia = true;
                for (int i = 0; i < lista.Length; i++)
                {
                    if (!string.IsNullOrEmpty(lista[i]))
                    {
                        Console.WriteLine($"{i + 1} - {lista[i]}");
                        vazia = false;
                    }
                }

                if (vazia)
                {
                    Console.WriteLine("A lista está vazia.");
                }
            }
            else if (opcao == "3")
            {
                var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\registros.txt"));

                using (StreamWriter logtxt = new StreamWriter(path, false))
                {
                    logtxt.WriteLine("Registros na lista:");
                    for (int i = 0; i < lista.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(lista[i]))
                        {
                            logtxt.WriteLine($"{i + 1} - {lista[i]}");
                        }
                    }
                }

                Console.WriteLine($"Registros exportados com sucesso para: {path}");
            }
            else if (opcao == "4")
            {
                Console.Write("Digite o número do registro que deseja remover: ");
                if (int.TryParse(Console.ReadLine(), out int numero) && numero > 0 && numero <= lista.Length)
                {
                    if (!string.IsNullOrEmpty(lista[numero - 1]))
                    {
                        Console.WriteLine($"Registro '{lista[numero - 1]}' removido com sucesso.");
                        lista[numero - 1] = null;

                        // Reorganiza a lista para evitar espaços vazios
                        for (int i = numero - 1; i < lista.Length - 1; i++)
                        {
                            lista[i] = lista[i + 1];
                        }
                        lista[lista.Length - 1] = null;
                    }
                    else
                    {
                        Console.WriteLine("Registro não encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Número inválido.");
                }
            }
            else if (opcao == "5")
            {
                sair = true;
            }
            else
            {
                Console.WriteLine("Opção inválida, tente novamente.");
            }
        }
    }
}
