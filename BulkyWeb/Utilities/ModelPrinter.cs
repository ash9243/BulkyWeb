using System;
using System.Reflection;

public static class ModelPrinter{
    public static void PrintModel(object model){

        if(model == null){
            Console.WriteLine("model is null");
            return;
        }

        Type type = model.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach(PropertyInfo property in properties){
            object val = property.GetValue(model);

            if(val == null){
                Console.WriteLine("val is null");
            }
            else if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                PrintModel(val);
            }
            else{
                Console.WriteLine($"{property.Name} {val}");
            }
        }
    }
}