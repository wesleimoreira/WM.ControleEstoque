using System.Text.Json;

namespace WM.ControleEstoque.Aplicacao.Helps
{
    public class MetodosJson
    {
        public static T JsonSerializerObject<T>(object objeto) where T : class
        {
            if (objeto is null) return default!;

            var jsonString = MetodosJson.JsonSerializerString(objeto);

            if (string.IsNullOrWhiteSpace(jsonString)) return default!;

            return JsonSerializer.Deserialize<T>(jsonString) ?? default!;
        }

        public static string JsonSerializerString(object objeto)
        {
            return JsonSerializer.Serialize(objeto);
        }
    }
}
