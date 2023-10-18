using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PizzeriaVisual
{
    internal class DatabaseManager
    {
        public static int CreateItem<T>(T item, string _path) where T : class
        {
            Console.WriteLine("AddItem");
            List<T> items = LoadDataFromJsonFile<T>(_path);
            bool itemExists = false;
            foreach (T existingItem in items)
            {
                if (existingItem.Equals(item))
                {
                    itemExists = true;
                    break;
                }
            }

            if (!itemExists)
            {
                items.Add(item);
                SaveDataToJsonFile(items, _path);
                return 0;
            }
            else
            {

                return 1;
            }
        }

        public static List<T> AllItems<T>(string _path) where T : class
        {
            if (File.Exists(_path))
            {
                // Le fichier existe, vous pouvez appeler LoadDataFromJsonFile avec fullPath
                List <T>data = LoadDataFromJsonFile<T>(_path);
                return data;
            }
            else
            {
                // Le fichier n'existe pas, affichez un message d'erreur
                Console.WriteLine("Le fichier JSON n'existe pas à l'emplacement spécifié.");
                return null;
            }
        }

        public static List<T> FindBy<T>(string _path, Func<T, bool> predicate) where T : class
        {
            List<T> items = LoadDataFromJsonFile<T>(_path);
            List<T> filteredItems = items.Where(predicate).ToList();
            return filteredItems;
        }

        public static List<T> LoadDataFromJsonFile<T>(string filePath) where T : class
        {
            List<T> data;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Console.WriteLine(json);

                if (!string.IsNullOrEmpty(json))
                {
                    data = JsonSerializer.Deserialize<List<T>>(json);
                }
                else
                {
                    data = new List<T>();
                }
            }
            else
            {
                data = new List<T>();
            }
            return data;
        }




        public static void SaveDataToJsonFile<T>(List<T> data, string filePath) where T : class
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }
    }
    }   
