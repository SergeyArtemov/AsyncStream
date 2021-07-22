using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AsyncStream
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await foreach(var number in GetNumberAsync()) 
            {
                Console.WriteLine(number);
            }

            // 2 пример
            Repository repo = new Repository();
            IAsyncEnumerable<string> data = repo.GetDataAsync();

            await foreach(var name in data)
            {
                Console.WriteLine(name);
            }

            
        }

        public static async IAsyncEnumerable<int> GetNumberAsync()
        {
            for (int i = 0; i<10; i++)
            {
                await Task.Delay(100);
                yield return i;

            }
        }
    }



    class Repository
    {
        string[] data = {"Moscow", "Tambov", "Rostov"};
        public async IAsyncEnumerable<string> GetDataAsync()  // Метод , реализущий асинхронный стрим
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine($"Получаем {i+1}-ый элемент");
                await Task.Delay(500);
                yield return data[i];   // Выдаем на выход стрима по мере готовности данных

            }
        }


    }
}
