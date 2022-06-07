using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Список_дел.Models;

namespace Список_дел.Services
{
    internal class FileOServices
    {
        private readonly string PATH;
        public FileOServices (string path)
        {
            PATH = path;
        }
        public BindingList<Todomodel> LoadData()
        {
            var FileExists = File.Exists(PATH);
            if (!FileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Todomodel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var FileText=reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Todomodel>>(FileText);
            }
        }
        public void SaveData(object todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output= JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }
        }
    }
}
