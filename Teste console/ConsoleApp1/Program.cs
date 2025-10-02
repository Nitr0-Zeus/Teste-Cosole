using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCrudApp
{
    // Modelo da entidade
    public class Item
    {
        public int Id { get; set; }
        public string name { get; set; }
    }

    class Program
    {
        static List<Item> itens = new List<Item>();
        static int proximoId = 1;

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Aplicação CRUD Console ===");
                Console.WriteLine("1 - Listar itens");
                Console.WriteLine("2 - Adicionar item");
                Console.WriteLine("3 - Atualizar item");
                Console.WriteLine("4 - Remover item");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarItens();
                        break;
                    case "2":
                        AdicionarItem();
                        break;
                    case "3":
                        AtualizarItem();
                        break;
                    case "4":
                        RemoverItem();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Pausar();
                        break;
                }
            }
        }

        static void ListarItens()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Itens ===");

            if (itens.Count == 0)
            {
                Console.WriteLine("Nenhum item cadastrado.");
            }
            else
            {
                foreach (var item in itens)
                {
                    Console.WriteLine($"ID: {item.Id} - Nome: {item.name}");
                }
            }

            Pausar();
        }

        static void AdicionarItem()
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Item ===");
            Console.Write("Digite o nome do item: ");
            string nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido!");
                Pausar();
                return;
            }

            var novoItem = new Item
            {
                Id = proximoId++,
                name = nome
            };

            itens.Add(novoItem);
            Console.WriteLine("Item adicionado com sucesso!");
            Pausar();
        }

        static void AtualizarItem()
        {
            Console.Clear();
            Console.WriteLine("=== Atualizar Item ===");
            Console.Write("Digite o ID do item que deseja atualizar: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido!");
                Pausar();
                return;
            }

            var item = itens.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                Console.WriteLine("Item não encontrado!");
                Pausar();
                return;
            }

            Console.Write($"Digite o novo nome para o item (atual: {item.name}): ");
            string novoNome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novoNome))
            {
                Console.WriteLine("Nome inválido!");
                Pausar();
                return;
            }

            item.Nome = novoNome;
            Console.WriteLine("Item atualizado com sucesso!");
            Pausar();
        }

        static void RemoverItem()
        {
            Console.Clear();
            Console.WriteLine("=== Remover Item ===");
            Console.Write("Digite o ID do item que deseja remover: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido!");
                Pausar();
                return;
            }

            var item = itens.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                Console.WriteLine("Item não encontrado!");
                Pausar();
                return;
            }

            itens.Remove(item);
            Console.WriteLine("Item removido com sucesso!");
            Pausar();
        }

        static void Pausar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
