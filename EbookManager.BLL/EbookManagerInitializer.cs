using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EbookManager.BLL
{
    public class EbookManagerInitializer
    {
        public static ObservableCollection<Ebook> Ebooks { get; private set; }

        public static IList<Ebook> Initizialize()
        {
            if (!FilePaths.AppDirectoryExist())
            {
                var dir = Directory.CreateDirectory(FilePaths.AppDataDirectory);
                var dataDir = dir.CreateSubdirectory("data");
                dataDir.CreateSubdirectory("ebooks");
                File.Create(Path.Combine(dataDir.FullName, "ebooks.json")).Close();
                var list = new List<Ebook>();
                var jsonStr = JsonConvert.SerializeObject(list);
                File.WriteAllText(FilePaths.EbookListFile, jsonStr);
                File.Create(Path.Combine(dataDir.FullName, "genres.json")).Close();
                File.WriteAllText(FilePaths.EbookGenresFile, JsonConvert.SerializeObject(new List<string>()));
                dir.CreateSubdirectory("logs");
            }
            LoadEbooks();
            return Ebooks;
        }

        private static void LoadEbooks()
        {
            var jsonStr = File.ReadAllText(FilePaths.EbookListFile);
            Ebooks = JsonConvert.DeserializeObject<ObservableCollection<Ebook>>(jsonStr, new JsonSerializerSettings
            {
                ContractResolver = new PrivateResolver()
            });
        }

        private class PrivateResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);
                if (prop.Writable) return prop;
                var property = member as PropertyInfo;
                if (property == null) return prop;
                var hasPrivateSetter = property.GetSetMethod(true) != null;
                prop.Writable = hasPrivateSetter;
                return prop;
            }
        }
    }
}