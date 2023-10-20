// using System.Runtime.InteropServices.JavaScript;
// using System;
// using Nethereum.Web3;
// using System.Threading.Tasks;
// using System.Text.Json;
// using System.Reflection;
// using System.Security.Cryptography;
// // using Newtonsoft.Json;

// public class CommandInput
// {
//         public string? key { get; set; }
// }

// public class MethodAndAttribute {
//     public MethodInfo? methodInfo { get; set; }
//     public PluginFnAttribute? attribute { get; set; }
// }

// public partial class Plugin
// {

//     // [JSExport]
//     // public static async Task<string> Run(string jsonString)
//     // {
//     //     ExampleInput? dto = JsonSerializer.Deserialize<ExampleInput>(jsonString);

//     //     var web3 = new Web3("https://bsc-dataseed1.ninicoin.io");

//     //     Console.WriteLine($"HEYEHY {dto?.url}");
//     //     await Task.Delay(2000);
//     //     try {
//     //         var t = await ExampleService.ExampleFunc(dto);

//     //         return t;
//     //         // var balance = await web3.Eth.GetBalance.SendRequestAsync("0x961a14bEaBd590229B1c68A21d7068c8233C8542");
//     //         // var etherAmount = Web3.Convert.FromWei(balance.Value);
//     //         // return etherAmount.ToString();
//     //     } catch (Exception e) {
//     //         Console.WriteLine(e.ToString());
//     //     }
//     //     return "LSLSL";
//     // }

//     [JSExport]
//     public static async Task<string> Run(string jsonString)
//     {
//         // dynamic dto = JsonConvert.DeserializeObject<dynamic>(jsonString);
//         CommandInput dto = JsonSerializer.Deserialize<CommandInput>(jsonString);

//         // Console.WriteLine($"DTO.key: {dto?.key}");

//         Type[] types = Assembly.GetExecutingAssembly().GetTypes();
//         var potentialMethods = (from t in types where t.IsClass select t.GetMethods().SelectMany(m => {
//             return System.Attribute.GetCustomAttributes(m)
//                 .Where(x => x is PluginFnAttribute)
//                 .Where(x => (x as PluginFnAttribute).GetKey().Equals(dto?.key.ToString()))
//                 .Select(x => { return new MethodAndAttribute { methodInfo = m, attribute = x as PluginFnAttribute }; });
//         })).SelectMany(x => x).ToArray();

//         if (potentialMethods.Length == 0) {
//             return $"Method {dto?.key} not Found.";
//         }
//         MethodAndAttribute method = potentialMethods.GetValue(0) as MethodAndAttribute;

//         if ((method.methodInfo.ReturnParameter as ParameterInfo).ParameterType.BaseType.ToString().Equals("System.Threading.Tasks.Task")) {
//             Console.WriteLine("Task");

//             var taskReturnType = (method.methodInfo.ReturnParameter as ParameterInfo).ParameterType;
//             var genericArguments = (method.methodInfo.ReturnParameter as ParameterInfo).ParameterType.GenericTypeArguments;
//             var argType = genericArguments.GetValue(0) as Type;


//             if (method.methodInfo.GetParameters().Length == 0) {
//                 var resultTaskObject = (Task)method.methodInfo.Invoke(null,new object[] { } );//await Task.Run(() => { return method.methodInfo.Invoke(null,new object[] { param } ); } );
//                 await resultTaskObject.ConfigureAwait(false);
//                 var resultProperty = resultTaskObject.GetType().GetProperty("Result");
//                 var resultObject = resultProperty.GetValue(resultTaskObject);
//                 var returnType = (method.methodInfo.ReturnParameter as ParameterInfo).ParameterType;
//                 var serializeMethod = typeof(Newtonsoft.Json.JsonConvert).GetMethod("SerializeObject", new[] { argType } );
//                 return (string)serializeMethod.Invoke(null, new object[]{ resultObject });
//             } else {
//                 var parameterType = (method.methodInfo.GetParameters().GetValue(0) as ParameterInfo).ParameterType;
//                 var param = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, parameterType);

//                 var resultTaskObject = (Task)method.methodInfo.Invoke(null,new object[] { param } );//await Task.Run(() => { return method.methodInfo.Invoke(null,new object[] { param } ); } );
//                 await resultTaskObject.ConfigureAwait(false);
//                 var resultProperty = resultTaskObject.GetType().GetProperty("Result");
//                 var resultObject = resultProperty.GetValue(resultTaskObject);
//                 var returnType = (method.methodInfo.ReturnParameter as ParameterInfo).ParameterType;
//                 var serializeMethod = typeof(Newtonsoft.Json.JsonConvert).GetMethod("SerializeObject", new[] { argType } );
//                 return (string)serializeMethod.Invoke(null, new object[]{ resultObject });
//             }
//         } else {

//             if (method.methodInfo.GetParameters().Length == 0) {
//                 var resultObject = method.methodInfo.Invoke(null,new object[] { } );

//                 var returnType = (method.methodInfo.ReturnParameter as ParameterInfo).ParameterType;
//                 var serializeMethod = typeof(Newtonsoft.Json.JsonConvert).GetMethod("SerializeObject", new[] { returnType } );
//                 return (string)serializeMethod.Invoke(null, new object[]{ resultObject });
//             } else {
//                 var parameterType = (method.methodInfo.GetParameters().GetValue(0) as ParameterInfo).ParameterType;
//                 var param = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString, parameterType);
//                 var resultObject = method.methodInfo.Invoke(null,new object[] { param } );

//                 var returnType = (method.methodInfo.ReturnParameter as ParameterInfo).ParameterType;
//                 var serializeMethod = typeof(Newtonsoft.Json.JsonConvert).GetMethod("SerializeObject", new[] { returnType } );
//                 return (string)serializeMethod.Invoke(null, new object[]{ resultObject });
//             }

//         }
//     }

// }

using System.Runtime.InteropServices.JavaScript;
using Keepix.PluginSystem;
using System.Reflection;
public partial class Plugin {
    
    [JSExport]
    public static async Task<string> Run(string jsonString) {
        return await KeepixPlugin.Run(jsonString, Assembly.GetExecutingAssembly().GetTypes());
    }
}