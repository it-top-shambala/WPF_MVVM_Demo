using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WPF_MVVM_Demo.App;

public static class ProductUtility
{
    public static void ExportProducts(IEnumerable<Product> products, string path)
    {
        using var file = new FileStream(path, FileMode.Truncate, FileAccess.Write);
        JsonSerializer.Serialize(file, products);
    }

    public static IEnumerable<Product> ImportProducts(string path)
    {
        using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<Product>>(file);
    }
}
